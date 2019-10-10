using System;

namespace FWUpdate
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.setUrlBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.SignBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ip Stampante";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(156, 15);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(203, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "129.20.37.5";
            this.txtIP.TextChanged += new System.EventHandler(this.TxtIP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Url New Firmware";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(156, 104);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(203, 20);
            this.txtURL.TabIndex = 3;
            this.txtURL.Text = "http://129.20.37.39/PRT.mot";
            // 
            // setUrlBtn
            // 
            this.setUrlBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.setUrlBtn.Location = new System.Drawing.Point(375, 103);
            this.setUrlBtn.Name = "setUrlBtn";
            this.setUrlBtn.Size = new System.Drawing.Size(62, 20);
            this.setUrlBtn.TabIndex = 4;
            this.setUrlBtn.Text = "SET";
            this.setUrlBtn.UseVisualStyleBackColor = true;
            this.setUrlBtn.Click += new System.EventHandler(this.SetUrlBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Url New Signature";
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(156, 147);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(203, 20);
            this.txtSign.TabIndex = 6;
            this.txtSign.Text = "http://129.20.37.39/PRT.sig";
            // 
            // SignBtn
            // 
            this.SignBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SignBtn.Location = new System.Drawing.Point(375, 147);
            this.SignBtn.Name = "SignBtn";
            this.SignBtn.Size = new System.Drawing.Size(62, 20);
            this.SignBtn.TabIndex = 7;
            this.SignBtn.Text = "SET";
            this.SignBtn.UseVisualStyleBackColor = true;
            this.SignBtn.Click += new System.EventHandler(this.SignBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateBtn.Location = new System.Drawing.Point(262, 186);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(97, 90);
            this.UpdateBtn.TabIndex = 8;
            this.UpdateBtn.Text = "UPDATE";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(443, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(196, 152);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FWUpdate.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(467, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 73);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(156, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(203, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(24, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tecnico";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(651, 5);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 0);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(198, 307);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 15);
            this.progressBar1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 325);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.SignBtn);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setUrlBtn);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FwUpdate 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button setUrlBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.Button SignBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

