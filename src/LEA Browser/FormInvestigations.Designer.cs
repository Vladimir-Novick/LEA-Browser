using LEA_Browser;

namespace LEA.Browser
{
    partial class FormInvestigations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvestigations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewInvestigations = new System.Windows.Forms.DataGridView();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonSave = new LEA_Browser.ButtonImageBox();
            this.buttonRefresh = new LEA_Browser.ButtonImageBox();
            this.buttonAddRow = new LEA_Browser.ButtonImageBox();
            this.buttonImageBoxDelete = new LEA_Browser.ButtonImageBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvestigations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 38);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.buttonRefresh);
            this.panel2.Controls.Add(this.buttonAddRow);
            this.panel2.Controls.Add(this.buttonImageBoxDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 30);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewInvestigations
            // 
            this.dataGridViewInvestigations.AllowUserToAddRows = false;
            this.dataGridViewInvestigations.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewInvestigations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvestigations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInvestigations.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewInvestigations.Name = "dataGridViewInvestigations";
            this.dataGridViewInvestigations.ReadOnly = true;
            this.dataGridViewInvestigations.RowTemplate.ReadOnly = true;
            this.dataGridViewInvestigations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInvestigations.Size = new System.Drawing.Size(459, 303);
            this.dataGridViewInvestigations.TabIndex = 2;
            this.dataGridViewInvestigations.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewInvestigations_CellBeginEdit);
            this.dataGridViewInvestigations.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInvestigations_CellEndEdit);
            this.dataGridViewInvestigations.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewPInvestigations_CurrentCellDirtyStateChanged);
            this.dataGridViewInvestigations.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewInvestigations_EditingControlShowing);
            this.dataGridViewInvestigations.SelectionChanged += new System.EventHandler(this.dataGridViewInvestigations_SelectionChanged);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // buttonSave
            // 
            this.buttonSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonSave.DisableImage = global::LEA_Browser.Properties.Resources.save22_disabled1;
            this.buttonSave.Enabled = false;
            this.buttonSave.EnableImage = global::LEA_Browser.Properties.Resources.save22;
            this.buttonSave.Image = global::LEA_Browser.Properties.Resources.save22_disabled1;
            this.buttonSave.Location = new System.Drawing.Point(45, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(43, 27);
            this.buttonSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonSave.TabIndex = 13;
            this.buttonSave.TabStop = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonRefresh.DisableImage = global::LEA_Browser.Properties.Resources.refresh22;
            this.buttonRefresh.EnableImage = global::LEA_Browser.Properties.Resources.refresh22;
            this.buttonRefresh.Image = global::LEA_Browser.Properties.Resources.refresh22;
            this.buttonRefresh.Location = new System.Drawing.Point(129, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(43, 27);
            this.buttonRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.TabStop = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonAddRow.DisableImage = global::LEA_Browser.Properties.Resources.plus22_disabled11;
            this.buttonAddRow.Enabled = false;
            this.buttonAddRow.EnableImage = global::LEA_Browser.Properties.Resources.plus221;
            this.buttonAddRow.Image = global::LEA_Browser.Properties.Resources.plus22_disabled11;
            this.buttonAddRow.Location = new System.Drawing.Point(87, 0);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(43, 27);
            this.buttonAddRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonAddRow.TabIndex = 11;
            this.buttonAddRow.TabStop = false;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonImageBoxDelete
            // 
            this.buttonImageBoxDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonImageBoxDelete.DisableImage = global::LEA_Browser.Properties.Resources.trash22_disabled1;
            this.buttonImageBoxDelete.Enabled = false;
            this.buttonImageBoxDelete.EnableImage = global::LEA_Browser.Properties.Resources.trash22;
            this.buttonImageBoxDelete.Image = global::LEA_Browser.Properties.Resources.trash22_disabled1;
            this.buttonImageBoxDelete.Location = new System.Drawing.Point(3, 0);
            this.buttonImageBoxDelete.Name = "buttonImageBoxDelete";
            this.buttonImageBoxDelete.Size = new System.Drawing.Size(43, 27);
            this.buttonImageBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonImageBoxDelete.TabIndex = 10;
            this.buttonImageBoxDelete.TabStop = false;
            this.buttonImageBoxDelete.Click += new System.EventHandler(this.buttonImageBoxDelete_Click);
            // 
            // FormInvestigations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(459, 371);
            this.Controls.Add(this.dataGridViewInvestigations);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInvestigations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Investigations";
            this.Load += new System.EventHandler(this.FormInvestigations_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvestigations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ButtonImageBox buttonSave;
        private ButtonImageBox buttonRefresh;
        private ButtonImageBox buttonAddRow;
        private ButtonImageBox buttonImageBoxDelete;
        private System.Windows.Forms.DataGridView dataGridViewInvestigations;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}