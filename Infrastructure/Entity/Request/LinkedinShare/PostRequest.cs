using Infrastructure.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Request.LinkedinPost
{
    public class PostRequest
    {
        public string author { get; private set; }
        public string lifecycleState { get; } = LifecycleState.PUBLISHED.ToString();
        public SpecificContent specificContent { get; private set; }
        public Visibility visibility { get; private set; }

        public PostRequest( string Author, SpecificContent SpecificContent, Visibility Visibility )
        {
            author = $"urn:li:person:{Author}";
            specificContent = SpecificContent;
            visibility = Visibility;

        }
    }

    public class SpecificContent
    {
        [JsonPropertyAttribute("com.linkedin.ugc.ShareContent")]
        public ShareContent shareContent { get; private set; }

        public SpecificContent( ShareContent ShareContent )
        {
            shareContent = ShareContent;
        }
    }

    public class ShareContent
    {
        public TextObject shareCommentary { get; private set; }
        public string shareMediaCategory { get; private set; } = MediaCategory.NONE.ToString();
        public List<Media> media { get; private set; }

        public ShareContent( TextObject ShareCommentary )
        {
            shareCommentary = ShareCommentary;
        }
        public ShareContent( TextObject ShareCommentary, string ShareMediaCategory )
        {
            shareCommentary = ShareCommentary;
            shareMediaCategory = ShareMediaCategory;
        }
        public ShareContent( TextObject ShareCommentary, string ShareMediaCategory, List<Media> Media )
        {
            shareCommentary = ShareCommentary;
            shareMediaCategory = ShareMediaCategory;
            media = Media;
        }
    }

    public class Media
    {
        public string status { get; } = "READY";
        public TextObject description { get; private set; } = new TextObject("Investment");
        public string media { get; private set; }
        public TextObject title { get; private set; }

        public Media( string media, TextObject Title )
        {
            this.media = media;
            title = Title;
        }
    }

    public class Visibility
    {
        [JsonPropertyAttribute("com.linkedin.ugc.MemberNetworkVisibility")]
        public string memberNetworkVisibility { get; private set; } = MemberVisibility.PUBLIC.ToString();

        public Visibility( string MemberNetworkVisibility )
        {
            memberNetworkVisibility = MemberNetworkVisibility;
        }
    }

}
