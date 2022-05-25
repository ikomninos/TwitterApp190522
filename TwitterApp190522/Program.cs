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

            var userCredentials = new TwitterCredentials("IBuHFUmoHfEuBuulMEZsHUaCq", "Q51B2bLhAj5rIuXtgEhVcWuJuEjeK63qcf9PV40ufKgO91TAcr", "1509553057486495746-A7vG0iC5Pci9cGWPI6PWooAKgoDFnk", "MZBHe037LtpkWQgaoRZGtoTnyCVGneg3eb1358RYU8ZuU");
            var userClient = new TwitterClient(userCredentials);
            string filter1 = "C#";
            string filter2 = "Python";
            string filter3 = "javascript";
            string filter4 = "pascal";

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

                if (tweetText.Contains(filter1))

                {
                    counter1++;
                }
                if (tweetText.Contains(filter2))
                {

                    counter2++;
                }
                if (tweetText.Contains(filter3))
                {
                    counter3++;
                }
            
                Console.WriteLine(
                    filter1 + ":" + counter1 + ", " +
                    filter2 + ":" + counter2 + ", " +
                    filter3 + ":" + counter3
                   


                    );
                Console.WriteLine("----------------");

                if (counttweets == 100)
                {
                    stream.Stop();
                    Console.WriteLine("Complete!");
                }

                counttweets++;
            };


            await stream.StartMatchingAnyConditionAsync();
            


         


          


        }
    }
}
