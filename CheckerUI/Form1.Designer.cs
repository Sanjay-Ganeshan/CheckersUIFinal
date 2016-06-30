namespace CheckerUI
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
            this.components = new System.ComponentModel.Container();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.gbLobby = new System.Windows.Forms.GroupBox();
            this.lblLobbyCurrentUser = new System.Windows.Forms.Label();
            this.lboxGameList = new System.Windows.Forms.ListBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.timerLobbyUpdate = new System.Windows.Forms.Timer(this.components);
            this.timerGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.gbGame = new System.Windows.Forms.GroupBox();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.lblGameID = new System.Windows.Forms.Label();
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.btnLeaveGame = new System.Windows.Forms.Button();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblConfirmPassError = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.rbSignUp = new System.Windows.Forms.RadioButton();
            this.rbSignIn = new System.Windows.Forms.RadioButton();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            this.gbLobby.SuspendLayout();
            this.gbGame.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbBoard
            // 
            this.pbBoard.BackgroundImage = global::CheckerUI.Properties.Resources.checkerboard;
            this.pbBoard.Location = new System.Drawing.Point(27, 80);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(600, 600);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            this.pbBoard.Click += new System.EventHandler(this.pbBoard_Click);
            // 
            // gbLobby
            // 
            this.gbLobby.Controls.Add(this.lblLobbyCurrentUser);
            this.gbLobby.Controls.Add(this.lboxGameList);
            this.gbLobby.Controls.Add(this.btnLogOut);
            this.gbLobby.Controls.Add(this.button1);
            this.gbLobby.Controls.Add(this.btnCreateGame);
            this.gbLobby.Controls.Add(this.btnJoinGame);
            this.gbLobby.Location = new System.Drawing.Point(934, 279);
            this.gbLobby.Name = "gbLobby";
            this.gbLobby.Size = new System.Drawing.Size(309, 434);
            this.gbLobby.TabIndex = 2;
            this.gbLobby.TabStop = false;
            this.gbLobby.Text = "Lobby";
            this.gbLobby.Visible = false;
            // 
            // lblLobbyCurrentUser
            // 
            this.lblLobbyCurrentUser.AutoSize = true;
            this.lblLobbyCurrentUser.Location = new System.Drawing.Point(98, 31);
            this.lblLobbyCurrentUser.Name = "lblLobbyCurrentUser";
            this.lblLobbyCurrentUser.Size = new System.Drawing.Size(116, 13);
            this.lblLobbyCurrentUser.TabIndex = 4;
            this.lblLobbyCurrentUser.Text = "Currently Logged in As:";
            // 
            // lboxGameList
            // 
            this.lboxGameList.FormattingEnabled = true;
            this.lboxGameList.Location = new System.Drawing.Point(17, 55);
            this.lboxGameList.Name = "lboxGameList";
            this.lboxGameList.Size = new System.Drawing.Size(290, 303);
            this.lboxGameList.TabIndex = 3;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(17, 26);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "↺";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Location = new System.Drawing.Point(68, 370);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(135, 26);
            this.btnCreateGame.TabIndex = 1;
            this.btnCreateGame.Text = "Create Game";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(68, 402);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(135, 26);
            this.btnJoinGame.TabIndex = 0;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.btnJoinGame_Click);
            // 
            // timerLobbyUpdate
            // 
            this.timerLobbyUpdate.Interval = 4000;
            this.timerLobbyUpdate.Tick += new System.EventHandler(this.timerLobbyUpdate_Tick);
            // 
            // timerGameUpdate
            // 
            this.timerGameUpdate.Interval = 2500;
            this.timerGameUpdate.Tick += new System.EventHandler(this.timerGameUpdate_Tick);
            // 
            // gbGame
            // 
            this.gbGame.Controls.Add(this.btnEndTurn);
            this.gbGame.Controls.Add(this.lblGameID);
            this.gbGame.Controls.Add(this.listViewPlayers);
            this.gbGame.Controls.Add(this.btnLeaveGame);
            this.gbGame.Controls.Add(this.pbBoard);
            this.gbGame.Location = new System.Drawing.Point(7, 12);
            this.gbGame.Name = "gbGame";
            this.gbGame.Size = new System.Drawing.Size(921, 701);
            this.gbGame.TabIndex = 3;
            this.gbGame.TabStop = false;
            this.gbGame.Text = "Game";
            this.gbGame.Visible = false;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(686, 267);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(165, 49);
            this.btnEndTurn.TabIndex = 10;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Visible = false;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // lblGameID
            // 
            this.lblGameID.Location = new System.Drawing.Point(259, 30);
            this.lblGameID.Name = "lblGameID";
            this.lblGameID.Size = new System.Drawing.Size(418, 18);
            this.lblGameID.TabIndex = 9;
            this.lblGameID.Text = "Game ID: ";
            this.lblGameID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Location = new System.Drawing.Point(686, 544);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(229, 71);
            this.listViewPlayers.TabIndex = 8;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            // 
            // btnLeaveGame
            // 
            this.btnLeaveGame.Location = new System.Drawing.Point(695, 621);
            this.btnLeaveGame.Name = "btnLeaveGame";
            this.btnLeaveGame.Size = new System.Drawing.Size(166, 42);
            this.btnLeaveGame.TabIndex = 1;
            this.btnLeaveGame.Text = "Leave Game";
            this.btnLeaveGame.UseVisualStyleBackColor = true;
            this.btnLeaveGame.Visible = false;
            this.btnLeaveGame.Click += new System.EventHandler(this.btnLeaveGame_Click);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.txtServer);
            this.gbLogin.Controls.Add(this.lblServer);
            this.gbLogin.Controls.Add(this.lblConfirmPassError);
            this.gbLogin.Controls.Add(this.btnSignIn);
            this.gbLogin.Controls.Add(this.rbSignUp);
            this.gbLogin.Controls.Add(this.rbSignIn);
            this.gbLogin.Controls.Add(this.lblConfirmPassword);
            this.gbLogin.Controls.Add(this.txtConfirm);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.lblUsername);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.txtUsername);
            this.gbLogin.Location = new System.Drawing.Point(1030, 33);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(213, 233);
            this.gbLogin.TabIndex = 4;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login Controls";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(80, 18);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(127, 20);
            this.txtServer.TabIndex = 10;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 25);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "Server:";
            // 
            // lblConfirmPassError
            // 
            this.lblConfirmPassError.AutoSize = true;
            this.lblConfirmPassError.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPassError.Location = new System.Drawing.Point(82, 164);
            this.lblConfirmPassError.Name = "lblConfirmPassError";
            this.lblConfirmPassError.Size = new System.Drawing.Size(125, 13);
            this.lblConfirmPassError.TabIndex = 2;
            this.lblConfirmPassError.Text = "X Passwords must match";
            this.lblConfirmPassError.Visible = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(28, 195);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(148, 21);
            this.btnSignIn.TabIndex = 8;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // rbSignUp
            // 
            this.rbSignUp.AutoSize = true;
            this.rbSignUp.Location = new System.Drawing.Point(134, 48);
            this.rbSignUp.Name = "rbSignUp";
            this.rbSignUp.Size = new System.Drawing.Size(63, 17);
            this.rbSignUp.TabIndex = 7;
            this.rbSignUp.TabStop = true;
            this.rbSignUp.Text = "Sign Up";
            this.rbSignUp.UseVisualStyleBackColor = true;
            // 
            // rbSignIn
            // 
            this.rbSignIn.AutoSize = true;
            this.rbSignIn.Checked = true;
            this.rbSignIn.Location = new System.Drawing.Point(28, 48);
            this.rbSignIn.Name = "rbSignIn";
            this.rbSignIn.Size = new System.Drawing.Size(57, 17);
            this.rbSignIn.TabIndex = 6;
            this.rbSignIn.TabStop = true;
            this.rbSignIn.Text = "Sign in";
            this.rbSignIn.UseVisualStyleBackColor = true;
            this.rbSignIn.CheckedChanged += new System.EventHandler(this.rbSignIn_CheckedChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(12, 143);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(45, 13);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Confirm:";
            this.lblConfirmPassword.Visible = false;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(80, 140);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(127, 20);
            this.txtConfirm.TabIndex = 4;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.Visible = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 117);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 90);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 114);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(127, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(80, 87);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(127, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 741);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.gbGame);
            this.Controls.Add(this.gbLobby);
            this.Name = "Form1";
            this.Text = "Checkers!";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            this.gbLobby.ResumeLayout(false);
            this.gbLobby.PerformLayout();
            this.gbGame.ResumeLayout(false);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.GroupBox gbLobby;
        private System.Windows.Forms.Label lblLobbyCurrentUser;
        private System.Windows.Forms.ListBox lboxGameList;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Timer timerLobbyUpdate;
        private System.Windows.Forms.Timer timerGameUpdate;
        private System.Windows.Forms.GroupBox gbGame;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblConfirmPassError;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.RadioButton rbSignUp;
        private System.Windows.Forms.RadioButton rbSignIn;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLeaveGame;
        private System.Windows.Forms.Label lblGameID;
        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.Button btnEndTurn;
    }
}

