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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Server = new System.Windows.Forms.Button();
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.lbl_Titolo2 = new System.Windows.Forms.Label();
            this.grb_RegoleEAvvio = new System.Windows.Forms.GroupBox();
            this.searchingLbl = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Discover = new System.Windows.Forms.Button();
            this.lstHosts = new System.Windows.Forms.ListBox();
            this.grb_Forza4 = new System.Windows.Forms.GroupBox();
            this.lblTurnPlayer = new System.Windows.Forms.Label();
            this.playAgainBtn = new System.Windows.Forms.Button();
            this.lbl_Vincitore = new System.Windows.Forms.Label();
            this.gameStatusLbl = new System.Windows.Forms.Label();
            this.dtg_Forza4 = new System.Windows.Forms.DataGridView();
            this.grb_RegoleEAvvio.SuspendLayout();
            this.grb_Forza4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Forza4)).BeginInit();
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
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(512, 382);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.clientBtn_Click);
            // 
            // btn_Server
            // 
            this.btn_Server.Location = new System.Drawing.Point(66, 312);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(75, 23);
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
            this.lbl_Titolo2.Location = new System.Drawing.Point(179, 190);
            this.lbl_Titolo2.Name = "lbl_Titolo2";
            this.lbl_Titolo2.Size = new System.Drawing.Size(240, 17);
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
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Discover);
            this.grb_RegoleEAvvio.Controls.Add(this.lstHosts);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Regole);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo2);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Connect);
            this.grb_RegoleEAvvio.Controls.Add(this.lbl_Titolo);
            this.grb_RegoleEAvvio.Controls.Add(this.btn_Server);
            this.grb_RegoleEAvvio.Location = new System.Drawing.Point(12, 22);
            this.grb_RegoleEAvvio.Name = "grb_RegoleEAvvio";
            this.grb_RegoleEAvvio.Size = new System.Drawing.Size(627, 536);
            this.grb_RegoleEAvvio.TabIndex = 5;
            this.grb_RegoleEAvvio.TabStop = false;
            this.grb_RegoleEAvvio.Text = "REGOLE E AVVIO";
            // 
            // searchingLbl
            // 
            this.searchingLbl.AutoSize = true;
            this.searchingLbl.Location = new System.Drawing.Point(512, 312);
            this.searchingLbl.Name = "searchingLbl";
            this.searchingLbl.Size = new System.Drawing.Size(0, 15);
            this.searchingLbl.TabIndex = 11;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(66, 217);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(60, 15);
            this.label35.TabIndex = 10;
            this.label35.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(66, 241);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(227, 23);
            this.usernameTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Join A Game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host A Game";
            // 
            // btn_Discover
            // 
            this.btn_Discover.Location = new System.Drawing.Point(512, 344);
            this.btn_Discover.Name = "btn_Discover";
            this.btn_Discover.Size = new System.Drawing.Size(75, 23);
            this.btn_Discover.TabIndex = 6;
            this.btn_Discover.Text = "Discover";
            this.btn_Discover.UseVisualStyleBackColor = true;
            this.btn_Discover.Click += new System.EventHandler(this.on_DiscoverButtonClick);
            // 
            // lstHosts
            // 
            this.lstHosts.FormattingEnabled = true;
            this.lstHosts.ItemHeight = 15;
            this.lstHosts.Location = new System.Drawing.Point(179, 312);
            this.lstHosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstHosts.Name = "lstHosts";
            this.lstHosts.Size = new System.Drawing.Size(305, 139);
            this.lstHosts.TabIndex = 5;
            // 
            // grb_Forza4
            // 
            this.grb_Forza4.Controls.Add(this.lblTurnPlayer);
            this.grb_Forza4.Controls.Add(this.playAgainBtn);
            this.grb_Forza4.Controls.Add(this.lbl_Vincitore);
            this.grb_Forza4.Controls.Add(this.gameStatusLbl);
            this.grb_Forza4.Controls.Add(this.dtg_Forza4);
            this.grb_Forza4.Location = new System.Drawing.Point(645, 22);
            this.grb_Forza4.Name = "grb_Forza4";
            this.grb_Forza4.Size = new System.Drawing.Size(713, 536);
            this.grb_Forza4.TabIndex = 6;
            this.grb_Forza4.TabStop = false;
            this.grb_Forza4.Text = "FORZA 4";
            // 
            // lblTurnPlayer
            // 
            this.lblTurnPlayer.AutoSize = true;
            this.lblTurnPlayer.Location = new System.Drawing.Point(282, 29);
            this.lblTurnPlayer.Name = "lblTurnPlayer";
            this.lblTurnPlayer.Size = new System.Drawing.Size(0, 15);
            this.lblTurnPlayer.TabIndex = 9;
            // 
            // playAgainBtn
            // 
            this.playAgainBtn.Location = new System.Drawing.Point(326, 505);
            this.playAgainBtn.Name = "playAgainBtn";
            this.playAgainBtn.Size = new System.Drawing.Size(75, 23);
            this.playAgainBtn.TabIndex = 8;
            this.playAgainBtn.Text = "RIGIOCA";
            this.playAgainBtn.UseVisualStyleBackColor = true;
            // 
            // lbl_Vincitore
            // 
            this.lbl_Vincitore.AutoSize = true;
            this.lbl_Vincitore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_Vincitore.Location = new System.Drawing.Point(512, 48);
            this.lbl_Vincitore.Name = "lbl_Vincitore";
            this.lbl_Vincitore.Size = new System.Drawing.Size(0, 15);
            this.lbl_Vincitore.TabIndex = 7;
            // 
            // gameStatusLbl
            // 
            this.gameStatusLbl.AutoSize = true;
            this.gameStatusLbl.Location = new System.Drawing.Point(287, 38);
            this.gameStatusLbl.Name = "gameStatusLbl";
            this.gameStatusLbl.Size = new System.Drawing.Size(0, 15);
            this.gameStatusLbl.TabIndex = 6;
            // 
            // dtg_Forza4
            // 
            this.dtg_Forza4.AllowUserToAddRows = false;
            this.dtg_Forza4.AllowUserToDeleteRows = false;
            this.dtg_Forza4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_Forza4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Forza4.Location = new System.Drawing.Point(6, 66);
            this.dtg_Forza4.Name = "dtg_Forza4";
            this.dtg_Forza4.ReadOnly = true;
            this.dtg_Forza4.RowHeadersWidth = 51;
            this.dtg_Forza4.RowTemplate.Height = 25;
            this.dtg_Forza4.Size = new System.Drawing.Size(701, 417);
            this.dtg_Forza4.TabIndex = 1;
            this.dtg_Forza4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_Forza4_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 562);
            this.Controls.Add(this.grb_Forza4);
            this.Controls.Add(this.grb_RegoleEAvvio);
            this.Name = "Form1";
            this.Text = "FORZA 4";
            this.grb_RegoleEAvvio.ResumeLayout(false);
            this.grb_RegoleEAvvio.PerformLayout();
            this.grb_Forza4.ResumeLayout(false);
            this.grb_Forza4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Forza4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbl_Regole;
        private Button btn_Connect;
        private Button btn_Server;
        private Label lbl_Titolo;
        private Label lbl_Titolo2;
        private GroupBox grb_RegoleEAvvio;
        private GroupBox grb_Forza4;
        private DataGridView dtg_Forza4;
        private Label lbl_Vincitore;
        private Label gameStatusLbl;
        private Button playAgainBtn;
        private Label label2;
        private Label label1;
        private Button btn_Discover;
        private ListBox lstHosts;
        private Label lblTurnPlayer;
        private Label label35;
        private TextBox usernameTextBox;
        private Label searchingLbl;
    }
}