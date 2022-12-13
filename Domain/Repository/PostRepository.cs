using Domain.Service;
using Domain.Service.Linkedin;
using Domain.Service.Storage;
using Infrastructure.Entity;
using Infrastructure.Entity.Post;
using Infrastructure.Entity.Request.LinkedinPost;
using Infrastructure.Entity.Request.LinkedinShare;
using Infrastructure.Entity.Response.LinkedinShare;
using Infrastructure.Enum;
using Infrastructure.Interface;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Domain.Repository
{
    public class PostRepository : IPost
    {

        private readonly HttpClientFactory _client;
        private readonly IHostEnvironment _environment;
        public PostRepository( HttpClientFactory _clientFactory, IHostEnvironment environment )
        {
            _client = _clientFactory;
            _environment = environment;
        }
        public async Task<CustomResponse> PostOnLinkedin( string id, PostAttributes postAttributes )
        {
            try
            {
                RegisterImageResponse responseUploadUrl_ToRegisterImage = await GetUploadUrlToRegisterImage(id);
                string uploadUrl = responseUploadUrl_ToRegisterImage.value.uploadMechanism.mediauploadhttprequest.uploadUrl;
                string asset = responseUploadUrl_ToRegisterImage.value.asset;


                var responseRegisterImage_ToMakePost = await RegisterImageOnLinkedIn(uploadUrl, postAttributes);
                var responsePostOnLinkedin = await SharePost(id, postAttributes, asset);

                return CustomResponseService.Mapping(
                    HttpStatusCode.Created,
                    responsePostOnLinkedin
                );
            }
            catch ( Exception err)
            {

                return CustomResponseService.Mapping(
                    HttpStatusCode.InternalServerError,
                    err.Message

                );
            }
        }

        private async Task<RegisterImageResponse> GetUploadUrlToRegisterImage( string id )
        {
            try
            {
                var post = new RegisterImageRequest(
                    new UploadRequest(Owner: id)
                );
                var url = $"{Environment.GetEnvironmentVariable("LINKEDIN_BASE_URL")}/assets?action=registerUpload";
                
                HttpRequestMessage request = _client.CreateRequest(HttpMethod.Post, url, post);
                RegisterImageResponse response = await _client.CallApi<RegisterImageResponse>(request);

                return response;
            }
            catch ( Exception )
            {
                throw;
            }
            
        }
        private async Task<CustomResponse> RegisterImageOnLinkedIn( string uploadUrl, PostAttributes postAttributes )
        {
            try
            {
                await SaveImageTemporaryOnStorage(postAttributes);
                var filePath = Path.Combine(_environment.ContentRootPath, "storage", postAttributes.file.FileName);

                HttpRequestMessage request = _client.CreateRequest<string>(HttpMethod.Post, uploadUrl);
                request.Content = new ByteArrayContent(File.ReadAllBytes(filePath.ToString()));

                var response = await _client.CallApi<string>(request);

                return CustomResponseService.Mapping(
                    HttpStatusCode.OK,
                    response
                );
            }
            catch ( Exception )
            {

                throw;
            }
        }
        private async Task<CustomResponse> SharePost( string id, PostAttributes postAttributes, string asset )
        {
            try
            {
                var url = $"{Environment.GetEnvironmentVariable("LINKEDIN_BASE_URL")}/ugcPosts";

                PostRequest post = MapPostService.WithImage(id, postAttributes, asset, MemberVisibility.PUBLIC);

                HttpRequestMessage request = _client.CreateRequest(HttpMethod.Post, url, post);
                PostIdentify response = await _client.CallApi<PostIdentify>(request);

                TemporaryStorageService.DeleteDirectory($"{Path.Combine(_environment.ContentRootPath)}/storage");

                return CustomResponseService.Mapping(HttpStatusCode.Created, response);
            }
            catch ( Exception )
            {

                throw;
            }
        }

        private async Task<CustomResponse> SaveImageTemporaryOnStorage( PostAttributes postAttributes )
        {
            try
            {
                var image = postAttributes.file;
                var directoryCreated = TemporaryStorageService.CreateDirectory($"{Path.Combine(_environment.ContentRootPath)}/storage");

                if ( directoryCreated )
                {
                    var filePath = Path.Combine(_environment.ContentRootPath, "storage", image.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await image.CopyToAsync(fileStream);

                }

                return
                    new CustomResponse(
                        HttpStatusCode.OK,
                        FormatString.ImageTitle(image.FileName)
                    );
            }
            catch ( Exception )
            {

                throw;
            }
            
        }
    }
}