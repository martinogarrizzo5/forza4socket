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
            this.grb_Grid = new System.Windows.Forms.GroupBox();
            this.grb_Impostazioni = new System.Windows.Forms.GroupBox();
            this.btn_Server = new System.Windows.Forms.Button();
            this.btn_Client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grb_Grid.SuspendLayout();
            this.grb_Impostazioni.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_Grid
            // 
            this.grb_Grid.Controls.Add(this.grb_Impostazioni);
            this.grb_Grid.Location = new System.Drawing.Point(70, 12);
            this.grb_Grid.Name = "grb_Grid";
            this.grb_Grid.Size = new System.Drawing.Size(786, 539);
            this.grb_Grid.TabIndex = 0;
            this.grb_Grid.TabStop = false;
            this.grb_Grid.Text = "Grid";
            // 
            // grb_Impostazioni
            // 
            this.grb_Impostazioni.Controls.Add(this.label2);
            this.grb_Impostazioni.Controls.Add(this.label1);
            this.grb_Impostazioni.Controls.Add(this.btn_Client);
            this.grb_Impostazioni.Controls.Add(this.btn_Server);
            this.grb_Impostazioni.Location = new System.Drawing.Point(35, 192);
            this.grb_Impostazioni.Name = "grb_Impostazioni";
            this.grb_Impostazioni.Size = new System.Drawing.Size(715, 323);
            this.grb_Impostazioni.TabIndex = 1;
            this.grb_Impostazioni.TabStop = false;
            this.grb_Impostazioni.Text = "Impostazioni e Regole";
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(458, 68);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(75, 26);
            this.btn_Server.TabIndex = 0;
            this.btn_Server.Text = "SERVER";
            this.btn_Server.UseVisualStyleBackColor = true;
            // 
            // btn_Client
            // 
            this.btn_Client.Location = new System.Drawing.Point(595, 68);
            this.btn_Client.Name = "btn_Client";
            this.btn_Client.Size = new System.Drawing.Size(75, 26);
            this.btn_Client.TabIndex = 1;
            this.btn_Client.Text = "CLIENT";
            this.btn_Client.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scegliere tra le due opzioni :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 606);
            this.Controls.Add(this.grb_Grid);
            this.Name = "Form1";
            this.Text = "Forza quattro";
            this.grb_Grid.ResumeLayout(false);
            this.grb_Impostazioni.ResumeLayout(false);
            this.grb_Impostazioni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grb_Grid;
        private GroupBox grb_Impostazioni;
        private Label label2;
        private Label label1;
        private Button btn_Client;
        private Button btn_Server;
    }
}