using System.ComponentModel;

namespace TicketApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            backgroundWorker1 = new BackgroundWorker();
            AddTaskButton = new Button();
            lblTasksKind = new Label();
            lblSearchID = new Label();
            txtSearchId = new TextBox();
            btnSearchId = new Button();
            lblSearchContent = new Label();
            txtSearchContent = new TextBox();
            btnSearchContent = new Button();
            btnHome = new Button();
            cmbPriorityFilter = new ComboBox();
            cmbConsultantFilter = new ComboBox();
            cmbStatusFilter = new ComboBox();
            btnFilter = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            flowLayoutPanel1.Location = new Point(208, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1155, 453);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // AddTaskButton
            // 
            AddTaskButton.Location = new Point(52, 72);
            AddTaskButton.Name = "AddTaskButton";
            AddTaskButton.Size = new Size(94, 29);
            AddTaskButton.TabIndex = 1;
            AddTaskButton.Text = "Add task";
            AddTaskButton.UseVisualStyleBackColor = true;
            AddTaskButton.Click += AddTaskButton_Click;
            // 
            // lblTasksKind
            // 
            lblTasksKind.AutoSize = true;
            lblTasksKind.Location = new Point(205, 15);
            lblTasksKind.Name = "lblTasksKind";
            lblTasksKind.Size = new Size(99, 20);
            lblTasksKind.TabIndex = 2;
            lblTasksKind.Text = "Aktywne taski";
            // 
            // lblSearchID
            // 
            lblSearchID.AutoSize = true;
            lblSearchID.Location = new Point(52, 132);
            lblSearchID.Name = "lblSearchID";
            lblSearchID.Size = new Size(89, 20);
            lblSearchID.TabIndex = 3;
            lblSearchID.Text = "Wyszukaj ID";
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new Point(38, 155);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(125, 27);
            txtSearchId.TabIndex = 4;
            // 
            // btnSearchId
            // 
            btnSearchId.Location = new Point(52, 188);
            btnSearchId.Name = "btnSearchId";
            btnSearchId.Size = new Size(94, 29);
            btnSearchId.TabIndex = 5;
            btnSearchId.Text = "Szukaj";
            btnSearchId.UseVisualStyleBackColor = true;
            btnSearchId.Click += btnSearchId_Click;
            // 
            // lblSearchContent
            // 
            lblSearchContent.AutoSize = true;
            lblSearchContent.Location = new Point(39, 263);
            lblSearchContent.Name = "lblSearchContent";
            lblSearchContent.Size = new Size(107, 20);
            lblSearchContent.TabIndex = 6;
            lblSearchContent.Text = "Wyszukaj frazę";
            // 
            // txtSearchContent
            // 
            txtSearchContent.Location = new Point(38, 286);
            txtSearchContent.Name = "txtSearchContent";
            txtSearchContent.Size = new Size(125, 27);
            txtSearchContent.TabIndex = 7;
            // 
            // btnSearchContent
            // 
            btnSearchContent.Location = new Point(52, 319);
            btnSearchContent.Name = "btnSearchContent";
            btnSearchContent.Size = new Size(94, 29);
            btnSearchContent.TabIndex = 8;
            btnSearchContent.Text = "Szukaj";
            btnSearchContent.UseVisualStyleBackColor = true;
            btnSearchContent.Click += btnSearchContent_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(52, 6);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(94, 29);
            btnHome.TabIndex = 9;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // cmbPriorityFilter
            // 
            cmbPriorityFilter.FormattingEnabled = true;
            cmbPriorityFilter.Items.AddRange(new object[] { "High-SLA", "Low-SLA", "Normal-SLA" });
            cmbPriorityFilter.Location = new Point(374, 12);
            cmbPriorityFilter.Name = "cmbPriorityFilter";
            cmbPriorityFilter.Size = new Size(151, 28);
            cmbPriorityFilter.TabIndex = 10;
            // 
            // cmbConsultantFilter
            // 
            cmbConsultantFilter.FormattingEnabled = true;
            cmbConsultantFilter.Items.AddRange(new object[] { "Dawid Młynarski", "Artur Karwatka" });
            cmbConsultantFilter.Location = new Point(531, 12);
            cmbConsultantFilter.Name = "cmbConsultantFilter";
            cmbConsultantFilter.Size = new Size(151, 28);
            cmbConsultantFilter.TabIndex = 11;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "Aktywne", "Zamknięte" });
            cmbStatusFilter.Location = new Point(688, 12);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(151, 28);
            cmbStatusFilter.TabIndex = 12;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(845, 12);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 13;
            btnFilter.Text = "Filtruj";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnFilter);
            Controls.Add(cmbStatusFilter);
            Controls.Add(cmbConsultantFilter);
            Controls.Add(cmbPriorityFilter);
            Controls.Add(btnHome);
            Controls.Add(btnSearchContent);
            Controls.Add(txtSearchContent);
            Controls.Add(lblSearchContent);
            Controls.Add(btnSearchId);
            Controls.Add(txtSearchId);
            Controls.Add(lblSearchID);
            Controls.Add(lblTasksKind);
            Controls.Add(AddTaskButton);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button AddTaskButton;
        private Label lblTasksKind;
        private Label lblSearchID;
        private TextBox txtSearchId;
        private Button btnSearchId;
        private Label lblSearchContent;
        private TextBox txtSearchContent;
        private Button btnSearchContent;
        private Button btnHome;
        private ComboBox cmbPriorityFilter;
        private ComboBox cmbConsultantFilter;
        private ComboBox cmbStatusFilter;
        private Button btnFilter;
    }
}
