using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Response
{
    public class PersonResponse
    {
        public string Id { get; private set; }
        public string LocalizedFirstName { get; private set; }
        public string LocalizedLastName { get; private set; }

        public PersonResponse( string id, string localizedFirstName, string localizedLastName )
        {
            Id = id;
            LocalizedFirstName = localizedFirstName;
            LocalizedLastName = localizedLastName;
        }
    }
}
