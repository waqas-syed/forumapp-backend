using System.Collections.Generic;

namespace ForumApp.Forum.Application.ApplicationServices.Representations
{
    /// <summary>
    /// Representation for Post to the outside world
    /// </summary>
    public class PostRepresentation
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IList<CommentRepresentation> Comments { get; set; }
    }
}
