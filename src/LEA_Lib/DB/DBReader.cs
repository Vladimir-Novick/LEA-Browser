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
        public void GetUserName(out String UserName, out String Password)
        {
            UserName = ConfigUtils.GetConfig()["UserName"];
            Password = ConfigUtils.GetConfig()["Password"];
        }

        public BindingList<ProductItem> GetProduct(SelectProductParamItems param)
        {
            var productItems = new BindingList<ProductItem>();
            String sql = $"exec SelectProduct @InvestigationId = {param.selectedValue};";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(productItems, ReadProductItem, connetionString, sql);
           

            return productItems;
        }

        public BindingList<ProductItem> AddProduct(int investigationId)
        {
            var productItems = new BindingList<ProductItem>();
            String sql = $"exec sp_AddProduct @InvestigationId = {investigationId};";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(productItems, ReadProductItem, connetionString, sql);

            if (productItems.Count > 0)
            {
                return productItems;
            }
            return null;
        }

        private static bool ReadProductItem(Object obj, SqlDataReader sqlDataReader)
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

        public List<InvestigationItem> GetInvestigationItems()
        {
            var investigations = new List<InvestigationItem>();

            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            String sql = "Select * from dbo.[Investigation];";

            ReadListFromDatabase(investigations, ReadInvestigationItem, connetionString, sql);
            return investigations;
        }



        private static void ReadListFromDatabase(Object list, 
               Func<Object,SqlDataReader,bool> ReadInvestigationItem,
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

        private static bool ReadInvestigationItem(Object obj, SqlDataReader sqlDataReader)
        {
            List<InvestigationItem> investigations = obj as List<InvestigationItem>;
            int id = sqlDataReader.GetInt32(0); // id
            String Name = sqlDataReader.GetString(1); // Name
            DateTime CreationDate = sqlDataReader.GetDateTime(2);
            var item = new InvestigationItem() { id = id, Name = Name, CreationDate = CreationDate };
            investigations.Add(item);
            return true;
        }

        Action<object> DeleteProductAction = (object obj) =>
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

        #region UpdateInvestigationItem

        public void UpdateInvestigationItemRecord(InvestigationItem investigationItem)
        {
            Task task = new Task(UpdateinvestigationItemAction, investigationItem);
            String key = "UpdateInvestigationRecord:" + investigationItem.id.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }

        Action<object> UpdateinvestigationItemAction = (object obj) =>
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

        #endregion UpdateInvestigationItem

        public InvestigationItem AddInvestigation()
        {
            List<InvestigationItem> investigations = new List<InvestigationItem>() ;
            String sql = $"exec sp_AddInvestigation ;";
            string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];
            ReadListFromDatabase(investigations, ReadInvestigationItem, connetionString, sql);
            if (investigations.Count > 0) return investigations[0];
            return null;
        }


        #region DeleteInvestigation items

        public void DeleteInvestigationRows(List<int> rows)
        {
            Task task = new Task(DeleteInvestigationAction, rows);
            String key = "deleteInvestigation: "+ rows.ToKey();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> DeleteInvestigationAction = (object obj) =>
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


        #endregion

        public static ConcurrentDictionary<String, Task> threadPool = new ConcurrentDictionary<String, Task>();

        public void DeleteProducts(List<int> rows)
        {
            Task task = new Task(DeleteProductAction, rows);
            String key = rows.ToKey();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }



        #region UpdateProductRecord

        public void UpdateProductRecord(ProductItem productItem)
        {
            Task task = new Task(UpdateProductRecordAction, productItem);
            String key = "UpdateProductRecord:" + productItem.Id.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> UpdateProductRecordAction = (object obj) =>
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


        #endregion


        public VoiceCallItem GetVoiceRecordAction(ProductItem productItem)
        {

            if (productItem == null) return null;

            VoiceCallItem voiceCallItem = new VoiceCallItem();
            voiceCallItem.Path = "Empty";
            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"SELECT [Path]
                                    FROM[dbo].[VoiceCall]
                                    where ProductId = {productItem.Id}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        var sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {

                            voiceCallItem.Path = sqlDataReader.GetString(0); // Name
                            voiceCallItem.ProductId = productItem.Id;
                            break;

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

            return voiceCallItem;

        }




        public SmsMessageItem GetSmsRecorddAction(ProductItem productItem)
        {
            if (productItem == null) return null;

            SmsMessageItem smsMessageItem = new SmsMessageItem();
            smsMessageItem.Text = "Empty";

            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

                using (var sqlConnection = new SqlConnection(connetionString))
                {
                    sqlConnection.Open();
                    String sql = $@"SELECT [Text]
                                    FROM[dbo].[SmsMessage]
                                    where ProductId = {productItem.Id}";
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        var sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {

                            smsMessageItem.Text = sqlDataReader.GetString(0); // Name
                            smsMessageItem.ProductID = productItem.Id;
                            break;

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

            return smsMessageItem;
        }


        #region Update SmsMessage

        public void UpdateSmsMessage(SmsMessageItem smsMessageItem)
        {
            Task task = new Task(UpdateSmsMessageRecordAction, smsMessageItem);
            String key = "UpdateSmsMessageRecord:" + smsMessageItem.ProductID.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> UpdateSmsMessageRecordAction = (object obj) =>
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

        #endregion


        #region Update VoiceCallItem DB record

        public void UpdateVoiceCallItem(VoiceCallItem voiceCallItem)
        {
            Task task = new Task(UpdateVoiceCallItemAction, voiceCallItem);
            String key = "UpdateVoiceCallItemRecor:" + voiceCallItem.ProductId.ToString();
            threadPool.TryAdd(key, task);
            task.ContinueWith(t =>
            {

                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });
            task.Start();
        }


        Action<object> UpdateVoiceCallItemAction = (object obj) =>
        {
            VoiceCallItem voiceCallItem = obj as VoiceCallItem;
            if (voiceCallItem == null) return;
            try
            {
                string connetionString = ConfigUtils.GetConfig()[AppConstants.ConnectionString];

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

        #endregion
    }
}
