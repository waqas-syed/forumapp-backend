using ForumApp.Forum.Application.ApplicationServices;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.Ninject;
using ForumApp.Forum.Infrastructure.Persistence.Ninject;
using Ninject;
using NUnit.Framework;

namespace ForumApp.Forum.Application.Tests
{
    [TestFixture]
    public class PostApplicationServiceTests
    {
        private IKernel _kernel;

        [SetUp]
        public void Setup()
        {
            _kernel = new StandardKernel();
            _kernel.Load<ForumPersistenceNinjectModule>();
            _kernel.Load<ForumApplicationNinjectModule>();
        }

        [Test]
        public void SaveNewPostTest_TestsThatANewPostIsSavedToTheDatabaseAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postApplicationService = _kernel.Get<IPostApplicationService>();
            Assert.NotNull(postApplicationService);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postId = postApplicationService.SaveNewPost(createPostCommand);
            var retreivedPost = postApplicationService.GetPostById(postId);
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(title, retreivedPost.Title);
            Assert.AreEqual(description, retreivedPost.Description);
            Assert.AreEqual(category, retreivedPost.Category);
        }

        [Test]
        public void AddNewCommentToPostTest_TestsThatANewCommentIsSavedToTheDatabaseAsExpected_VerifiesByDatabaseRetrieval()
        {
            var postApplicationService = _kernel.Get<IPostApplicationService>();
            Assert.NotNull(postApplicationService);
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;

            var postId = postApplicationService.SaveNewPost(createPostCommand);
            var retreivedPost = postApplicationService.GetPostById(postId);
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(title, retreivedPost.Title);
            Assert.AreEqual(description, retreivedPost.Description);
            Assert.AreEqual(category, retreivedPost.Category);

            var authorId1 = "GandalfTheWhite";
            var text1 = "I have returned to finish the job";
            postApplicationService.AddCommentToPost(new AddCommentCommand()
            {
                AuthorId = authorId1,
                Text = text1,
                PostId = postId
            });

            var authorId2 = "Aragorn";
            var text2 = "I have returned to my throne";
            postApplicationService.AddCommentToPost(new AddCommentCommand()
            {
                AuthorId = authorId2,
                Text = text2,
                PostId = postId
            });

            retreivedPost = postApplicationService.GetPostById(postId);
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(2, retreivedPost.Comments.Count);
            Assert.AreEqual(authorId1, retreivedPost.Comments[0].AuthorId);
            Assert.AreEqual(text1, retreivedPost.Comments[0].Text);
            Assert.AreEqual(authorId2, retreivedPost.Comments[1].AuthorId);
            Assert.AreEqual(text2, retreivedPost.Comments[1].Text);
        }
    }
}
