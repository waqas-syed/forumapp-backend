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

        public Comment(string authorId, string text, Post post)
        {
            AuthorId = authorId;
            Text = text;
            Post = post;
        }

        public string AuthorId
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

        public string PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
