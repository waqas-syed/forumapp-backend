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
            string email = "w@12345-1.com";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;
            createPostCommand.Email = email;

            var postId = postApplicationService.SaveNewPost(createPostCommand, email);
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
            string email = "wbgta@12345-1.com";
            var createPostCommand = new CreatePostCommand();
            createPostCommand.Title = title;
            createPostCommand.Description = description;
            createPostCommand.Category = category;
            createPostCommand.Email = email;

            var postId = postApplicationService.SaveNewPost(createPostCommand, email);
            var retreivedPost = postApplicationService.GetPostById(postId);
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(title, retreivedPost.Title);
            Assert.AreEqual(description, retreivedPost.Description);
            Assert.AreEqual(category, retreivedPost.Category);

            var authorId1 = "GandalfTheWhite";
            var text1 = "I have returned to finish the job";
            string emailComment1 = "welfgta@12345-1.com";
            postApplicationService.AddCommentToPost(new AddCommentCommand()
            {
                AuthorEmail = emailComment1,
                Text = text1,
                PostId = postId
            }, emailComment1);

            var authorId2 = "Aragorn";
            var text2 = "I have returned to my throne";
            string emailComment2 = "welfgta@12345-1.com";
            postApplicationService.AddCommentToPost(new AddCommentCommand()
            {
                AuthorEmail = emailComment2,
                Text = text2,
                PostId = postId
            }, emailComment2);

            retreivedPost = postApplicationService.GetPostById(postId);
            Assert.NotNull(retreivedPost);
            Assert.AreEqual(2, retreivedPost.Comments.Count);
            Assert.AreEqual(emailComment1, retreivedPost.Comments[0].AuthorEmail);
            Assert.AreEqual(text1, retreivedPost.Comments[0].Text);
            Assert.AreEqual(emailComment2, retreivedPost.Comments[1].AuthorEmail);
            Assert.AreEqual(text2, retreivedPost.Comments[1].Text);
        }
    }
}
