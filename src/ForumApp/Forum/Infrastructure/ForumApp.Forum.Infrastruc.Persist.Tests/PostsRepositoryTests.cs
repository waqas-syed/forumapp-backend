using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.Ninject;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;
using Ninject;
using NUnit.Framework;

namespace ForumApp.Forum.Infrastruc.Persist.Tests
{
    [TestFixture]
    public class PostsRepositoryTests
    {
        private IKernel _kernel;

        [SetUp]
        public void Setup()
        {
            _kernel = new StandardKernel();
            _kernel.Load<ForumPersistenceNinjectModule>();
        }

        [Test]
        public void SaveNewPostTest_TestsThatANewPosttIsSavedToTheDatbaseCorrectly_VerifiesByRetrievingSavedObject()
        {
            IPostRepository postRepository = _kernel.Get<IPostRepository>();
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            Post post = new Post(title, description,category);
            postRepository.Add(post);
            var retrievedPost = postRepository.GetById(post.Id);
            Assert.NotNull(retrievedPost);
            Assert.AreEqual(title, retrievedPost.Title);
            Assert.AreEqual(description, retrievedPost.Description);
            Assert.AreEqual(category, retrievedPost.Category);
        }

        [Test]
        public void AddNewCommentToPostTest_TestsThatANewPosttIsSavedToTheDatbaseCorrectly_VerifiesByRetrievingSavedObject()
        {
            IPostRepository postRepository = _kernel.Get<IPostRepository>();
            string title = "Post # 1";
            string description = "Description of Post # 1";
            string category = "Category of Post # 1";
            Post post = new Post(title, description, category);
            postRepository.Add(post);
            var retrievedPost = postRepository.GetById(post.Id);
            Assert.NotNull(retrievedPost);
            Assert.AreEqual(title, retrievedPost.Title);
            Assert.AreEqual(description, retrievedPost.Description);
            Assert.AreEqual(category, retrievedPost.Category);

            // Now add a new comment
            var authorId = "GandalfTheWhite";
            var text = "I have returned to finish the job";
            post.AddNewComment(authorId, text);
            postRepository.Update(post);
            retrievedPost = postRepository.GetById(post.Id);
            Assert.NotNull(retrievedPost);
            Assert.AreEqual(1, retrievedPost.Comments.Count);
            Assert.AreEqual(authorId, retrievedPost.Comments[0].AuthorId);
            Assert.AreEqual(text, retrievedPost.Comments[0].Text);
        }
    }
}
