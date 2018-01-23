using ForumApp.Forum.Application.ApplicationServices;
using System;
using System.Web.Http;

namespace ForumApp.Forum.Ports.Rest.Controllers
{
    /// <summary>
    /// Handles all API operations related to Categories
    /// </summary>
    [RoutePrefix("v1")]
    public class CategoryController : ApiController
    {
        private ICategoryApplicationService _categoryApplicationService;

        public CategoryController(ICategoryApplicationService categoryApplicationService)
        {
            _categoryApplicationService = categoryApplicationService;
        }

        
        [Route("category")]
        [HttpGet]
        //[Authorize]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_categoryApplicationService.GetAllCategories());
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}
