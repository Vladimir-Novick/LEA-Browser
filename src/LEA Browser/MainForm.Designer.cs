namespace LEA.Browser
{
    partial class MainForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.buttonSave = new LEA_Browser.ButtonImageBox();
            this.buttonRefresh = new LEA_Browser.ButtonImageBox();
            this.buttonAddRow = new LEA_Browser.ButtonImageBox();
            this.buttonImageBoxEditChooser = new LEA_Browser.ButtonImageBox();
            this.buttonImageBoxDelete = new LEA_Browser.ButtonImageBox();
            this.pictureBoxCastle = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInvestigationChooser = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.Panel_CallDetails = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonImageBoxGetFolder = new LEA_Browser.ButtonImageBox();
            this.buttonPlay = new LEA_Browser.ButtonImageBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Panel_SmsDetails = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSMSText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerChooser = new System.ComponentModel.BackgroundWorker();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxEditChooser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCastle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.DetailsPanel.SuspendLayout();
            this.Panel_CallDetails.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxGetFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Panel_SmsDetails.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.TopPanel.Controls.Add(this.buttonSave);
            this.TopPanel.Controls.Add(this.buttonRefresh);
            this.TopPanel.Controls.Add(this.buttonAddRow);
            this.TopPanel.Controls.Add(this.buttonImageBoxEditChooser);
            this.TopPanel.Controls.Add(this.buttonImageBoxDelete);
            this.TopPanel.Controls.Add(this.pictureBoxCastle);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.comboBoxInvestigationChooser);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(619, 34);
            this.TopPanel.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonSave.DisableImage = global::LEA_Browser.Properties.Resources.save22_disabled1;
            this.buttonSave.Enabled = false;
            this.buttonSave.EnableImage = global::LEA_Browser.Properties.Resources.save22;
            this.buttonSave.Image = global::LEA_Browser.Properties.Resources.save22_disabled1;
            this.buttonSave.Location = new System.Drawing.Point(45, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(43, 27);
            this.buttonSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonSave.TabIndex = 9;
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
            this.buttonRefresh.Location = new System.Drawing.Point(129, 4);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(43, 27);
            this.buttonRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonRefresh.TabIndex = 8;
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
            this.buttonAddRow.Location = new System.Drawing.Point(87, 4);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(43, 27);
            this.buttonAddRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonAddRow.TabIndex = 7;
            this.buttonAddRow.TabStop = false;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonImageBoxEditChooser
            // 
            this.buttonImageBoxEditChooser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonImageBoxEditChooser.DisableImage = global::LEA_Browser.Properties.Resources.plus22_disabled11;
            this.buttonImageBoxEditChooser.Enabled = false;
            this.buttonImageBoxEditChooser.EnableImage = global::LEA_Browser.Properties.Resources.plus221;
            this.buttonImageBoxEditChooser.Image = global::LEA_Browser.Properties.Resources.plus22_disabled11;
            this.buttonImageBoxEditChooser.Location = new System.Drawing.Point(531, 4);
            this.buttonImageBoxEditChooser.Name = "buttonImageBoxEditChooser";
            this.buttonImageBoxEditChooser.Size = new System.Drawing.Size(32, 27);
            this.buttonImageBoxEditChooser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonImageBoxEditChooser.TabIndex = 6;
            this.buttonImageBoxEditChooser.TabStop = false;
            this.buttonImageBoxEditChooser.Click += new System.EventHandler(this.buttonImageBoxEditChooser_Click);
            // 
            // buttonImageBoxDelete
            // 
            this.buttonImageBoxDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonImageBoxDelete.DisableImage = global::LEA_Browser.Properties.Resources.trash22_disabled1;
            this.buttonImageBoxDelete.Enabled = false;
            this.buttonImageBoxDelete.EnableImage = global::LEA_Browser.Properties.Resources.trash22;
            this.buttonImageBoxDelete.Image = global::LEA_Browser.Properties.Resources.trash22_disabled1;
            this.buttonImageBoxDelete.Location = new System.Drawing.Point(3, 4);
            this.buttonImageBoxDelete.Name = "buttonImageBoxDelete";
            this.buttonImageBoxDelete.Size = new System.Drawing.Size(43, 27);
            this.buttonImageBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonImageBoxDelete.TabIndex = 4;
            this.buttonImageBoxDelete.TabStop = false;
            this.buttonImageBoxDelete.Click += new System.EventHandler(this.buttonImageBoxDelete_Click);
            // 
            // pictureBoxCastle
            // 
            this.pictureBoxCastle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCastle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxCastle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCastle.Image = global::LEA_Browser.Properties.Resources.castle22;
            this.pictureBoxCastle.Location = new System.Drawing.Point(579, 0);
            this.pictureBoxCastle.Name = "pictureBoxCastle";
            this.pictureBoxCastle.Size = new System.Drawing.Size(38, 34);
            this.pictureBoxCastle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxCastle.TabIndex = 2;
            this.pictureBoxCastle.TabStop = false;
            this.pictureBoxCastle.Click += new System.EventHandler(this.pictureBoxCastle_Click);
            this.pictureBoxCastle.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBoxCastle.MouseLeave += new System.EventHandler(this.pictureBoxCastle_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Investigation";
            // 
            // comboBoxInvestigationChooser
            // 
            this.comboBoxInvestigationChooser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInvestigationChooser.FormattingEnabled = true;
            this.comboBoxInvestigationChooser.Location = new System.Drawing.Point(258, 7);
            this.comboBoxInvestigationChooser.Name = "comboBoxInvestigationChooser";
            this.comboBoxInvestigationChooser.Size = new System.Drawing.Size(267, 21);
            this.comboBoxInvestigationChooser.TabIndex = 0;
            this.comboBoxInvestigationChooser.SelectedIndexChanged += new System.EventHandler(this.comboBoxInvestigationChooser_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewProduct);
            this.panel1.Controls.Add(this.DetailsPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 416);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AllowUserToAddRows = false;
            this.dataGridViewProduct.AllowUserToDeleteRows = false;
            this.dataGridViewProduct.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProduct.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowTemplate.ReadOnly = true;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.ShowCellErrors = false;
            this.dataGridViewProduct.Size = new System.Drawing.Size(619, 354);
            this.dataGridViewProduct.TabIndex = 1;
            this.dataGridViewProduct.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellEndEdit);
            this.dataGridViewProduct.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewProduct_CellValidating_1);
            this.dataGridViewProduct.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellValueChanged);
            this.dataGridViewProduct.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewProduct_CurrentCellDirtyStateChanged);
            this.dataGridViewProduct.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewProduct_DataError);
            this.dataGridViewProduct.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewProduct_EditingControlShowing);
            this.dataGridViewProduct.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_RowEnter);
            this.dataGridViewProduct.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_RowLeave);
            this.dataGridViewProduct.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewProduct_RowPrePaint);
            this.dataGridViewProduct.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewProduct_RowsAdded_1);
            this.dataGridViewProduct.SelectionChanged += new System.EventHandler(this.dataGridViewProduct_SelectionChanged);
            this.dataGridViewProduct.Leave += new System.EventHandler(this.dataGridViewProduct_Leave);
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Controls.Add(this.Panel_CallDetails);
            this.DetailsPanel.Controls.Add(this.Panel_SmsDetails);
            this.DetailsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetailsPanel.Location = new System.Drawing.Point(0, 354);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Size = new System.Drawing.Size(619, 62);
            this.DetailsPanel.TabIndex = 0;
            // 
            // Panel_CallDetails
            // 
            this.Panel_CallDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_CallDetails.Controls.Add(this.panel6);
            this.Panel_CallDetails.Controls.Add(this.panel5);
            this.Panel_CallDetails.Controls.Add(this.panel4);
            this.Panel_CallDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_CallDetails.Location = new System.Drawing.Point(304, 0);
            this.Panel_CallDetails.Name = "Panel_CallDetails";
            this.Panel_CallDetails.Size = new System.Drawing.Size(315, 62);
            this.Panel_CallDetails.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.textBoxFilePath);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(44, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 60);
            this.panel6.TabIndex = 4;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilePath.Location = new System.Drawing.Point(0, 38);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(225, 22);
            this.textBoxFilePath.TabIndex = 3;
            this.textBoxFilePath.TextChanged += new System.EventHandler(this.textBoxFilePath_TextChanged);
            this.textBoxFilePath.Leave += new System.EventHandler(this.textBoxFilePath_Leave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonImageBoxGetFolder);
            this.panel5.Controls.Add(this.buttonPlay);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(269, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 60);
            this.panel5.TabIndex = 2;
            // 
            // buttonImageBoxGetFolder
            // 
            this.buttonImageBoxGetFolder.DisableImage = global::LEA_Browser.Properties.Resources.get_folder22_disabled;
            this.buttonImageBoxGetFolder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonImageBoxGetFolder.Enabled = false;
            this.buttonImageBoxGetFolder.EnableImage = global::LEA_Browser.Properties.Resources.get_folder22;
            this.buttonImageBoxGetFolder.Image = global::LEA_Browser.Properties.Resources.get_folder22_disabled;
            this.buttonImageBoxGetFolder.Location = new System.Drawing.Point(0, 31);
            this.buttonImageBoxGetFolder.Name = "buttonImageBoxGetFolder";
            this.buttonImageBoxGetFolder.Size = new System.Drawing.Size(44, 29);
            this.buttonImageBoxGetFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonImageBoxGetFolder.TabIndex = 1;
            this.buttonImageBoxGetFolder.TabStop = false;
            this.buttonImageBoxGetFolder.Click += new System.EventHandler(this.buttonImageBoxGetFolder_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.DisableImage = global::LEA_Browser.Properties.Resources.play22_disabled;
            this.buttonPlay.EnableImage = global::LEA_Browser.Properties.Resources.play22;
            this.buttonPlay.Image = global::LEA_Browser.Properties.Resources.play22;
            this.buttonPlay.Location = new System.Drawing.Point(3, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(38, 22);
            this.buttonPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(44, 60);
            this.panel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "File ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LEA_Browser.Properties.Resources.call_32;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 37);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Panel_SmsDetails
            // 
            this.Panel_SmsDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_SmsDetails.Controls.Add(this.panel3);
            this.Panel_SmsDetails.Controls.Add(this.panel2);
            this.Panel_SmsDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_SmsDetails.Location = new System.Drawing.Point(0, 0);
            this.Panel_SmsDetails.Name = "Panel_SmsDetails";
            this.Panel_SmsDetails.Size = new System.Drawing.Size(304, 62);
            this.Panel_SmsDetails.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxSMSText);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(44, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 60);
            this.panel3.TabIndex = 2;
            // 
            // textBoxSMSText
            // 
            this.textBoxSMSText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSMSText.Enabled = false;
            this.textBoxSMSText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSMSText.Location = new System.Drawing.Point(0, 0);
            this.textBoxSMSText.Multiline = true;
            this.textBoxSMSText.Name = "textBoxSMSText";
            this.textBoxSMSText.Size = new System.Drawing.Size(258, 60);
            this.textBoxSMSText.TabIndex = 0;
            this.textBoxSMSText.TextChanged += new System.EventHandler(this.textBoxSMSText_TextChanged);
            this.textBoxSMSText.Leave += new System.EventHandler(this.textBoxSMSText_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 60);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Text";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LEA_Browser.Properties.Resources.sms_32;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 39);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorkerChooser
            // 
            this.backgroundWorkerChooser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChooser_DoWork);
            this.backgroundWorkerChooser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerChooser_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.MinimumSize = new System.Drawing.Size(633, 39);
            this.Name = "MainForm";
            this.Text = "LEA (Law Enforcement Agency) Browser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxEditChooser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCastle)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.DetailsPanel.ResumeLayout(false);
            this.Panel_CallDetails.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonImageBoxGetFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Panel_SmsDetails.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInvestigationChooser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Panel DetailsPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChooser;
        private System.Windows.Forms.PictureBox pictureBoxCastle;
        private System.Windows.Forms.Panel Panel_CallDetails;
        private System.Windows.Forms.Panel Panel_SmsDetails;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LEA_Browser.ButtonImageBox buttonImageBoxDelete;
        private LEA_Browser.ButtonImageBox buttonImageBoxEditChooser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxSMSText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private LEA_Browser.ButtonImageBox buttonPlay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private LEA_Browser.ButtonImageBox buttonImageBoxGetFolder;
        private System.Windows.Forms.Label label4;
        private LEA_Browser.ButtonImageBox buttonAddRow;
        private LEA_Browser.ButtonImageBox buttonRefresh;
        private LEA_Browser.ButtonImageBox buttonSave;
        //private LEA_Browser.ButtonImageBox buttonImageBox2;
        //private LEA_Browser.ButtonImageBox buttonImageBox1;
        //private LEA_Browser.ButtonImageBox buttonImageBox3;
    }
}

