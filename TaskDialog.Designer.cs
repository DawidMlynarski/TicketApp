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
            btnOK.Location = new Point(37, 401);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(162, 401);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(673, 401);
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
            // TaskDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}