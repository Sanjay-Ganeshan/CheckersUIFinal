using Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CheckerUI
{
    class CheckersServer
    {
        HttpClient client;
        public static CheckersServer server;
        string Username;
        string Password;
        string serverAddress;
        string apiEndpoint;

        public CheckersServer()
        {
            this.Username = "";
            this.Password = "";
            this.client = new HttpClient();
            serverAddress = "";
            apiEndpoint = "api/";
        }

        public string getCurrentUser()
        {
            return this.Username;
        }

        private async Task<dynamic> doGetRequest(string actionname)
        {
            HttpResponseMessage response = await client.GetAsync(apiEndpoint + actionname);
            Task<string> readTask = response.Content.ReadAsStringAsync();
            bool worked = response.IsSuccessStatusCode;
            string responseContent = await readTask;
            dynamic responseParsed = JsonParser.Deserialize(responseContent);
            if (worked)
            {
                return responseParsed;
            }
            else
            {
                throw new Exception(responseParsed.error);
            }
        }

        private async Task<dynamic> doPostRequest(string actionName, Dictionary<string, string> inputs, bool addPlayerAuthentication)
        {
            if (addPlayerAuthentication)
            {
                inputs["username"] = this.Username;
                inputs["password"] = this.Password;
            }
            FormUrlEncodedContent content = new FormUrlEncodedContent(inputs);
            HttpResponseMessage response = await client.PostAsync(apiEndpoint + actionName, content);
            Task<string> readTask = response.Content.ReadAsStringAsync();
            bool worked = response.IsSuccessStatusCode;
            string responseContent = await readTask;
            dynamic responseParsed = JsonParser.Deserialize(responseContent);
            if (worked)
            {
                return responseParsed;
            }
            else
            {
                throw new Exception(responseParsed.error);
            }
        }

        public void setServer(string newAddress)
        {
            if (!newAddress.EndsWith("/"))
            {
                newAddress += "/";
            }
            this.serverAddress = newAddress;
            this.client.BaseAddress = new Uri(this.serverAddress);
        }

        public void setLoginInfo(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public async Task<CHServerResponse> getGamesList()
        {
            dynamic getTask;
            dynamic getTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "listGames";
            getTask = doGetRequest(actionName);
            try
            {
                getTaskResult = await getTask;
                newInfo.gamesList = getTaskResult.gameslist;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to fetch games list: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> joinGame(string gameId)
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "joinGame";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            theParams.Add("gameId", gameId);
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.gameId = postTaskResult.gameid;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to join game: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }


        public async Task<CHServerResponse> createGame()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "createGame";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.gameId = postTaskResult.gameid;
                myResponse = new CHServerResponse(true, newInfo);

            }
            catch (Exception e)
            {
                newInfo.error = "Failed to create game: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> leaveGame()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "leaveGame";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.gameId = postTaskResult.gameid;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to leave game: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> getGameSummary()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "getGameSummary";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.summary = postTaskResult.summary;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to get game info: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> logIn()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "userValid";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.playerId = postTaskResult.playerid;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to log in: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> signUp()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "createPlayer";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.playerId = postTaskResult.playerid;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to sign up: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }

        public async Task<CHServerResponse> movePiece(Point p1, Point p2)
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "submitMove";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            theParams["x1"] = p1.X + "";
            theParams["y1"] = p1.Y + "";
            theParams["x2"] = p2.X + "";
            theParams["y2"] = p2.Y + "";

            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.valid = postTaskResult.valid;
                if (!newInfo.valid)
                {
                    newInfo.error = postTaskResult.movemessage;
                    myResponse = new CHServerResponse(false, newInfo);
                }
                else {
                    newInfo.stillTurn = postTaskResult.stillturn;
                    newInfo.message = postTaskResult.movemessage;
                    newInfo.locked = postTaskResult.islockedin;
                    myResponse = new CHServerResponse(true, newInfo);
                }
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to get submit move: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }
        public async Task<CHServerResponse> submitEndTurn()
        {
            dynamic postTask;
            dynamic postTaskResult;
            dynamic newInfo = new ExpandoObject();
            CHServerResponse myResponse;
            string actionName = "endMove";
            Dictionary<string, string> theParams = new Dictionary<string, string>();
            postTask = doPostRequest(actionName, theParams, true);
            try
            {
                postTaskResult = await postTask;
                newInfo.success = postTaskResult.success;
                myResponse = new CHServerResponse(true, newInfo);
            }
            catch (Exception e)
            {
                newInfo.error = "Failed to end turn: " + e.Message;
                myResponse = new CHServerResponse(false, newInfo);
            }
            return myResponse;
        }
    }
}
