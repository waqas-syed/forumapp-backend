using System;
using System.Collections.Generic;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;

namespace ForumApp.Forum.Application.ApplicationServices
{
    /// <summary>
    /// Delivers all operations related to Posts
    /// </summary>
    public class PostApplicationService : IPostApplicationService
    {
        private IPostRepository _postRepository;

        public PostApplicationService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        /// <summary>
        /// Save a new Post
        /// </summary>
        /// <param name="createPostCommand"></param>
        public string SaveNewPost(CreatePostCommand createPostCommand)
        {
            var post = new Post(createPostCommand.Title,
                createPostCommand.Description,
                createPostCommand.Category);
            _postRepository.Add(post);
            return post.Id;
        }

        /// <summary>
        /// Update an existing post
        /// </summary>
        /// <param name="updatepostCommand"></param>
        public void UpdatePost(UpdatePostCommand updatepostCommand)
        {
            var post = _postRepository.GetById(updatepostCommand.Id);
            if (post == null)
            {
                throw new NullReferenceException(string.Format("Could not find a Post with ID:{0}", updatepostCommand.Id));
            }
            post.Update(updatepostCommand.Title, updatepostCommand.Description, updatepostCommand.Category);
            _postRepository.Update(post);
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="postId"></param>
        public void DeletePost(string postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
            {
                throw new NullReferenceException(string.Format("Could not find a Post with ID:{0}", postId));
            }
            _postRepository.Delete(post);
        }

        /// <summary>
        /// Get all the posts
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        /// <summary>
        /// Get a post by it's Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Post GetPostById(string postId)
        {
            return _postRepository.GetById(postId);
        }

        /// <summary>
        /// Add a new Comment to a Post
        /// </summary>
        /// <param name="addCommentCommand"></param>
        public void AddCommentToPost(AddCommentCommand addCommentCommand)
        {
            var post = _postRepository.GetById(addCommentCommand.PostId);
            if (post == null)
            {
                throw new NullReferenceException(string.Format("Could not find a Post with ID:{0}", addCommentCommand.PostId));
            }
            post.AddNewComment(addCommentCommand.AuthorId, addCommentCommand.Text);
        }
    }
}
