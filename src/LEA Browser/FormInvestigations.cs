using LEA.Lib.DB;
using LEA.Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEA.Browser
{
    public partial class FormInvestigations : Form
    {
        public FormInvestigations()
        {
            InitializeComponent();
        }

        private void dataGridViewPInvestigations_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewInvestigations.IsCurrentCellDirty)
            {


            }

        }

        private BindingSource investigationsBindingSource = new BindingSource();

        private void InitDataGridViewInvestigations()
        {
            this.investigationsBindingSource.DataSource = new BindingList<InvestigationItem>();

            dataGridViewInvestigations.DataSource = this.investigationsBindingSource;

            dataGridViewInvestigations.Columns["id"].Visible = false;

            dataGridViewInvestigations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInvestigations.AllowUserToAddRows = false;



            dataGridViewInvestigations.Columns["CreationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dataGridViewInvestigations.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            dataGridViewInvestigations.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            GetInvestigationsList();

        }

        private void FormInvestigations_Load(object sender, EventArgs e)
        {


            try
            {
                InitDataGridViewInvestigations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load {ex.Message}");
            }
        }

        private void SetEnable(Boolean enable)
        {
            if (enable)
            {
                dataGridViewInvestigations.ReadOnly = false;

                buttonImageBoxDelete.Enabled = true;
                buttonAddRow.Enabled = true;
                buttonSave.Enabled = true;
                dataGridViewInvestigations.Columns["CreationDate"].ReadOnly = true;
               
            }
            else
            {
                dataGridViewInvestigations.ReadOnly = true;
                buttonImageBoxDelete.Enabled = false;
                buttonAddRow.Enabled = false;
                buttonSave.Enabled = false;

            }
        }


        private void GetInvestigationsList()
        {
            if (backgroundWorker.IsBusy != true)
            {

                SetEnable(false);
                backgroundWorker.RunWorkerAsync();

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            var dbReader = new DBReader();
            var investigationItems = dbReader.InvestigationGetItems();
            BindingList<InvestigationItem> bindingListInvestigation = new BindingList<InvestigationItem>();
            foreach (var item in investigationItems)
            {
                bindingListInvestigation.Add(item);
            }
            e.Result = bindingListInvestigation;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            BindingList<InvestigationItem> BindingListInvestigation = e.Result as BindingList<InvestigationItem>;

            this.investigationsBindingSource.DataSource = BindingListInvestigation;

            dataGridViewInvestigations.DataSource = this.investigationsBindingSource;

            dataGridViewInvestigations.Columns["id"].Visible = false;

            dataGridViewInvestigations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetEnable(true);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
          => GetInvestigationsList();

        private void buttonSave_Click(object sender, EventArgs e)
         => SaveInvestigationRow();

        private int rowModifiedIndex = -1;

        private void SaveInvestigationRow()
        {
            if (rowModifiedIndex >= 0)
            {

                InvestigationItem investigationItem = dataGridViewInvestigations.Rows[rowModifiedIndex]?.DataBoundItem as InvestigationItem;
                if (investigationItem != null)
                {
                    (new DBReader()).InvestigationUpdateCreateTask((InvestigationItem)investigationItem.Clone());

                }
                rowModifiedIndex = -1;

            };
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            rowModifiedIndex = dataGridViewInvestigations.CurrentRow.Index;

        }

        private void dataGridViewInvestigations_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tx = e.Control as TextBox;
            if (tx != null)
            {

                tx.TextChanged += new EventHandler(tb_TextChanged);


            }

        }



        private void dataGridViewInvestigations_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewInvestigations.BindingContext[dataGridViewInvestigations.DataSource].EndCurrentEdit();
            dataGridViewInvestigations.EndEdit();
        }


        private void dataGridViewInvestigations_SelectionChanged(object sender, EventArgs e)
        {
            SaveInvestigationRow();
        }


        private void buttonAddRow_Click(object sender, EventArgs e)
        {

            DBReader dBReader = new DBReader();
            InvestigationItem investigationItem = dBReader.InvestigationAdd();

            if (investigationItem != null)
            {
                this.investigationsBindingSource.Add(investigationItem);
                
                dataGridViewInvestigations.Invalidate();

            }
        }

        private void buttonImageBoxDelete_Click(object sender, EventArgs e)
        {
            var rowSelected = dataGridViewInvestigations.SelectedRows.Count;
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
                foreach (DataGridViewRow item in dataGridViewInvestigations.SelectedRows)
                {
                    int Id = (int)item.Cells["id"].Value;
                    rows.Add(Id);
                }

                DBReader dBReader = new DBReader();
                dBReader.InvestigationDeleteCreateTask(rows);

                foreach (DataGridViewRow item in dataGridViewInvestigations.SelectedRows)
                {
                    dataGridViewInvestigations.Rows.RemoveAt(item.Index);
                }

            }
        }

        private void dataGridViewInvestigations_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Context.ToString());
        }
    }
}
