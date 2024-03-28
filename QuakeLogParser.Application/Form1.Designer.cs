using QuakeLogParser.Domain.Services.Interface;

namespace QuakeLogParser.App
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
            btnExit = new Button();
            btnMatchReport = new Button();
            btnPreviewLog = new Button();
            txtResult = new TextBox();
            label1 = new Label();
            chkWithWeapon = new CheckBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(935, 607);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnMatchReport
            // 
            btnMatchReport.Location = new Point(587, 607);
            btnMatchReport.Name = "btnMatchReport";
            btnMatchReport.Size = new Size(111, 23);
            btnMatchReport.TabIndex = 2;
            btnMatchReport.Text = "Match Report";
            btnMatchReport.UseVisualStyleBackColor = true;
            btnMatchReport.Click += btnMatchReport_Click;
            // 
            // btnPreviewLog
            // 
            btnPreviewLog.Location = new Point(470, 607);
            btnPreviewLog.Name = "btnPreviewLog";
            btnPreviewLog.Size = new Size(111, 23);
            btnPreviewLog.TabIndex = 1;
            btnPreviewLog.Text = "Priview Log";
            btnPreviewLog.UseVisualStyleBackColor = true;
            btnPreviewLog.Click += btnPreviewLog_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(12, 21);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Both;
            txtResult.Size = new Size(998, 580);
            txtResult.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 3);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 5;
            label1.Text = "Report Preview";
            // 
            // chkWithWeapon
            // 
            chkWithWeapon.AutoSize = true;
            chkWithWeapon.Location = new Point(714, 610);
            chkWithWeapon.Name = "chkWithWeapon";
            chkWithWeapon.Size = new Size(98, 19);
            chkWithWeapon.TabIndex = 3;
            chkWithWeapon.Text = "With Weapon";
            chkWithWeapon.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(818, 607);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save Report";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 642);
            Controls.Add(btnSave);
            Controls.Add(chkWithWeapon);
            Controls.Add(label1);
            Controls.Add(txtResult);
            Controls.Add(btnPreviewLog);
            Controls.Add(btnMatchReport);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Quake Log Parser";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Button btnMatchReport;
        private Button btnPreviewLog;
        private TextBox txtResult;
        private Label label1;
        private CheckBox chkWithWeapon;
        private Button btnSave;
    }

}
