using System;

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
            this.cbSignalType = new System.Windows.Forms.ComboBox();
            this.btnAddToPolysignal = new System.Windows.Forms.Button();
            this.lblPolysignalCount = new System.Windows.Forms.Label();
            this.lblPolysignalCountValue = new System.Windows.Forms.Label();
            this.btnClearPolysignal = new System.Windows.Forms.Button();
            this.btnRecordPolysignal = new System.Windows.Forms.Button();
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
            this.edtAmplitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
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
            // cbSignalType
            // 
            this.cbSignalType.DataSource = Enum.GetValues(typeof(SignalType));
            this.cbSignalType.FormattingEnabled = true;
            this.cbSignalType.Location = new System.Drawing.Point(496, 29);
            this.cbSignalType.Name = "cbSignalType";
            this.cbSignalType.Size = new System.Drawing.Size(121, 24);
            this.cbSignalType.TabIndex = 5;
            // 
            // btnAddToPolysignal
            // 
            this.btnAddToPolysignal.Location = new System.Drawing.Point(496, 197);
            this.btnAddToPolysignal.Name = "btnAddToPolysignal";
            this.btnAddToPolysignal.Size = new System.Drawing.Size(121, 46);
            this.btnAddToPolysignal.TabIndex = 6;
            this.btnAddToPolysignal.Text = "Add to polysignal";
            this.btnAddToPolysignal.UseVisualStyleBackColor = true;
            this.btnAddToPolysignal.Click += new System.EventHandler(this.btnAddToPolysignal_Click);
            // 
            // lblPolysignalCount
            // 
            this.lblPolysignalCount.AutoSize = true;
            this.lblPolysignalCount.Location = new System.Drawing.Point(493, 268);
            this.lblPolysignalCount.Name = "lblPolysignalCount";
            this.lblPolysignalCount.Size = new System.Drawing.Size(188, 17);
            this.lblPolysignalCount.TabIndex = 7;
            this.lblPolysignalCount.Text = "polysignal component count:";
            // 
            // lblPolysignalCountValue
            // 
            this.lblPolysignalCountValue.AutoSize = true;
            this.lblPolysignalCountValue.Location = new System.Drawing.Point(700, 268);
            this.lblPolysignalCountValue.Name = "lblPolysignalCountValue";
            this.lblPolysignalCountValue.Size = new System.Drawing.Size(16, 17);
            this.lblPolysignalCountValue.TabIndex = 8;
            this.lblPolysignalCountValue.Text = "0";
            // 
            // btnClearPolysignal
            // 
            this.btnClearPolysignal.Location = new System.Drawing.Point(645, 197);
            this.btnClearPolysignal.Name = "btnClearPolysignal";
            this.btnClearPolysignal.Size = new System.Drawing.Size(102, 46);
            this.btnClearPolysignal.TabIndex = 9;
            this.btnClearPolysignal.Text = "Clear polysignal";
            this.btnClearPolysignal.UseVisualStyleBackColor = true;
            this.btnClearPolysignal.Click += new System.EventHandler(this.btnClearPolysignal_Click);
            // 
            // btnRecordPolysignal
            // 
            this.btnRecordPolysignal.Location = new System.Drawing.Point(496, 304);
            this.btnRecordPolysignal.Name = "btnRecordPolysignal";
            this.btnRecordPolysignal.Size = new System.Drawing.Size(247, 49);
            this.btnRecordPolysignal.TabIndex = 10;
            this.btnRecordPolysignal.Text = "Record polysignal";
            this.btnRecordPolysignal.UseVisualStyleBackColor = true;
            this.btnRecordPolysignal.Click += new System.EventHandler(this.btnRecordPolysignal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRecordPolysignal);
            this.Controls.Add(this.btnClearPolysignal);
            this.Controls.Add(this.lblPolysignalCountValue);
            this.Controls.Add(this.lblPolysignalCount);
            this.Controls.Add(this.btnAddToPolysignal);
            this.Controls.Add(this.cbSignalType);
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
        private System.Windows.Forms.ComboBox cbSignalType;
        private System.Windows.Forms.Button btnAddToPolysignal;
        private System.Windows.Forms.Label lblPolysignalCount;
        private System.Windows.Forms.Label lblPolysignalCountValue;
        private System.Windows.Forms.Button btnClearPolysignal;
        private System.Windows.Forms.Button btnRecordPolysignal;
    }
}

