using System;
using System.Collections.Generic;
using System.Text;

namespace Les2Oef1
{
    class Tweet: IPrintMessage
    {
        private string account;
        private string hashtag;
        private string message;

        public string Account
        {
            get
            {
                return this.account;
            }
            set
            {
                this.account = value;
            }
        }

        public string Hashtag
        {
            get
            {
                return this.hashtag;
            }
            set
            {
                this.hashtag = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public void GetMessageInfo()
        {
            Console.WriteLine("--- Tweet ---");
            Console.WriteLine("\tTweet account: " + this.account + "\n\tHashtag: #" + this.hashtag + "\n\tBericht: " + this.message);
        }

        public override string ToString()
        {
            return "Tweet - " + this.hashtag;
        }
    }
}
