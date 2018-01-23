using ForumApp.Forum.Application.ApplicationServices;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Web.Http;

namespace ForumApp.Forum.Ports.Rest.Controllers
{
    /// <summary>
    /// Api Handler for the Post related operations
    /// </summary>
    [RoutePrefix("v1")]
    public class PostController : ApiController
    {
        private IPostApplicationService _postApplicationService;

        public PostController(IPostApplicationService postApplicationService)
        {
            _postApplicationService = postApplicationService;
        }

        [Route("post")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody]object createPostCommandJson)
        {
            try
            {
                // Null reference check
                if (createPostCommandJson != null)
                {
                    var createPostCommand = JsonConvert.DeserializeObject<CreatePostCommand>(createPostCommandJson.ToString());
                    // Save the new Post
                    return Ok(_postApplicationService.SaveNewPost(createPostCommand, GetEmailFromClaims()));
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        [Route("post")]
        [HttpPut]
        [Authorize]
        [AcceptVerbs(new string[] { "OPTIONS", "PUT" })]
        public IHttpActionResult Put([FromBody] Object updatePostCommandJson)
        {
            try
            {
                if (updatePostCommandJson != null)
                {
                    var updatePostCommand = JsonConvert.DeserializeObject<UpdatePostCommand>(updatePostCommandJson.ToString());
                    // Update the requested Post
                    _postApplicationService.UpdatePost(updatePostCommand, GetEmailFromClaims());
                    return Ok();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        [Route("post")]
        [HttpGet]
        public IHttpActionResult Get(string postId = null)
        {
            try
            {
                // If Id is given, then return that specific Post
                if (!string.IsNullOrEmpty(postId))
                {
                    return Ok(_postApplicationService.GetPostById(postId));
                }
                // Otherwise return all the Posts
                else
                {
                    return Ok(_postApplicationService.GetAllPosts());
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }

        [Route("post/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                _postApplicationService.DeletePost(id, GetEmailFromClaims());
                return Ok();
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }

        #region Comment related calls

        [Route("post/{id}/comment")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostComment([FromBody]object addCommentCommandJson)
        {
            try
            {
                // Null reference check
                if (addCommentCommandJson != null)
                {
                    var addCommentCommand = JsonConvert.DeserializeObject<AddCommentCommand>(addCommentCommandJson.ToString());
                    // Add the new Comment
                    _postApplicationService.AddCommentToPost(addCommentCommand, GetEmailFromClaims());
                    return Ok();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        #endregion
        
        #region Private helper Methods

        /// <summary>
        /// Get the email address, either from Identity.Name or ClaimsIdentity's email address
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        private string GetEmailFromClaims()
        {
            if (!string.IsNullOrWhiteSpace(User.Identity?.Name))
            {
                return User.Identity.Name;
            }
            else
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    var email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        return email;
                    }
                }
                return null;
            }
        }

        #endregion
    }
}
