namespace Earnings
{
    partial class Form1
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
            this.txtDateStart = new System.Windows.Forms.DateTimePicker();
            this.txtDateEnd = new System.Windows.Forms.DateTimePicker();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogActivity = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtDateStart
            // 
            this.txtDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateStart.Location = new System.Drawing.Point(79, 39);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(131, 20);
            this.txtDateStart.TabIndex = 0;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateEnd.Location = new System.Drawing.Point(79, 79);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(131, 20);
            this.txtDateEnd.TabIndex = 1;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(67, 180);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 3;
            this.BtnSubmit.Text = "Start";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date End";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(79, 122);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(131, 43);
            this.txtFileLocation.TabIndex = 6;
            this.txtFileLocation.Text = "D:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Location";
            // 
            // txtLogActivity
            // 
            this.txtLogActivity.Location = new System.Drawing.Point(216, 3);
            this.txtLogActivity.Name = "txtLogActivity";
            this.txtLogActivity.Size = new System.Drawing.Size(269, 364);
            this.txtLogActivity.TabIndex = 8;
            this.txtLogActivity.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 257);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            //this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            //this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 366);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtLogActivity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.txtDateEnd);
            this.Controls.Add(this.txtDateStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtDateStart;
        private System.Windows.Forms.DateTimePicker txtDateEnd;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtFileLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtLogActivity;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

