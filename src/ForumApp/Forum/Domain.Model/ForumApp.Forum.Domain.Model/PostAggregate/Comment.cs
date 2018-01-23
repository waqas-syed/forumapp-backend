using ForumApp.Common.Domain.Model;

namespace ForumApp.Forum.Domain.Model.PostAggregate
{
    /// <summary>
    /// Comments that can be made on the Post
    /// </summary>
    public class Comment : Entity
    {
        private string _authorId;
        private string _text;

        public Comment()
        {
            
        }

        public Comment(string authorEmail, string text, Post post)
        {
            AuthorEmail = authorEmail;
            Text = text;
            Post = post;
        }

        public string AuthorEmail
        {
            get { return _authorId; }
            private set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _authorId = value;
            }
        }

        public string Text
        {
            get { return _text; }
            private set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _text = value;
            }
        }

        // This is only used by EntityFramework to honor the relationship with Post
        public string PostId { get; private set; }
        public virtual Post Post { get; private set; }
    }
}
