using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Request.LinkedinShare
{
    public class ImagePost
    {
        public string author { get; set; }
        public string lifecycleState { get; set; }
        public Specificcontent specificContent { get; set; }
        public Visibility visibility { get; set; }

        public class Specificcontent
        {
            [JsonProperty("com.linkedin.ugc.ShareContent")]
            public Sharecontent shareContent { get; set; }
        }

        public class Sharecontent
        {
            public Sharecommentary shareCommentary { get; set; }
            public string shareMediaCategory { get; set; } = "IMAGE";
            public Media[] media { get; set; }
        }

        public class Sharecommentary
        {
            public string text { get; set; }
        }

        public class Media
        {
            public string status { get; set; } = "READY";
            public Description description { get; set; }
            public string media { get; set; }
            public Title title { get; set; }
        }

        public class Description
        {
            public string text { get; set; }
        }

        public class Title
        {
            public string text { get; set; }
        }

        public class Visibility
        {
            [JsonProperty("com.linkedin.ugc.MemberNetworkVisibility")]
            public string memberNetworkVisibility { get; set; }
        }

    }
}
