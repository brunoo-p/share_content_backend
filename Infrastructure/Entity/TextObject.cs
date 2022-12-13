using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class TextObject
    {
        public string text { get; private set; }

        public TextObject( string Text )
        {
            text = Text;
        }
    }
}
