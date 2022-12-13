# share_content_backend

## Start
  - step 1: Create an app in [Linkedin Developer Portal](https://www.linkedin.com/developers/apps)
  - step 2: With app created go to Auth > OAuth Settings > add redirect URL ( _Ex: http: localhost:3000/myApp_ )

[more details](https://learn.microsoft.com/en-us/linkedin/shared/authentication/authorization-code-flow?context=linkedin%2Fconsumer%2Fcontext&tabs=HTTPS1)

## .Env File
  - Copy your keys from last step: Client Id, Client Secret, Redirect_Url and add to file.

<hr>

# API
## Authentication Api

  **/authorization**: Return a URL formatted with client_id and object scope to get access token in the next api step
    
    This endpoint will call linkedin signIn account and authorize app to post.
    After login will redirect to URL in the file .Env and registered in the app.

  **/accesstoken**: Return an [Person object](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Response/PersonResponse.cs)

    This endpoint expect the code returned in url response from last step
    Send a url with the code/client id/client secret
Receive an [Access token object](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/AccessToken.cs) and set in header

  
[more details](https://learn.microsoft.com/en-us/linkedin/shared/authentication/client-credentials-flow?context=linkedin%2Fconsumer%2Fcontext)

## Post Api

  **/linkedin**: Return the [Post indentify](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Post/PostIdentify.cs)

   This endpoint expect an [Post](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Post/PostAttributes.cs)

<hr>

# Post Services

**GetUploadUrlToRegisterImage(string id)**
  - Expect: the person account identification
  - Return: [Register image](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Response/LinkedinShare/RegisterImageResponse.cs) object

**RegisterImageOnLinkedIn( string uploadUrl, [PostAttributes](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Post/PostAttributes.cs) postAttributes )**
  - Expect: the upload url received in the last method, and the post to register the image in linkedIn

**SharePost( string id, PostAttributes postAttributes, string asset )**
  - Expect: the person account identification,
    [PostAttributes](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Post/PostAttributes.cs)
    and asset received in [Register image](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Response/LinkedinShare/RegisterImageResponse.cs) from the first method.
  - Return the [Post indentify](https://github.com/brunoo-p/share_content_backend/blob/master/Infrastructure/Entity/Post/PostIdentify.cs)

[more details](https://learn.microsoft.com/en-us/linkedin/consumer/integrations/self-serve/share-on-linkedin?context=linkedin%2Fconsumer%2Fcontext)
