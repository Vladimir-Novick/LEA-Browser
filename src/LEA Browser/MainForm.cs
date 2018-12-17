﻿using LEA.Lib;
using LEA.Lib.DB;
using LEA.Lib.Model;
using LEA_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEA.Browser
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        private BindingSource productBindingSource = new BindingSource();

        private VoiceCallItem voiceCallItem = new VoiceCallItem();

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitDataGridViewProduct();
                InitComboBoxInvestigationChooser();
                backgroundWorkerChooser.WorkerReportsProgress = true;
                backgroundWorkerChooser.WorkerSupportsCancellation = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {ex.Message}");
            }
        }

        private void InitDataGridViewProduct()
        {
            this.productBindingSource.DataSource = new BindingList<ProductItem>();

            dataGridViewProduct.DataSource = this.productBindingSource;

            dataGridViewProduct.Columns["Id"].Visible = false;
            dataGridViewProduct.Columns["InvestigationId"].Visible = false;
            dataGridViewProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduct.AllowUserToAddRows = false;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.ValuesAreIcons = true;
            img.HeaderText = "";
            img.Name = "img";
            dataGridViewProduct.Columns.Add(img);
            dataGridViewProduct.Columns["img"].Width = 42;
            dataGridViewProduct.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dataGridViewProduct.Columns["CreationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridViewProduct.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            dataGridViewProduct.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridViewProduct.ReadOnly = true;

        }

        private void InitComboBoxInvestigationChooser()
                        => UpdateInvestigationChooser();

        private void UpdateInvestigationChooser()
        {
            var dbReader = new DBReader();
            var investigationItems = dbReader.GetInvestigationItems();

            var list = investigationItems.OrderBy(x => x.Name).ToList();

            var itemSelect = new InvestigationItem() { id = -1, Name = "Please Select", CreationDate = DateTime.Now };
            list.Insert(0, itemSelect);


            comboBoxInvestigationChooser.DisplayMember = "Name";
            comboBoxInvestigationChooser.ValueMember = "id";
            comboBoxInvestigationChooser.DataSource = list;

            if (list.Count > 0)
            {
                comboBoxInvestigationChooser.SelectedIndex = 0;
            }

        }

        private void comboBoxInvestigationChooser_SelectedIndexChanged(object sender, EventArgs e)
                 => GetProductList((ComboBox)sender);

        private void GetProductList(ComboBox comboxChooser)
        {
            int selectedValue = (int)comboxChooser.SelectedValue;

            if (backgroundWorkerChooser.IsBusy != true)
            {
                comboBoxInvestigationChooser.Enabled = false;
                SetEnable(false);
                var paramItems = new SelectProductParamItems()
                {
                    selectedValue = selectedValue

                };
                backgroundWorkerChooser.RunWorkerAsync(argument: paramItems);

            }
        }

        private void backgroundWorkerChooser_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var value = (SelectProductParamItems)e.Argument;
            var dbReader = new DBReader();
            var productItems = dbReader.GetProduct(value);
            e.Result = productItems;
        }

        private void backgroundWorkerChooser_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            comboBoxInvestigationChooser.Enabled = true;

            var productItems = (BindingList<ProductItem>)e.Result;

            this.productBindingSource.DataSource = productItems;

            dataGridViewProduct.DataSource = this.productBindingSource;

            dataGridViewProduct.DataSource = productItems;
            dataGridViewProduct.Columns["Id"].Visible = false;
            dataGridViewProduct.Columns["InvestigationId"].Visible = false;
            dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChangeImageToDataGrid();
            SetEnable(true);

        }

        internal void ChangeImageToDataGrid()
        {

            for (int i = 0; i < dataGridViewProduct.Rows.Count; i++)
            {
                int type = GetRecordType(i);
                SetImageToRecord(i, type);
            }
        }

        private int GetRecordType(int recordIndex)
        {
            DataGridViewRow item = dataGridViewProduct.Rows[recordIndex];
            string str = (item.Cells["Type"].Value?.ToString()) ?? "";

            int type = -1;
            int.TryParse(str, out type);
            return type;
        }

        internal void SetImageToRecord(int rowIndex, int recordType)
        {
            switch (recordType)
            {
                case AppConstants.CallRecordTypeCallID:
                    dataGridViewProduct.Rows[rowIndex].Cells["img"].Value = LEA_Browser.Properties.Resources.call;
                    break;
                case AppConstants.CallRecordTypeSmsID:
                    dataGridViewProduct.Rows[rowIndex].Cells["img"].Value = LEA_Browser.Properties.Resources.sms;
                    break;
                default:
                    dataGridViewProduct.Rows[rowIndex].Cells["img"].Value = LEA_Browser.Properties.Resources.zero;
                    break;
            }
        }

        private void dataGridViewProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // Type field
            {
                int objectType = (int)dataGridViewProduct.Rows[e.RowIndex].Cells["Type"].Value;
                SetImageToRecord(e.RowIndex, objectType);
            }
        }

        internal void pictureBox1_MouseEnter(object sender, EventArgs e) =>
            pictureBoxCastle.Cursor = Cursors.Hand;

        internal void pictureBoxCastle_MouseLeave(object sender, EventArgs e) =>
                 pictureBoxCastle.Cursor = Cursors.Default;

        private Boolean isEditabble { get; set; } = false;


        private void pictureBoxCastle_Click(object sender, EventArgs e)
        {
            if (!isEditabble)
            {
                FormLogin login = new FormLogin();
                login.ShowDialog();

                if (!FormLogin.isLogin)
                {
                    return;
                }
            }

            if (!isEditabble)
            {
                pictureBoxCastle.Image = LEA_Browser.Properties.Resources.castle22_open;
                isEditabble = true;
            }
            else
            {
                pictureBoxCastle.Image = LEA_Browser.Properties.Resources.castle22;
                isEditabble = false;
            }

            SetEnable(isEditabble);
        }

        private void SetEnable(Boolean enable)
        {
            if (enable)
            {
                if (isEditabble)
                {
                    dataGridViewProduct.ReadOnly = false;
                    buttonImageBoxDelete.Enabled = true;
                    buttonImageBoxEditChooser.Enabled = true;
                    textBoxSMSText.Enabled = true;
                    buttonImageBoxGetFolder.Enabled = true;
                    textBoxFilePath.Enabled = true;
                    buttonAddRow.Enabled = true;
                    buttonPlay.Enabled = true;

                    buttonSave.Enabled = true;

                    dataGridViewProduct.Columns["CreationDate"].ReadOnly = true;
                    dataGridViewProduct.Columns["Investigation"].ReadOnly = true;

                }
            }
            else
            {
                dataGridViewProduct.ReadOnly = true;
                buttonImageBoxDelete.Enabled = false;
                buttonPlay.Enabled = false;
                buttonImageBoxEditChooser.Enabled = false;
                textBoxSMSText.Enabled = false;
                buttonImageBoxGetFolder.Enabled = false;
                textBoxFilePath.Enabled = false;
                buttonAddRow.Enabled = false;

                buttonSave.Enabled = false;

            }
        }

        private void MainForm_Resize(object sender, EventArgs e) =>
                                        Panel_SmsDetails.Width = this.ClientSize.Width / 2;

        private void MainForm_Shown(object sender, EventArgs e) =>
                                        Panel_SmsDetails.Width = this.ClientSize.Width / 2;

        private void buttonImageBoxEditChooser_Click(object sender, EventArgs e)
        {

            String investigationSelect = comboBoxInvestigationChooser.Text;
            FormInvestigations formInvestigations = new FormInvestigations();

            formInvestigations.ShowDialog();

            UpdateInvestigationChooser();

        }

        private void buttonImageBoxGetFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "audio files|*.wav|MP3 Files|*.mp3|All files|*.*";
            openFileDialog1.Title = "Select an Audio File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog1.FileName;
                voiceUpdate = true;

                voicePathText = textBoxFilePath.Text;

                currentProductID = GetCurrentProductId();
                SaveTextBoxPath();
            }
        }

        private void buttonImageBoxDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = dataGridViewProduct.SelectedRows.Count;
            if (rowSelected == 0)
            {
                MessageBox.Show("No row selected. Please select one or more rows.");
                return;
            }

            string message = "Are you sure you want to delete selected items?";
            string caption = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                List<int> rows = new List<int>();
                foreach (DataGridViewRow item in dataGridViewProduct.SelectedRows)
                {
                    int Id = (int)item.Cells["Id"].Value;
                    rows.Add(Id);
                }

                DBReader dBReader = new DBReader();
                dBReader.DeleteProducts(rows);

                foreach (DataGridViewRow item in dataGridViewProduct.SelectedRows)
                {
                    dataGridViewProduct.Rows.RemoveAt(item.Index);
                }

            }

        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            int selectedValue = (int)comboBoxInvestigationChooser.SelectedValue;
            if (selectedValue <= 0)
            {
                MessageBox.Show("Please select Investigation");
                return;
            }
            DBReader dBReader = new DBReader();
            BindingList<ProductItem> productItems = dBReader.AddProduct(selectedValue);

            if (productItems != null)
            {
                this.productBindingSource.Add(productItems[0]);
            }
        }

        private void dataGridViewProduct_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
               => SetImageToRecord(e.RowIndex, GetRecordType(e.RowIndex));

        private void buttonRefresh_Click(object sender, EventArgs e)
              => GetProductList(comboBoxInvestigationChooser);

        void tx_KeyPress(object sender, KeyPressEventArgs e) =>
              e.Handled = (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b')) ? true : false;

        private void dataGridViewProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tx = e.Control as TextBox;
            if (this.dataGridViewProduct.CurrentCell.ColumnIndex == 2)
            {
                tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
            }
            else
            {
                tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
            }

            tx.TextChanged += new EventHandler(tb_TextChanged);

        }

        private int rowModifiedIndex = -1;

        void tb_TextChanged(object sender, EventArgs e)
             => rowModifiedIndex = dataGridViewProduct.CurrentRow.Index;

        private void dataGridViewProduct_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int value = GetRecordType(e.RowIndex);
                if (value == -1)
                {
                    dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value = AppConstants.CallRecordTypeCallID;
                    e.Cancel = true;
                }
            }
            e.Cancel = false;

        }

        private void dataGridViewProduct_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.ColumnIndex == 2)
            {
                // MessageBox.Show("Product type not be empty");
            }
            else
            {
                MessageBox.Show("Error happened " + anError.Context.ToString());
            }
        }

        private void dataGridViewProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            => dataGridViewProduct.BindingContext[dataGridViewProduct.DataSource].EndCurrentEdit();


        private void dataGridViewProduct_SelectionChanged(object sender, EventArgs e)
          => SaveProductRow();

        private void SaveProductRow()
        {
            if (rowModifiedIndex >= 0)
            {

                ProductItem productItem = dataGridViewProduct.Rows[rowModifiedIndex]?.DataBoundItem as ProductItem;
                if (productItem != null)
                {
                    (new DBReader()).UpdateProductRecord((ProductItem)productItem.Clone());

                }
                rowModifiedIndex = -1;

            };
        }

        private void dataGridViewProduct_Leave(object sender, EventArgs e)
            => SaveProductRow();

        private void dataGridViewProduct_RowLeave(object sender, DataGridViewCellEventArgs e)
            => SaveProductRow();

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        private void dataGridViewProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ProductItem productItem = dataGridViewProduct.Rows[e.RowIndex].DataBoundItem as ProductItem;

            textBoxSMSText.Text = "";
            textBoxFilePath.Text = "";

            switch (productItem.Type)
            {

                case AppConstants.CallRecordTypeCallID:

                    GetVoiceRecord(productItem);
                    break;

                case AppConstants.CallRecordTypeSmsID:
                    GetSmsRecord(productItem);
                    break;

            }

            ChangeDetailsPanel(productItem.Type);

        }

        private void GetVoiceRecord(ProductItem productItem)
        {
            #region create task for VoiceRecord

            Task<VoiceCallItem> task = new Task<VoiceCallItem>(() =>
            {

                return (new DBReader()).GetVoiceRecordAction(productItem);
            });

            String key = "GetVoiceRecord:" + productItem.Id.ToString();
            task.ContinueWith(t =>
            {
                ThreadHelper.SetText(this, textBoxFilePath, t.Result.Path);
                DBReader.threadPool.TryRemove(key, out Task oldItem);

            });


            DBReader.threadPool.TryAdd(key, task);
            task.Start();

            #endregion
        }

        #region get SmsRecord
        private void GetSmsRecord(ProductItem productItem)
        {


            Task<SmsMessageItem> taskSMS = new Task<SmsMessageItem>(() =>
            {

                return (new DBReader()).GetSmsRecorddAction(productItem);
            });

            String keySMS = "GetSMSRecord:" + productItem.Id.ToString() + GetTimestamp(DateTime.Now);

            taskSMS.ContinueWith(t =>
            {
                ThreadHelper.SetText(this, textBoxSMSText, t.Result.Text);
                DBReader.threadPool.TryRemove(keySMS, out Task oldItem);

            });



            DBReader.threadPool.TryAdd(keySMS, taskSMS);
            taskSMS.Start();


        }

        #endregion

        private void ChangeDetailsPanel(int? productType)
        {
            switch (productType)
            {

                case AppConstants.CallRecordTypeCallID:

                    Panel_SmsDetails.Visible = false;

                    Panel_CallDetails.Visible = true;
                    Panel_CallDetails.Dock = DockStyle.Fill;
                    break;

                case AppConstants.CallRecordTypeSmsID:

                    Panel_CallDetails.Visible = false;
                    Panel_SmsDetails.Visible = true;
                    Panel_SmsDetails.Dock = DockStyle.Fill;
                    break;
                default:
                    Panel_SmsDetails.Visible = false;
                    Panel_CallDetails.Visible = false;
                    break;

            }
        }

        private void dataGridViewProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewProduct.IsCurrentCellDirty)
            {
                dataGridViewProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dataGridViewProduct.CurrentCell.ColumnIndex == 2)
                {
                    SaveProductRow();
                    int? type = dataGridViewProduct.CurrentCell.Value as int?;
                    ChangeDetailsPanel(type);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
           => SaveProductRow();

        #region update SmsMessage to DB
        private bool smsUpdate = false;
        private string newsmsText = "";
        private int currentProductID = -1;




        private void textBoxSMSText_TextChanged(object sender, EventArgs e)
        {
            smsUpdate = true;
            TextBox box = sender as TextBox;
            newsmsText = box.Text;
            currentProductID = GetCurrentProductId();

        }

        private int GetCurrentProductId()
        {
            int currentIndex = (dataGridViewProduct?.CurrentRow?.Index) ?? -1;
            if (currentIndex >= 0)
            {
                ProductItem productItem = dataGridViewProduct.Rows[currentIndex].DataBoundItem as ProductItem;
                return productItem.Id;
            }
            return -1;

        }

        private void textBoxSMSText_Leave(object sender, EventArgs e)
        {
            if (smsUpdate)
            {
                smsUpdate = false;
                if (currentProductID == -1) return;

                SmsMessageItem smsMessageItem = new SmsMessageItem() { ProductID = currentProductID, Text = newsmsText };

                currentProductID = -1;
                (new DBReader()).UpdateSmsMessage(smsMessageItem);
            }
        }

        #endregion

        #region Update VoiceCallItem to DB

        private bool voiceUpdate { get; set; } = false;
        private string voicePathText { get; set; } = "";

        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            voiceUpdate = true;
            TextBox box = sender as TextBox;
            voicePathText = box.Text;

            currentProductID = GetCurrentProductId();
        }

        private void textBoxFilePath_Leave(object sender, EventArgs e)
             => SaveTextBoxPath();

        private void SaveTextBoxPath()
        {
            if (voiceUpdate)
            {
                voiceUpdate = false;
                if (currentProductID == -1) return;

                VoiceCallItem voiceCallItemArg = new VoiceCallItem() { ProductId = currentProductID, Path = voicePathText };

                currentProductID = -1;
                (new DBReader()).UpdateVoiceCallItem(voiceCallItemArg);
            }
        }

        #endregion
    }
}
