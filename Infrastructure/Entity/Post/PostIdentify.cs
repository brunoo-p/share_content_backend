using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Post
{
    public class PostIdentify
    {
        public string id { get; private set; }
        public PostIdentify( string Id )
        {
            id = Id;
        }
    }
}
