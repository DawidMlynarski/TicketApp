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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
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
    }
}
