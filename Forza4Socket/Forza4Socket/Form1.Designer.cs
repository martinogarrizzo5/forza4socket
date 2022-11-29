namespace Forza4Socket
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
            this.clientBtn = new System.Windows.Forms.Button();
            this.serverBtn = new System.Windows.Forms.Button();
            this.sendDataBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientBtn
            // 
            this.clientBtn.Location = new System.Drawing.Point(125, 136);
            this.clientBtn.Name = "clientBtn";
            this.clientBtn.Size = new System.Drawing.Size(94, 29);
            this.clientBtn.TabIndex = 0;
            this.clientBtn.Text = "Client";
            this.clientBtn.UseVisualStyleBackColor = true;
            this.clientBtn.Click += new System.EventHandler(this.clientBtn_Click);
            // 
            // serverBtn
            // 
            this.serverBtn.Location = new System.Drawing.Point(251, 136);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(94, 29);
            this.serverBtn.TabIndex = 1;
            this.serverBtn.Text = "Server";
            this.serverBtn.UseVisualStyleBackColor = true;
            this.serverBtn.Click += new System.EventHandler(this.serverBtn_Click);
            // 
            // sendDataBtn
            // 
            this.sendDataBtn.Location = new System.Drawing.Point(125, 186);
            this.sendDataBtn.Name = "sendDataBtn";
            this.sendDataBtn.Size = new System.Drawing.Size(220, 36);
            this.sendDataBtn.TabIndex = 2;
            this.sendDataBtn.Text = "Send Data";
            this.sendDataBtn.UseVisualStyleBackColor = true;
            this.sendDataBtn.Click += new System.EventHandler(this.sendDataBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendDataBtn);
            this.Controls.Add(this.serverBtn);
            this.Controls.Add(this.clientBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button clientBtn;
        private Button serverBtn;
        private Button sendDataBtn;
        private Label label1;
    }
}