namespace Forza4Socket
{
    partial class frm_Forza4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Forza4));
            this.lbl_Regole = new System.Windows.Forms.Label();
            this.btn_Client = new System.Windows.Forms.Button();
            this.btn_Server = new System.Windows.Forms.Button();
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.lbl_Titolo2 = new System.Windows.Forms.Label();
            this.grb_RegoleEAvvio = new System.Windows.Forms.GroupBox();
            this.grb_Forza4 = new System.Windows.Forms.GroupBox();
            this.btn_Rigioca = new System.Windows.Forms.Button();
            this.lbl_Vincitore = new System.Windows.Forms.Label();
            this.lbl_Vincita = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grb_RegoleEAvvio.SuspendLayout();
            this.grb_Forza4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Regole
            // 
            this.lbl_Regole.AutoSize = true;
            this.lbl_Regole.Location = new System.Drawing.Point(58, 48);
            this.lbl_Regole.Name = "lbl_Regole";
            this.lbl_Regole.Size = new System.Drawing.Size(508, 105);
            this.lbl_Regole.TabIndex = 0;
            this.lbl_Regole.Text = resources.GetString("lbl_Regole.Text");
            // 
            // btn_Client
            // 
            this.btn_Client.Location = new System.Drawing.Point(184, 244);
            this.btn_Client.Name = "btn_Client";
            this.btn_Client.Size = new System.Drawing.Size(75, 23);
            this.btn_Client.TabIndex = 1;
            this.btn_Client.Text = "CLIENT";
            this.btn_Client.UseVisualStyleBackColor = true;
            this.btn_Client.Click += new System.EventHandler(this.btn_Client_Click);
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(349, 244);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(75, 23);
            this.btn_Server.TabIndex = 2;
            this.btn_Server.Text = "SERVER";
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // lbl_Titolo
            // 
            this.lbl_Titolo.AutoSize = true;
            this.lbl_Titolo.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Titolo.ForeColor = System.Drawing.Color.Red;
            this.lbl_Titolo.Location = new System.Drawing.Point(252, 17);
            this.lbl_Titolo.Name = "lbl_Titolo";
            this.lbl_Titolo.Size = new System.Drawing.Size(97, 17);
            this.lbl_Titolo.TabIndex = 3;
            this.lbl_Titolo.Text = "REGOLE DEL GIOCO";
            // 
            // lbl_Titolo2
            // 
            this.lbl_Titolo2.AutoSize = true;
            this.lbl_Titolo2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Titolo2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Titolo2.Location = new System.Drawing.Point(184, 190);
            this.lbl_Titolo2.Name = "lbl_Titolo2";
            this.lbl_Titolo2.Size = new System.Drawing.Size(240, 17);
            this.lbl_Titolo2.TabIndex = 4;
            this.lbl_Titolo2.Text = "SCIGLIERE COME SI VUOLE GIOCARE LA PARTITA";
            // 
            // grb_RegoleEAvvio
            // 
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Regole);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo2);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Client);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Server);
            this.grb_RegoleEAvvio.Location = new System.Drawing.Point(12, 22);
            this.grb_RegoleEAvvio.Name = "grb_RegoleEAvvio";
            this.grb_RegoleEAvvio.Size = new System.Drawing.Size(627, 305);
            this.grb_RegoleEAvvio.TabIndex = 5;
            this.grb_RegoleEAvvio.TabStop = false;
            this.grb_RegoleEAvvio.Text = "REGOLE E AVVIO";
            // 
            // grb_Forza4
            // 
            this.grb_Forza4.Controls.Add(this.btn_Rigioca);
            this.grb_Forza4.Controls.Add(this.lbl_Vincitore);
            this.grb_Forza4.Controls.Add(this.lbl_Vincita);
            this.grb_Forza4.Controls.Add(this.dataGridView1);
            this.grb_Forza4.Location = new System.Drawing.Point(645, 22);
            this.grb_Forza4.Name = "grb_Forza4";
            this.grb_Forza4.Size = new System.Drawing.Size(713, 536);
            this.grb_Forza4.TabIndex = 6;
            this.grb_Forza4.TabStop = false;
            this.grb_Forza4.Text = "FORZA 4";
            // 
            // btn_Rigioca
            // 
            this.btn_Rigioca.Location = new System.Drawing.Point(573, 130);
            this.btn_Rigioca.Name = "btn_Rigioca";
            this.btn_Rigioca.Size = new System.Drawing.Size(75, 23);
            this.btn_Rigioca.TabIndex = 8;
            this.btn_Rigioca.Text = "RIGIOCA";
            this.btn_Rigioca.UseVisualStyleBackColor = true;
            // 
            // lbl_Vincitore
            // 
            this.lbl_Vincitore.AutoSize = true;
            this.lbl_Vincitore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_Vincitore.Location = new System.Drawing.Point(590, 48);
            this.lbl_Vincitore.Name = "lbl_Vincitore";
            this.lbl_Vincitore.Size = new System.Drawing.Size(0, 15);
            this.lbl_Vincitore.TabIndex = 7;
            // 
            // lbl_Vincita
            // 
            this.lbl_Vincita.AutoSize = true;
            this.lbl_Vincita.Location = new System.Drawing.Point(517, 48);
            this.lbl_Vincita.Name = "lbl_Vincita";
            this.lbl_Vincita.Size = new System.Drawing.Size(67, 15);
            this.lbl_Vincita.TabIndex = 6;
            this.lbl_Vincita.Text = "VINCITORE:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(487, 417);
            this.dataGridView1.TabIndex = 1;
            // 
            // frm_Forza4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 576);
            this.Controls.Add(this.grb_Forza4);
            this.Controls.Add(this.grb_RegoleEAvvio);
            this.Name = "frm_Forza4";
            this.Text = "FORZA 4";
            this.Load += new System.EventHandler(this.Frm_RegoleEAvvio_Load);
            this.grb_RegoleEAvvio.ResumeLayout(false);
            this.grb_RegoleEAvvio.PerformLayout();
            this.grb_Forza4.ResumeLayout(false);
            this.grb_Forza4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbl_Regole;
        private Button btn_Client;
        private Button btn_Server;
        private Label lbl_Titolo;
        private Label lbl_Titolo2;
        private GroupBox grb_RegoleEAvvio;
        private GroupBox grb_Forza4;
        private DataGridView dataGridView1;
        private Label lbl_Vincitore;
        private Label lbl_Vincita;
        private Button btn_Rigioca;
    }
}