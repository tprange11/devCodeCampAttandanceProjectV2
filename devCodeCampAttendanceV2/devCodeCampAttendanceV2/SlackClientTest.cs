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

            SlackClient client = new SlackClient(urlWithAccessToken);

            client.PostMessage(username: "attendotron",
                       text: "THIS IS A TEST MESSAGE! SQUEEDLYBAMBLYFEEDLYMEEDLYMOWWWWWWWW!",
                       channel: "#attendotron");
        }
    }
}