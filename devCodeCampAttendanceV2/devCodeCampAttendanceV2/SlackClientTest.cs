using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2
{
    public class SlackClientTest
    {
        public void TestPostMessage()
        {
            string urlWithAccessToken = "https://hooks.slack.com/services/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";
            string username = "jonathanweatherall0";
            SlackClient client = new SlackClient(urlWithAccessToken);

            client.PostMessage(username: "attendotron",
                       text: "If you havent signed in yet, you can do so here: ",
                       channel: "@"+username);
        }

        

    }
}