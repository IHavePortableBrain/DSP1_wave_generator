namespace lab1
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
            this.btnRecord = new System.Windows.Forms.Button();
            this.edtFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.edtAmplitude = new System.Windows.Forms.NumericUpDown();
            this.lblAmplitude = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmplitude)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(623, 29);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(124, 43);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // edtFrequency
            // 
            this.edtFrequency.BackColor = System.Drawing.Color.Aqua;
            this.edtFrequency.Location = new System.Drawing.Point(623, 103);
            this.edtFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.edtFrequency.Name = "edtFrequency";
            this.edtFrequency.Size = new System.Drawing.Size(120, 22);
            this.edtFrequency.TabIndex = 1;
            this.edtFrequency.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(543, 105);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(79, 17);
            this.lblFrequency.TabIndex = 2;
            this.lblFrequency.Text = "Frequency:";
            // 
            // edtAmplitude
            // 
            this.edtAmplitude.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAmplitude.DecimalPlaces = 2;
            this.edtAmplitude.Location = new System.Drawing.Point(623, 150);
            this.edtAmplitude.Name = "edtAmplitude";
            this.edtAmplitude.Size = new System.Drawing.Size(120, 22);
            this.edtAmplitude.TabIndex = 3;
            this.edtAmplitude.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // lblAmplitude
            // 
            this.lblAmplitude.AutoSize = true;
            this.lblAmplitude.Location = new System.Drawing.Point(543, 152);
            this.lblAmplitude.Name = "lblAmplitude";
            this.lblAmplitude.Size = new System.Drawing.Size(74, 17);
            this.lblAmplitude.TabIndex = 4;
            this.lblAmplitude.Text = "Amplitude:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAmplitude);
            this.Controls.Add(this.edtAmplitude);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.edtFrequency);
            this.Controls.Add(this.btnRecord);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.edtFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmplitude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.NumericUpDown edtFrequency;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.NumericUpDown edtAmplitude;
        private System.Windows.Forms.Label lblAmplitude;
    }
}

