using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class FormatString
    {
        public static string ImageTitle( string name )
        {
            return name[..name.IndexOf(".")];
        }
    }
}
