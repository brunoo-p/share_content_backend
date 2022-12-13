using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enum
{
    public enum MemberVisibility
    {
        CONNECTIONS,    // The share will be viewable by 1st-degree connections only.
        PUBLIC,         // The share will be viewable by anyone on LinkedIn.
    }
    public enum MediaCategory
    {
        NONE,       // The share does not contain any media, and will only consist of text.
        ARTICLE,    // The share contains a URL
        IMAGE       // The Share contains an image.
    }
    public enum LifecycleState
    {
        PUBLISHED 
    }
}
