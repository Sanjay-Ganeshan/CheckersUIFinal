using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerUI
{
    public partial class Form1 : Form
    {
        Bitmap redCoin;
        Bitmap blackCoin;
        Bitmap redKing;
        Bitmap blackKing;
        Bitmap checkerBoard;
        Bitmap selectedSquare;

        List<Point> selectedPoints;

        List<Point> occupiedSpacesRed;
        List<Point> occupiedSpacesBlack;
        bool isShowingMessage = false;
        bool isLocked = false;
        bool isTurn = false;
        dynamic lastSummary;

        public Form1()
        {
            InitializeComponent();
        }

        public void loadCoins()
        {
            redCoin = CheckerUI.Properties.Resources.redpiece;
            blackCoin = CheckerUI.Properties.Resources.blackpiece;
            checkerBoard = CheckerUI.Properties.Resources.checkerboard;
            redKing = CheckerUI.Properties.Resources.redking;
            blackKing = CheckerUI.Properties.Resources.blackking;
            selectedSquare = CheckerUI.Properties.Resources.selectedsquare;
        }

        public Point boardCoordinateToAbsolute(int x, int y)
        {
            return new Point(x * 75, y * 75);
        }

        public Point absoluteCoordinateToBoardCoordinate(int x, int y)
        {
            return new Point((int) x / 75, (int) y / 75);
        }

        public Bitmap drawBoard(dynamic summary)
        {
            Bitmap newBoard = new Bitmap(600, 600);
            newBoard.MakeTransparent();
            Graphics g = Graphics.FromImage(newBoard);
            g.CompositingMode = CompositingMode.SourceOver;
            var redPieces = summary.redpieces;
            var blackPieces = summary.blackpieces;
            int xToDraw;
            int yToDraw;
            occupiedSpacesRed.Clear();
            occupiedSpacesBlack.Clear();
            for (int q = 0; q < selectedPoints.Count; q++)
            {
                g.DrawImage(selectedSquare, boardCoordinateToAbsolute(this.selectedPoints[q].X, this.selectedPoints[q].Y));
            }
            foreach (var redPiece in redPieces)
            {
                xToDraw = (int) redPiece["x"];
                yToDraw = (int) redPiece["y"];
                if((bool) redPiece["isKing"])
                    g.DrawImage(redKing, boardCoordinateToAbsolute(xToDraw, yToDraw));
                else
                    g.DrawImage(redCoin, boardCoordinateToAbsolute(xToDraw,yToDraw));
                occupiedSpacesRed.Add(new Point(xToDraw, yToDraw));
            }
            foreach (var blackPiece in blackPieces)
            {
                xToDraw = (int)blackPiece["x"];
                yToDraw = (int)blackPiece["y"];
                if ((bool)blackPiece["isKing"])
                    g.DrawImage(blackKing, boardCoordinateToAbsolute(xToDraw, yToDraw));
                else
                    g.DrawImage(blackCoin, boardCoordinateToAbsolute(xToDraw, yToDraw));
                occupiedSpacesBlack.Add(new Point(xToDraw, yToDraw));
            }
            return newBoard;
            //Bitmap
            //foreach(var)
        }


        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            createGame();
        }

        private void rbSignIn_CheckedChanged(object sender, EventArgs e)
        {
            lblConfirmPassword.Visible = !lblConfirmPassword.Visible;
            txtConfirm.Visible = !txtConfirm.Visible;
            if (rbSignIn.Checked)
            {
                btnSignIn.Text = "Sign In";
                lblConfirmPassError.Visible = false;
            }
            else if (rbSignUp.Checked)
            {
                btnSignIn.Text = "Sign Up";
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckersServer.server.setServer(txtServer.Text);
            }
            catch (Exception f)
            {

            }
            CheckersServer.server.setLoginInfo(this.txtUsername.Text, this.txtPassword.Text);
            lblConfirmPassError.Visible = false;
            if (rbSignIn.Checked)
                signIn();
            else if (rbSignUp.Checked)
            {
                if (!txtPassword.Text.Equals(txtConfirm.Text))
                {
                    lblConfirmPassError.Visible = true;
                }
                else
                {
                    signUp();
                }
            }
        }
        async void signIn()
        {
            CHServerResponse resp = await CheckersServer.server.logIn();
            if (resp.worked)
                transitionFromSignInToLobby();
            else
                broadcastError(resp);
        }

        void transitionFromLobbyToGame()
        {
            timerLobbyUpdate.Stop();
            btnLogOut.Visible = false;
            gbLobby.Visible = false;
            gbGame.Visible = true;
            timerGameUpdate.Start();
            setUpGame();
        }

        void transitionFromGameToLobby()
        {
            timerLobbyUpdate.Start();
            btnLogOut.Visible = true;
            gbLobby.Visible = true;
            gbGame.Visible = false;
            timerGameUpdate.Stop();
            setUpLobby();
        }

        void transitionFromSignInToLobby()
        {
            timerLobbyUpdate.Start();
            btnLogOut.Visible = true;
            gbLobby.Visible = true;
            gbLogin.Visible = false;
            setUpLobby();
        }

        void transitionFromLobbyToSignIn()
        {
            timerLobbyUpdate.Stop();
            btnLogOut.Visible = false;
            gbLobby.Visible = false;
            gbLogin.Visible = true;
            setUpSignIn();
        }

        void setUpLobby()
        {
            lblLobbyCurrentUser.Text = "Currently signed in as: " + CheckersServer.server.getCurrentUser();
            updateLobby();
        }

        async void createGame()
        {
            CHServerResponse resp = await CheckersServer.server.createGame();
            if (resp.worked)
            {
                transitionFromLobbyToGame();
            }
            else
                broadcastError(resp);
        }

        async void joinGame()
        {
            string gameId = "";
            gameId = lboxGameList.SelectedItem.ToString();
            CHServerResponse resp = await CheckersServer.server.joinGame(gameId);
            if (resp.worked)
            {
                transitionFromLobbyToGame();
            }
            else
                broadcastError(resp);
        }

        async void updateLobby()
        {
            CHServerResponse resp = await CheckersServer.server.getGamesList();
            if (resp.worked)
            {
                List<object> gamesList = resp.info.gamesList;
                int selectedIndex = lboxGameList.SelectedIndex;
                lboxGameList.Items.Clear();
                foreach (object o in gamesList)
                {
                    lboxGameList.Items.Add(o.ToString());
                }
                if (selectedIndex < gamesList.Count)
                {
                    lboxGameList.SelectedIndex = selectedIndex;
                }
            }
            else
                broadcastError(resp);
        }

        void setUpSignIn()
        {

        }

        void setUpGame()
        {
            updateGame();
        }



        async void signUp()
        {
            CHServerResponse resp = await CheckersServer.server.signUp();
            if (resp.worked)
            {
                MessageBox.Show("You're good to go! Try logging in now.");
                rbSignIn.Checked = true;
            }
            else
                broadcastError(resp);
        }

        async void updateGame()
        {
            CHServerResponse resp = await CheckersServer.server.getGameSummary();
            if (resp.worked)
            {
                lastSummary = resp.info.summary;
                Bitmap newBoard = drawBoard(resp.info.summary);
                pbBoard.Image = newBoard;


                lblGameID.Text = "Game ID: " + resp.info.summary.gameid;
                List<dynamic> players = resp.info.summary.players;
                List<ListViewItem> newItems = new List<ListViewItem>();
                foreach (var eachPlayer in players)
                {
                    ListViewItem newItem = new ListViewItem(new string[] { eachPlayer["turn"] ? ">" : "", eachPlayer["name"], eachPlayer["score"] + "" });
                    newItems.Add(newItem);
                }
                listViewPlayers.Items.Clear();
                listViewPlayers.Columns.Clear();
                listViewPlayers.Columns.Add("Turn");
                listViewPlayers.Columns.Add("Name");
                listViewPlayers.Columns.Add("Score");
                
                foreach (ListViewItem it in newItems)
                {
                    listViewPlayers.Items.Add(it);
                }
                isTurn = resp.info.summary.isturn;
                modifyUIForPlay();
            }
            else
                broadcastError(resp);
        }

        async void move()
        {
            if (selectedPoints.Count < 2)
            {
                return;
            }
            CHServerResponse resp = await CheckersServer.server.movePiece(selectedPoints[0],selectedPoints[1]);
            if (resp.worked)
            {
                this.isLocked = resp.info.locked;
                if(this.isLocked&& selectedPoints.Count >= 2)
                {
                    selectedPoints.RemoveAt(0);
                }
                if(resp.info.stillTurn)
                {

                }
                else
                {
                    isLocked = false;
                    isTurn = false;
                }
                clearPoints();
                updateGame();
            }
            else {
                clearPoints();
                broadcastError(resp);
            }
        }

        void modifyUIForPlay()
        {
            btnEndTurn.Visible = isLocked;
            btnLeaveGame.Visible = isTurn;
        }

        async void endTurn()
        {
            CHServerResponse resp = await CheckersServer.server.submitEndTurn();
            if (resp.worked)
            {
                isLocked = false;
                isTurn = false;
                clearPoints();
                updateGame();
            }
            else
                broadcastError(resp);
        }

        void clearPoints()
        {
            if (isLocked)
            {
                while (this.selectedPoints.Count > 1)
                {
                    this.selectedPoints.RemoveAt(1);
                }
            }
            else
            {
                this.selectedPoints.Clear();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            transitionFromLobbyToSignIn();
        }

        private void timerLobbyUpdate_Tick(object sender, EventArgs e)
        {
            updateLobby();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateLobby();
        }

        private void timerGameUpdate_Tick(object sender, EventArgs e)
        {
            updateGame();
        }

        private void btnJoinGame_Click(object sender, EventArgs e)
        {
            joinGame();
        }

        async void leaveGame()
        {
            CHServerResponse resp = await CheckersServer.server.leaveGame();
            if (resp.worked)
            {
                transitionFromGameToLobby();
            }
            else
                broadcastError(resp);
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            leaveGame();
        }

        public void broadcastError(CHServerResponse resp)
        {
            string s = resp.info.error;
            if (!isShowingMessage)
            {
                isShowingMessage = true;
                //DialogResult x = MessageBox.Show(s + "\nWould you like to keep running the application?", "An error occurred.",MessageBoxButtons.YesNo);
                MessageBox.Show(s);
                /*if(x == DialogResult.No)
                {
                    //this.Close();
                }
                else
                {*/
                    this.isShowingMessage = false;
                //}
            }
            Debug.WriteLine(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCoins();
            CheckersServer.server = new CheckersServer();
            selectedPoints = new List<Point>();
            occupiedSpacesRed = new List<Point>();
            occupiedSpacesBlack = new List<Point>();
        }

        private void pbBoard_Click(object sender, EventArgs e)
        {
            //Point gameBoardPoint = absoluteCoordinateToBoardCoordinate()
            var x = ((MouseEventArgs)e).X;
            var y = ((MouseEventArgs)e).Y;
            Point p = absoluteCoordinateToBoardCoordinate(x, y);
            if (isTurn)
            {
                switch (selectedPoints.Count)
                {
                    case 0:
                        selectedPoints.Add(p);
                        pbBoard.Image=drawBoard(lastSummary);
                        break;
                    case 1:
                        selectedPoints.Add(p);
                        move();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            endTurn();
        }
    }
}
