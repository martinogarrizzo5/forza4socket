namespace Forza4Socket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_Regole = new System.Windows.Forms.Label();
            this.btn_Client = new System.Windows.Forms.Button();
            this.btn_Server = new System.Windows.Forms.Button();
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.lbl_Titolo2 = new System.Windows.Forms.Label();
            this.grb_RegoleEAvvio = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lstHosts = new System.Windows.Forms.ListBox();
            this.grb_Forza4 = new System.Windows.Forms.GroupBox();
            this.lblTurnPlayer = new System.Windows.Forms.Label();
            this.playAgainBtn = new System.Windows.Forms.Button();
            this.lbl_Vincitore = new System.Windows.Forms.Label();
            this.gameStatusLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchingLbl = new System.Windows.Forms.Label();
            this.grb_RegoleEAvvio.SuspendLayout();
            this.grb_Forza4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Regole
            // 
            this.lbl_Regole.AutoSize = true;
            this.lbl_Regole.Location = new System.Drawing.Point(66, 64);
            this.lbl_Regole.Name = "lbl_Regole";
            this.lbl_Regole.Size = new System.Drawing.Size(644, 140);
            this.lbl_Regole.TabIndex = 0;
            this.lbl_Regole.Text = resources.GetString("lbl_Regole.Text");
            // 
            // btn_Client
            // 
            this.btn_Client.Location = new System.Drawing.Point(585, 509);
            this.btn_Client.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Client.Name = "btn_Client";
            this.btn_Client.Size = new System.Drawing.Size(86, 31);
            this.btn_Client.TabIndex = 1;
            this.btn_Client.Text = "Connect";
            this.btn_Client.UseVisualStyleBackColor = true;
            this.btn_Client.Click += new System.EventHandler(this.clientBtn_Click);
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(76, 416);
            this.btn_Server.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(86, 31);
            this.btn_Server.TabIndex = 2;
            this.btn_Server.Text = "SERVER";
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Click += new System.EventHandler(this.serverBtn_Click);
            // 
            // lbl_Titolo
            // 
            this.lbl_Titolo.AutoSize = true;
            this.lbl_Titolo.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Titolo.ForeColor = System.Drawing.Color.Red;
            this.lbl_Titolo.Location = new System.Drawing.Point(288, 23);
            this.lbl_Titolo.Name = "lbl_Titolo";
            this.lbl_Titolo.Size = new System.Drawing.Size(126, 21);
            this.lbl_Titolo.TabIndex = 3;
            this.lbl_Titolo.Text = "REGOLE DEL GIOCO";
            // 
            // lbl_Titolo2
            // 
            this.lbl_Titolo2.AutoSize = true;
            this.lbl_Titolo2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Titolo2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Titolo2.Location = new System.Drawing.Point(205, 253);
            this.lbl_Titolo2.Name = "lbl_Titolo2";
            this.lbl_Titolo2.Size = new System.Drawing.Size(313, 21);
            this.lbl_Titolo2.TabIndex = 4;
            this.lbl_Titolo2.Text = "SCIGLIERE COME SI VUOLE GIOCARE LA PARTITA";
            // 
            // grb_RegoleEAvvio
            // 
            this.grb_RegoleEAvvio.Controls.Add(this.searchingLbl);
            this.grb_RegoleEAvvio.Controls.Add(this.label35);
            this.grb_RegoleEAvvio.Controls.Add(this.usernameTextBox);
            this.grb_RegoleEAvvio.Controls.Add(this.label2);
            this.grb_RegoleEAvvio.Controls.Add(this.label1);
            this.grb_RegoleEAvvio.Controls.Add(this.button1);
            this.grb_RegoleEAvvio.Controls.Add(this.lstHosts);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Regole);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo2);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Client);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Server);
            this.grb_RegoleEAvvio.Location = new System.Drawing.Point(14, 29);
            this.grb_RegoleEAvvio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grb_RegoleEAvvio.Name = "grb_RegoleEAvvio";
            this.grb_RegoleEAvvio.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grb_RegoleEAvvio.Size = new System.Drawing.Size(717, 715);
            this.grb_RegoleEAvvio.TabIndex = 5;
            this.grb_RegoleEAvvio.TabStop = false;
            this.grb_RegoleEAvvio.Text = "REGOLE E AVVIO";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(76, 289);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(75, 20);
            this.label35.TabIndex = 10;
            this.label35.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(76, 321);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(259, 27);
            this.usernameTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Join A Game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host A Game";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 459);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Discover";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.on_DiscoverButtonClick);
            // 
            // lstHosts
            // 
            this.lstHosts.FormattingEnabled = true;
            this.lstHosts.ItemHeight = 20;
            this.lstHosts.Location = new System.Drawing.Point(205, 416);
            this.lstHosts.Name = "lstHosts";
            this.lstHosts.Size = new System.Drawing.Size(348, 184);
            this.lstHosts.TabIndex = 5;
            // 
            // grb_Forza4
            // 
            this.grb_Forza4.Controls.Add(this.lblTurnPlayer);
            this.grb_Forza4.Controls.Add(this.playAgainBtn);
            this.grb_Forza4.Controls.Add(this.lbl_Vincitore);
            this.grb_Forza4.Controls.Add(this.gameStatusLbl);
            this.grb_Forza4.Controls.Add(this.dataGridView1);
            this.grb_Forza4.Location = new System.Drawing.Point(737, 29);
            this.grb_Forza4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grb_Forza4.Name = "grb_Forza4";
            this.grb_Forza4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grb_Forza4.Size = new System.Drawing.Size(815, 715);
            this.grb_Forza4.TabIndex = 6;
            this.grb_Forza4.TabStop = false;
            this.grb_Forza4.Text = "FORZA 4";
            // 
            // lblTurnPlayer
            // 
            this.lblTurnPlayer.AutoSize = true;
            this.lblTurnPlayer.Location = new System.Drawing.Point(411, 39);
            this.lblTurnPlayer.Name = "lblTurnPlayer";
            this.lblTurnPlayer.Size = new System.Drawing.Size(0, 20);
            this.lblTurnPlayer.TabIndex = 9;
            // 
            // playAgainBtn
            // 
            this.playAgainBtn.Location = new System.Drawing.Point(379, 662);
            this.playAgainBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playAgainBtn.Name = "playAgainBtn";
            this.playAgainBtn.Size = new System.Drawing.Size(86, 31);
            this.playAgainBtn.TabIndex = 8;
            this.playAgainBtn.Text = "RIGIOCA";
            this.playAgainBtn.UseVisualStyleBackColor = true;
            // 
            // lbl_Vincitore
            // 
            this.lbl_Vincitore.AutoSize = true;
            this.lbl_Vincitore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_Vincitore.Location = new System.Drawing.Point(674, 64);
            this.lbl_Vincitore.Name = "lbl_Vincitore";
            this.lbl_Vincitore.Size = new System.Drawing.Size(0, 20);
            this.lbl_Vincitore.TabIndex = 7;
            // 
            // gameStatusLbl
            // 
            this.gameStatusLbl.AutoSize = true;
            this.gameStatusLbl.Location = new System.Drawing.Point(417, 50);
            this.gameStatusLbl.Name = "gameStatusLbl";
            this.gameStatusLbl.Size = new System.Drawing.Size(0, 20);
            this.gameStatusLbl.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(136, 88);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(557, 556);
            this.dataGridView1.TabIndex = 1;
            // 
            // searchingLbl
            // 
            this.searchingLbl.AutoSize = true;
            this.searchingLbl.Location = new System.Drawing.Point(585, 416);
            this.searchingLbl.Name = "searchingLbl";
            this.searchingLbl.Size = new System.Drawing.Size(0, 20);
            this.searchingLbl.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 768);
            this.Controls.Add(this.grb_Forza4);
            this.Controls.Add(this.grb_RegoleEAvvio);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "FORZA 4";
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
        private Label gameStatusLbl;
        private Button playAgainBtn;
        private Label label2;
        private Label label1;
        private Button button1;
        private ListBox lstHosts;
        private Label lblTurnPlayer;
        private Label label35;
        private TextBox usernameTextBox;
        private Label searchingLbl;
    }
}