using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace ChronosBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                //// calculate something for us to return
                //int length = (message.Text ?? string.Empty).Length;

                //// return our reply to the user
                //return message.CreateReplyMessage($"You sent {length} characters");

                if (message.Text.ToLower() == "hi")
                {
                    return message.CreateReplyMessage("Yes! Please tell me your feedback, I'm listening!");
                }

                var hc = new HttpClient();
                var response = await hc.GetStringAsync($"https://api.projectoxford.ai/luis/v1/application?id=7fc93106-708f-40fd-a1f7-a770868c6068&subscription-key=3681d667776544e4a642adb6199af213&q={message.Text}");

                var obj = JsonConvert.DeserializeObject<LUISClass.Rootobject>(response);

                string reply = "";
                string meaning = obj.intents[0].intent;

                if(meaning == "None")
                {
                    reply = "I will work on your feedback soon, thank you! =)";
                }
                else
                {
                    reply = $"I got your feedback! Will consider your feedback for {meaning} ({Convert.ToInt32((obj.intents[0].score * 100))}%), thanks for your feedback! =)";
                }

                return message.CreateReplyMessage(reply);


            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "BotAddedToConversation";
                return reply;
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}