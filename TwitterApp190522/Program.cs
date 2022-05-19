using System;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterApp190522
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);


            // Create a simple stream containing only tweets with the keyword France

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("java");

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

            await stream.StartMatchingAnyConditionAsync();


        }
    }
}
