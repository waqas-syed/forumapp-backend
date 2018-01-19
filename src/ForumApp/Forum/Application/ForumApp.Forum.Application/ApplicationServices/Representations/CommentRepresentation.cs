using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Forum.Application.ApplicationServices.Representations
{
    /// <summary>
    /// Comment Representation for the outside world
    /// </summary>
    public class CommentRepresentation
    {
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public string PostId { get; set; }
    }
}
