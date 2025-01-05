namespace TicketApp
{
    partial class TaskDialog
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            btnClose = new Button();
            cmbPriority = new ComboBox();
            lblPriority = new Label();
            cmbConsultant = new ComboBox();
            lblConsultant = new Label();
            btnAddEntry = new Button();
            rtbEntries = new RichTextBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(40, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tytuł";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 32);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(776, 27);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(16, 73);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(39, 20);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Opis";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 96);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(776, 110);
            txtDescription.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(398, 247);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(521, 247);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(636, 247);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(115, 29);
            btnClose.TabIndex = 6;
            btnClose.Text = "Zamknij Taska";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Normal-SLA", "High-SLA", "Low-SLA" });
            cmbPriority.Location = new Point(12, 247);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(151, 28);
            cmbPriority.TabIndex = 7;
            cmbPriority.Text = "Normal-SLA";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(15, 220);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(103, 20);
            lblPriority.TabIndex = 8;
            lblPriority.Text = "Priorytet taska";
            // 
            // cmbConsultant
            // 
            cmbConsultant.FormattingEnabled = true;
            cmbConsultant.Items.AddRange(new object[] { "Dawid Młynarski", "Artur Karwatka" });
            cmbConsultant.Location = new Point(212, 247);
            cmbConsultant.Name = "cmbConsultant";
            cmbConsultant.Size = new Size(151, 28);
            cmbConsultant.TabIndex = 9;
            cmbConsultant.Text = "Dawid Młynarski";
            // 
            // lblConsultant
            // 
            lblConsultant.AutoSize = true;
            lblConsultant.Location = new Point(217, 218);
            lblConsultant.Name = "lblConsultant";
            lblConsultant.Size = new Size(79, 20);
            lblConsultant.TabIndex = 10;
            lblConsultant.Text = "Konsultant";
            lblConsultant.Click += label1_Click;
            // 
            // btnAddEntry
            // 
            btnAddEntry.Location = new Point(12, 316);
            btnAddEntry.Name = "btnAddEntry";
            btnAddEntry.Size = new Size(94, 29);
            btnAddEntry.TabIndex = 12;
            btnAddEntry.Text = "Dodaj wpis";
            btnAddEntry.UseVisualStyleBackColor = true;
            btnAddEntry.Click += btnAddEntry_Click;
            // 
            // rtbEntries
            // 
            rtbEntries.Location = new Point(12, 373);
            rtbEntries.Name = "rtbEntries";
            rtbEntries.Size = new Size(776, 622);
            rtbEntries.TabIndex = 11;
            rtbEntries.Text = "";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(173, 317);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(190, 28);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Status: Task Aktywny";
            // 
            // TaskDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(lblStatus);
            Controls.Add(btnAddEntry);
            Controls.Add(rtbEntries);
            Controls.Add(lblConsultant);
            Controls.Add(cmbConsultant);
            Controls.Add(lblPriority);
            Controls.Add(cmbPriority);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Name = "TaskDialog";
            Text = "TaskDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnOK;
        private Button btnCancel;
        private Button btnClose;
        private ComboBox cmbPriority;
        private Label lblPriority;
        private ComboBox cmbConsultant;
        private Label lblConsultant;
        private Button btnAddEntry;
        private RichTextBox rtbEntries;
        private Label lblStatus;
    }
}