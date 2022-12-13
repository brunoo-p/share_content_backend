using Newtonsoft.Json;

namespace Infrastructure.Entity.Response.LinkedinShare
{
    public class RegisterImageResponse
    {
        public Value value { get; private set; }
        
        public RegisterImageResponse( Value Value)
        {
            value = Value;
        }
    }
    public class Value
    {
        public UploadMechanism uploadMechanism { get; private set; }
        public string mediaArtifact { get; private set; }
        public string asset { get; private set; }

        public Value( UploadMechanism UploadMechanism, string MediaArtifact, string Asset )
        {
            uploadMechanism = UploadMechanism;
            mediaArtifact = MediaArtifact;
            asset = Asset;
        }
    }
    public class UploadMechanism
    {
        [JsonProperty("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest")]
        public MediaUploadHttpRequest mediauploadhttprequest { get; private set; }
        public UploadMechanism( MediaUploadHttpRequest Mediauploadhttprequest )
        {
            mediauploadhttprequest = Mediauploadhttprequest;
        }
    }
    public class MediaUploadHttpRequest
    {
        public object headers { get; private set; }
        public string uploadUrl { get; private set; }

        public MediaUploadHttpRequest(object Header, string UploadUrl)
        {
            headers = Header;
            uploadUrl = UploadUrl;
        }
    }

}
