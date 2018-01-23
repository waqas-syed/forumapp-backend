using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Forum.Application.ApplicationServices.Commands
{
    [Serializable]
    public class AddCommentCommand
    {
        public string PostId { get; set; }
        public string AuthorEmail { get; set; }
        public string Text { get; set; }
    }
}
