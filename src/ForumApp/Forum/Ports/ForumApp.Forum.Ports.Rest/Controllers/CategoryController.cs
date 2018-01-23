using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using Newtonsoft.Json;

namespace ForumApp.Forum.Ports.Rest.Controllers
{
    /// <summary>
    /// Handles all API operations related to Categories
    /// </summary>
    public class CategoryController : ApiController
    {
        [Route("post")]
        [HttpPost]
        //[Authorize]
        public IHttpActionResult Post([FromBody]object createPostCommandJson)
        {
            try
            {
                // Null reference check
                if (createPostCommandJson != null)
                {
                    var createPostCommand = JsonConvert.DeserializeObject<CreatePostCommand>(createPostCommandJson.ToString());
                    // Save the new Post
                    return Ok(_categoryApplicationService.SaveNewPost(createPostCommand, GetEmailFromClaims()));
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }
    }
}
