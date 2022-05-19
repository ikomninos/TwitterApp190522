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
            stream.AddTrack("c#");
            stream.AddTrack("python");

            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
           
            int counttweets = 0;


            stream.MatchingTweetReceived += async (sender, eventReceived) =>

            {



                ITweet tweet = eventReceived.Tweet;
                string tweetText = eventReceived.Tweet.FullText;
                int favoritecount = tweet.FavoriteCount;
                string tweetAuthorName = tweet.CreatedBy.Name;


                Console.WriteLine(tweetAuthorName, " " + " " + favoritecount);
                Console.WriteLine(tweetText);
                Console.WriteLine();
                Console.WriteLine();



                await stream.StartMatchingAnyConditionAsync();
            };


         


          


        }
    }
}
