using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Forum.Application.ApplicationServices.Commands
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
    }
}
