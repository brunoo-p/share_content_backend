using Infrastructure.Entity;
using Infrastructure.Entity.Post;

namespace Infrastructure.Interface
{
    public interface IPost
    {
        Task<CustomResponse> PostOnLinkedin( string id, PostAttributes postAttributes);
    }
}