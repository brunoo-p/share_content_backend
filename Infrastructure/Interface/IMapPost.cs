using Infrastructure.Entity.Request.LinkedinPost;
using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IMapPost
    {
        PostRequest JustText( string id, string text, MemberVisibility visitbility );
        PostRequest WithImage( string id, string description, string title, string commentary, string asset, MemberVisibility visibility );
        List<Media> MapMedia( string description, string asset, string title );
    }
}
