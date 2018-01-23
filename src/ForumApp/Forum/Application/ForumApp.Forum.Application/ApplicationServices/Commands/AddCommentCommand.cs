using System;

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
