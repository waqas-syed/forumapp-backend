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
        public void SaveNewPostTest_TestsThatANewPostIsSavedAndRetreovedAsExpected_VerifiesByDatabaseRetrieval()
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
        public void AddnewCommentsToPostTest_TestsThatANewPostIsSavedAndRetreovedAsExpected_VerifiesByDatabaseRetrieval()
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

            var authorId1 = "GandalfTheWhite";
            var text1 = "I have returned to finish the job";
            AddCommentCommand addCommentCommand = new AddCommentCommand()
            {
                AuthorId = authorId1,
                PostId = postId,
                Text = text1
            };
            postController.PostComment(JsonConvert.SerializeObject(addCommentCommand));
            postController
        }
    }
}
