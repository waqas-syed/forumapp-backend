using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.ApplicationServices.Representations;
using System.Collections.Generic;

namespace ForumApp.Forum.Application.ApplicationServices
{
    /// <summary>
    /// application Service for Posts,
    /// </summary>
    public interface IPostApplicationService
    {
        /// <summary>
        /// Save a new Post. Retuns the Id of the new Post
        /// </summary>
        string SaveNewPost(CreatePostCommand createPostCommand, string currentUserEmail);

        /// <summary>
        /// Update a Post
        /// </summary>
        /// <param name="updatepostCommand"></param>
        void UpdatePost(UpdatePostCommand updatepostCommand, string currentUserEmail);

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="postId"></param>
        void DeletePost(string postId, string currentUserEmail);

        /// <summary>
        /// Get all the posts
        /// </summary>
        /// <returns></returns>
        IList<PostRepresentation> GetAllPosts();

        /// <summary>
        /// Get a Post by its ID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        PostRepresentation GetPostById(string postId);

        /// <summary>
        /// Add a new Comment to a Post
        /// </summary>
        /// <param name="addCommentCommand"></param>
        /// <param name="currentUserEmail"></param>
        void AddCommentToPost(AddCommentCommand addCommentCommand, string currentUserEmail);
    }
}
