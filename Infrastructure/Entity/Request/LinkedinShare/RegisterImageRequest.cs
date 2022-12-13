using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Request.LinkedinShare
{
    public class RegisterImageRequest
    {
        public UploadRequest registerUploadRequest { get; private set; }
        public RegisterImageRequest(UploadRequest UploadRequest)
        {
            registerUploadRequest = UploadRequest;
        }
    }
    public class UploadRequest
    {
        public List<string> recipes { get; } = new List<string>(){ "urn:li:digitalmediaRecipe:feedshare-image"  };
        public string owner { get; private set; }
        public List<ServiceRelationship> serviceRelationships { get; private set; } = new List<ServiceRelationship>() { new ServiceRelationship() };

        public UploadRequest(string Owner ) 
        {
            owner = $"urn:li:person:{Owner}";
        }
    }
    public class ServiceRelationship
    {
        public string relationshipType { get; } = "OWNER";
        public string identifier { get; } = "urn:li:userGeneratedContent";
    }

}
