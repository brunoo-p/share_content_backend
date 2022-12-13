using Infrastructure.Entity;
using Infrastructure.Entity.Post;
using Infrastructure.Entity.Request.LinkedinPost;
using Infrastructure.Enum;

namespace Domain.Service.Linkedin
{
    public class MapPostService
    {

        public static PostRequest JustText(string id, string text, MemberVisibility visitbility )
        {
            return new PostRequest(
                id,
                new SpecificContent(
                    new ShareContent(new TextObject(text))
                ),
                new Visibility(visitbility.ToString())
            );
        }
        public static PostRequest WithImage(string id, PostAttributes postAttributes, string asset, MemberVisibility visibility)
        {
            string imageName = FormatString.ImageTitle(postAttributes.file.FileName);
            var post = new PostRequest(
                id,
                new SpecificContent(
                    new ShareContent(
                        new TextObject(postAttributes.commentary),
                        MediaCategory.IMAGE.ToString(),
                        MapMedia(asset, imageName)
                    )
                ),
                new Visibility(visibility.ToString())
            );
            return post;
        }

        private static List<Media> MapMedia(string asset, string title)
        {
            return
                new List<Media>() {
                    new Media(
                        asset,
                        new TextObject(title)
                    )
                };
        }
    }
}
