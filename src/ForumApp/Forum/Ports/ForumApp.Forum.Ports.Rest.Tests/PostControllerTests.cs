using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.ApplicationServices.Representations;
using ForumApp.Forum.Application.Ninject;
using ForumApp.Forum.Infrastructure.Persistence.Ninject;
using ForumApp.Forum.Ports.Rest.Controllers;
using ForumApp.Forum.Ports.Rest.Ninject;
using Newtonsoft.Json;
using Ninject;
using NUnit.Framework;

namespace ForumApp.Forum.Ports.Rest.Tests
{
    [TestFixture]
    public class PostControllerTests
    {
        private IKernel _kernel;

        [SetUp]
        public void Setup()
        {
            _kernel = new StandardKernel();
            _kernel.Load<ForumPersistenceNinjectModule>();
            _kernel.Load<ForumApplicationNinjectModule>();
            _kernel.Load<ForumPortsNinjectModule>();
        }

        [Test]
        public void SaveNewPostTest_TestsThatANewPostIsSavedAndRetreivedAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postController = _kernel.Get<PostController>();
            Assert.NotNull(postController);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postIdHttpContent = postController.Post(JsonConvert.SerializeObject(createPostCommand));
            string postId = ((OkNegotiatedContentResult<string>)postIdHttpContent).Content;

            IHttpActionResult response = (IHttpActionResult)postController.Get(postId);
            dynamic retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(title, retreivedPost.Title);
            Assert.AreEqual(description, retreivedPost.Description);
            Assert.AreEqual(category, retreivedPost.Category);
        }

        [Test]
        public void AddNewCommentsToPostTest_TestsThatANewCommentIsAddedToPostAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postController = _kernel.Get<PostController>();
            Assert.NotNull(postController);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postIdHttpContent = postController.Post(JsonConvert.SerializeObject(createPostCommand));
            string postId = ((OkNegotiatedContentResult<string>)postIdHttpContent).Content;

            IHttpActionResult response = (IHttpActionResult)postController.Get(postId);
            PostRepresentation retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);

            var authorId1 = "GandalfTheGrey";
            var text1 = "You shall not pass";
            AddCommentCommand addCommentCommand = new AddCommentCommand()
            {
                AuthorEmail = authorId1,
                PostId = postId,
                Text = text1
            };
            postController.PostComment(JsonConvert.SerializeObject(addCommentCommand));
            var authorId2 = "GandalfTheWhite";
            var text2 = "I have returned to finish the job";
            AddCommentCommand addCommentCommand2 = new AddCommentCommand()
            {
                AuthorEmail = authorId2,
                PostId = postId,
                Text = text2
            };
            postController.PostComment(JsonConvert.SerializeObject(addCommentCommand2));
            response = postController.Get(postId);
            retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(2, retreivedPost.Comments.Count);
            Assert.AreEqual(authorId1, retreivedPost.Comments[0].AuthorId);
            Assert.AreEqual(postId, retreivedPost.Comments[0].PostId);
            Assert.AreEqual(text1, retreivedPost.Comments[0].Text);
            Assert.AreEqual(authorId2, retreivedPost.Comments[1].AuthorId);
            Assert.AreEqual(postId, retreivedPost.Comments[1].PostId);
            Assert.AreEqual(text2, retreivedPost.Comments[1].Text);
        }

        [Test]
        public void UpdatePostTest_TestsThatAPostIsUpdatedAndRetreivedAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postController = _kernel.Get<PostController>();
            Assert.NotNull(postController);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postIdHttpContent = postController.Post(JsonConvert.SerializeObject(createPostCommand));
            string postId = ((OkNegotiatedContentResult<string>)postIdHttpContent).Content;

            IHttpActionResult response = (IHttpActionResult)postController.Get(postId);
            PostRepresentation retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);
            
            Assert.AreEqual(title, retreivedPost.Title);
            Assert.AreEqual(description, retreivedPost.Description);
            Assert.AreEqual(category, retreivedPost.Category);

            string title2 = "Post # 2";
            string description2 = "Description of Post # 2";
            string category2 = "Category of Post # 2";

            var updatePostCommand = new UpdatePostCommand()
            {
                Category = category2,
                Description = description2,
                Id = postId,
                Title = title2
            };

            postController.Put(JsonConvert.SerializeObject(updatePostCommand));

            response = (IHttpActionResult)postController.Get(postId);
            retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);

            Assert.AreEqual(title2, retreivedPost.Title);
            Assert.AreEqual(description2, retreivedPost.Description);
            Assert.AreEqual(category2, retreivedPost.Category);
        }

        [Test]
        public void SaveAndGetMultiplePostsTest_TestsThatMultiplePostsSavedAndRetreivedAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postController = _kernel.Get<PostController>();
            Assert.NotNull(postController);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            postController.Post(JsonConvert.SerializeObject(createPostCommand));

            // Post # 2
            string title2 = "Post # 2";
            string description2 = "Description of Post # 2";
            string category2 = "Category of Post # 2";
            var createPostCommand2 = new CreatePostCommand();
            createPostCommand2.Title = title2;
            createPostCommand2.Description = description2;
            createPostCommand2.Category = category2;
            postController.Post(JsonConvert.SerializeObject(createPostCommand2));

            // Post # 3
            string title3 = "Post # 3";
            string description3 = "Description of Post # 3";
            string category3 = "Category of Post # 3";
            var createPostCommand3 = new CreatePostCommand();
            createPostCommand3.Title = title3;
            createPostCommand3.Description = description3;
            createPostCommand3.Category = category3;
            postController.Post(JsonConvert.SerializeObject(createPostCommand2));
            
            IHttpActionResult response = (IHttpActionResult)postController.Get();
            IList<PostRepresentation> retreivedPosts = ((OkNegotiatedContentResult<IList<PostRepresentation>>)response).Content;
            Assert.NotNull(retreivedPosts);
            Assert.GreaterOrEqual(retreivedPosts.Count, 3);
        }

        [Test]
        public void DeletePostTest_TestsThatANewPostIsSavedAndThenDeletedAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postController = _kernel.Get<PostController>();
            Assert.NotNull(postController);
            string title = "Post # 1";
            string description = "Description of Post # 6";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postIdHttpContent = postController.Post(JsonConvert.SerializeObject(createPostCommand));
            string postId = ((OkNegotiatedContentResult<string>)postIdHttpContent).Content;

            IHttpActionResult response = (IHttpActionResult)postController.Get(postId);
            PostRepresentation retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.NotNull(retreivedPost);

            postController.Delete(postId);
            response = (IHttpActionResult)postController.Get(postId);
            retreivedPost = ((OkNegotiatedContentResult<PostRepresentation>)response).Content;
            Assert.IsNull(retreivedPost);
        }
    }
}
