using Microsoft.AspNetCore.Http;

namespace Infrastructure.Entity.Post
{
    public class PostAttributes
    { 
        public string commentary { get; private set; }
        public IFormFile file { get; private set; }

        public PostAttributes(string commentary, IFormFile file)
        {
            this.commentary = commentary;
            this.file = file;
        }
    }
}
