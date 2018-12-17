using LEA.Lib.Model;
using LEA_Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LEA.Lib.DB
{
    public class DBReader
    {
        public static ConcurrentDictionary<String, Task> threadPool = new ConcurrentDictionary<String, Task>();


        public void GetUserName(out String UserName, out String Password)
        {
            UserName = ConfigUtils.GetConfig()["UserName"];
            Password = ConfigUtils.GetConfig()["Password"];
        }

        private static void ReadListFromDatabase(Object list,
       Func<Object, SqlDataReader, bool> ReadInvestigationItem,
       string connetionString,
       string sql)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();

                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        var sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            ReadInvestigationItem(list, sqlDataReader);
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //TODO using NLOG
                Console.WriteLine(ex.Message);
            }
        }


        public BindingList<ProductItem> ProductGet(SelectProductParamItems param)
        {
            var productItems = new BindingList<ProductItem>();
            String sql = $"exec SelectProduct @InvestigationId = {param.selectedValue};";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(productItems, ProductReadItems, connetionString, sql);
            return productItems;
        }

        public BindingList<ProductItem> ProductAdd(int investigationId)
        {
            var productItems = new BindingList<ProductItem>();
            String sql = $"exec sp_AddProduct @InvestigationId = {investigationId};";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(productItems, ProductReadItems, connetionString, sql);

            if (productItems.Count > 0)
            {
                return productItems;
            }
            return null;
        }


        public void ProductDeleteCreateTask(List<int> rows)
        {
            Task task = new Task(ProductDeleteAction, rows);
            String key = rows.ToKey();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }

        Action<object> ProductDeleteAction = (object obj) =>
        {
            List<int> deleteRecords = (List<int>)obj;

            String key = deleteRecords.ToKey();

            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $"DELETE FROM [dbo].[Product] WHERE Id in ({key})";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }

            threadPool.TryRemove(key, out Task deleted);
        };

        internal static bool ProductReadItems(Object obj, SqlDataReader sqlDataReader)
        {
            BindingList<ProductItem> productItems = obj as BindingList<ProductItem>;
            int id = sqlDataReader.GetInt32(0); // id
            int Type = sqlDataReader.IsDBNull(1) ? 1 : sqlDataReader.GetInt32(1); // Type
            DateTime CreationDate = sqlDataReader.IsDBNull(2) ? DateTime.MinValue : sqlDataReader.GetDateTime(2);

            String Source = sqlDataReader.IsDBNull(3) ? "" : sqlDataReader.GetString(3); // Source
            String Destination = sqlDataReader.IsDBNull(4) ? "" : sqlDataReader.GetString(4); // Destination
            int InvestigationId = sqlDataReader.IsDBNull(5) ? 1 : sqlDataReader.GetInt32(5); // InvestigationId
            String Investigation = sqlDataReader.IsDBNull(6) ? "" : sqlDataReader.GetString(6); // Investigation
            var item = new ProductItem()
            {
                Id = id,
                Type = Type,
                CreationDate = CreationDate,
                Source = Source,
                Destination = Destination,
                InvestigationId = InvestigationId,
                Investigation = Investigation

            };

            productItems.Add(item);
            return true;
        }

        public void ProductUpdateCreateTask(ProductItem productItem)
        {
            Task task = new Task(ProductUpdateAction, productItem);
            String key = "UpdateProductRecord:" + productItem.Id.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }



        Action<object> ProductUpdateAction = (object obj) =>
        {
            ProductItem productItem = obj as ProductItem;
            if (productItem == null) return;
            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"UPDATE [dbo].[Product]
                                      SET [Type] = {productItem.Type}
                                      ,[Source] = '{productItem.Source?.Replace("'", "''")}'
                                      ,[Destination] = '{productItem.Destination?.Replace("'", "''")}'
                                      ,[InvestigationId] = {productItem.InvestigationId}
                                   WHERE Id = {productItem.Id}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
        };


        public List<InvestigationItem> InvestigationGetItems()
        {
            var investigations = new List<InvestigationItem>();

            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            String sql = "Select * from dbo.[Investigation];";

            ReadListFromDatabase(investigations, InvestigationReadItems, connetionString, sql);
            return investigations;
        }





        private static bool InvestigationReadItems(Object obj, SqlDataReader sqlDataReader)
        {
            List<InvestigationItem> investigations = obj as List<InvestigationItem>;
            int id = sqlDataReader.GetInt32(0); // id
            String Name = sqlDataReader.GetString(1); // Name
            DateTime CreationDate = sqlDataReader.GetDateTime(2);
            var item = new InvestigationItem() { id = id, Name = Name, CreationDate = CreationDate };
            investigations.Add(item);
            return true;
        }

        public void InvestigationUpdateCreateTask(InvestigationItem investigationItem)
        {
            Task task = new Task(investigationUpdateAction, investigationItem);
            String key = "UpdateInvestigationRecord:" + investigationItem.id.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }

        Action<object> investigationUpdateAction = (object obj) =>
        {
            InvestigationItem investigationItem = obj as InvestigationItem;
            if (investigationItem == null) return;
            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"UPDATE [dbo].[Investigation]
       SET [Name] ='{investigationItem.Name}'
        WHERE  [id] = {investigationItem.id}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };

        public InvestigationItem InvestigationAdd()
        {
            List<InvestigationItem> investigations = new List<InvestigationItem>() ;
            String sql = $"exec sp_AddInvestigation ;";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(investigations, InvestigationReadItems, connetionString, sql);
            if (investigations.Count > 0) return investigations[0];
            return null;
        }

        public void InvestigationDeleteCreateTask(List<int> rows)
        {
            Task task = new Task(InvestigationDeleteAction, rows);
            String key = "deleteInvestigation: "+ rows.ToKey();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }

        Action<object> InvestigationDeleteAction = (object obj) =>
        {
            List<int> deleteRecords = (List<int>)obj;

            String key = deleteRecords.ToKey();

            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $"DELETE FROM [dbo].[Investigation] WHERE id in ({key})";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        };
 
        public VoiceCallItem VoiceGetAction(ProductItem productItem)
        {
            if (productItem == null) return null;

            String sql = $@"SELECT [Path],[ProductId]
                                    FROM[dbo].[VoiceCall]
                                    where ProductId = {productItem.Id}";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            List<VoiceCallItem> voiceCallItems = new List<VoiceCallItem>();
            ReadListFromDatabase(voiceCallItems, VoiceReadItems, connetionString, sql);

            if (voiceCallItems.Count == 0) {
               return new VoiceCallItem() { Path = "Empty", ProductId = productItem.Id };
            }
            return voiceCallItems[0];

        }

        internal static bool VoiceReadItems(Object obj, SqlDataReader sqlDataReader)
        {
            List<VoiceCallItem> voiceCallItems = obj as List<VoiceCallItem>;
            VoiceCallItem voiceCallItem = new VoiceCallItem();
            voiceCallItem.Path = sqlDataReader.GetString(0); // Name
            voiceCallItem.ProductId = sqlDataReader.GetInt32(1);
            voiceCallItems.Add(voiceCallItem);
            return true;
        }

        public void VoiceUpdateCreateTask(VoiceCallItem voiceCallItem)
        {
            Task task = new Task(VoiceUpdateAction, voiceCallItem);
            String key = "UpdateVoiceCallItemRecor:" + voiceCallItem.ProductId.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> VoiceUpdateAction = (object obj) =>
        {
            VoiceCallItem voiceCallItem = obj as VoiceCallItem;
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

            if (voiceCallItem == null) return;
            try
            {
                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"UPDATE [dbo].[VoiceCall]
                                 SET [Path] = '{(voiceCallItem.Path?.ToString() ?? "").Replace("'", "''")}'
                                 WHERE [ProductId] = {voiceCallItem.ProductId}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };


        #region  SmsMessage operation

        public SmsMessageItem SmsGetRecorddAction(ProductItem productItem)
        {
            if (productItem == null) return null;
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            String sql = $@"SELECT [Text],[ProductId]
                                    FROM[dbo].[SmsMessage]
                                    where ProductId = {productItem.Id}";

            List<SmsMessageItem> smsMessageItems = new List<SmsMessageItem>();
            ReadListFromDatabase(smsMessageItems, SmsReadItem, connetionString, sql);

            if (smsMessageItems.Count > 0)
            return smsMessageItems[0];
            return new SmsMessageItem() { ProductID = productItem.Id, Text = "Empty" };

        }

        private static bool SmsReadItem(Object obj, SqlDataReader sqlDataReader)
        {
            var smsMessageItems = obj as List<SmsMessageItem>;
            var smsMessageItem = new SmsMessageItem();
            smsMessageItem.Text = sqlDataReader.GetString(0); // Name
            smsMessageItem.ProductID = sqlDataReader.GetInt32(1);
            smsMessageItems.Add(smsMessageItem);
            return true;
        }


        public void SmsUpdateCreateTask(SmsMessageItem smsMessageItem)
        {
            Task task = new Task(SmsUpdateAction, smsMessageItem);
            String key = "UpdateSmsMessageRecord:" + smsMessageItem.ProductID.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> SmsUpdateAction = (object obj) =>
        {
            SmsMessageItem smsMessageItem = obj as SmsMessageItem;
            if (smsMessageItem == null) return;
            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"UPDATE [dbo].[SmsMessage]
                                       Set [Text] = '{(smsMessageItem.Text?.ToString() ?? "").Replace("'", "''")}'
                                        WHERE [ProductId] = {smsMessageItem.ProductID}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        };

        #endregion  SmsMessage operation



    }
}
