using ForumApp.Common.Domain.Model;

namespace ForumApp.Forum.Domain.Model.PostAggregate
{
    /// <summary>
    /// Comments that can be made on the Post
    /// </summary>
    public class Comment
    {
        private string _authorId;
        private string _text;

        public string AuthorId
        {
            get { return _authorId; }
            set
            {
                Assertion.AssertStringNotNullorEmpty(value);
                _authorId = value;
            }
        }

        public string Text { get; set; }
    }
}
