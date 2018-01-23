using System;
using System.Collections.Generic;
using System.Linq;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.ApplicationServices.Representations;
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
        /// <param name="currentUserEmail"></param>
        public string SaveNewPost(CreatePostCommand createPostCommand, string currentUserEmail)
        {
            if (string.IsNullOrWhiteSpace(currentUserEmail))
            {
                throw new NullReferenceException("Couldn't verify current User's identity");
            }
            var post = new Post(createPostCommand.Title,
                createPostCommand.Description, createPostCommand.Category, currentUserEmail);
            _postRepository.Add(post);
            return post.Id;
        }

        /// <summary>
        /// Update an existing post
        /// </summary>
        /// <param name="updatepostCommand"></param>
        public void UpdatePost(UpdatePostCommand updatepostCommand, string currentUserEmail)
        {
            if (string.IsNullOrWhiteSpace(currentUserEmail))
            {
                throw new NullReferenceException("Couldn't verify current User's identity");
            }
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
        public void DeletePost(string postId, string currentUserEmail)
        {
            if (string.IsNullOrWhiteSpace(currentUserEmail))
            {
                throw new NullReferenceException("Couldn't verify current User's identity");
            }
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
        public IList<PostRepresentation> GetAllPosts()
        {
            return ConvertPostsToRepresentations(_postRepository.GetAll());
        }

        /// <summary>
        /// Get a post by it's Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public PostRepresentation GetPostById(string postId)
        {
            var post = _postRepository.GetById(postId);
            if (post != null)
            {
                return ConvertPostToRepresentation(post);
            }
            return null;
        }

        /// <summary>
        /// Add a new Comment to a Post
        /// </summary>
        /// <param name="addCommentCommand"></param>
        /// <param name="currentUserEmail"></param>
        public void AddCommentToPost(AddCommentCommand addCommentCommand, string currentUserEmail)
        {
            if (string.IsNullOrWhiteSpace(currentUserEmail))
            {
                throw new NullReferenceException("Couldn't verify current User's identity");
            }
            var post = _postRepository.GetById(addCommentCommand.PostId);
            if (post == null)
            {
                throw new NullReferenceException(string.Format("Could not find a Post with ID:{0}", addCommentCommand.PostId));
            }
            post.AddNewComment(addCommentCommand.AuthorEmail, addCommentCommand.Text);
            _postRepository.Update(post);
        }

        #region Helper Methods

        private IList<PostRepresentation> ConvertPostsToRepresentations(IList<Post> posts)
        {
            IList<PostRepresentation> postRepresentations = new List<PostRepresentation>();
            foreach (var post in posts)
            {
                postRepresentations.Add(ConvertPostToRepresentation(post));
            }
            return postRepresentations;
        }

        private PostRepresentation ConvertPostToRepresentation(Post post)
        {
            IList<CommentRepresentation> commentRepresentations = new List<CommentRepresentation>();
            if (post.Comments != null && post.Comments.Any())
            {
                foreach (var currentComment in post.Comments)
                {
                    commentRepresentations.Add(new CommentRepresentation()
                    {
                        AuthorId = currentComment.AuthorEmail,
                        PostId = currentComment.PostId,
                        Text = currentComment.Text
                    });
                }
            }
            return new PostRepresentation()
            {
                Id = post.Id,
                Category = post.Category,
                Description = post.Description,
                Title = post.Title,
                Comments = commentRepresentations
            };
        }

        #endregion Helper Methods
    }
}
