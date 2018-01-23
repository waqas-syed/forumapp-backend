using ForumApp.Common.Domain.Model;
using System.Collections.Generic;

namespace ForumApp.Forum.Domain.Model.PostAggregate
{
    /// <summary>
    /// The post that can be posted on our forum
    /// The aggregate root for this aggregate, the main component of our forum. Following the Domain Driven Design
    /// pattern, only the aggregate root can make changes in any entity contained within the aggregate, not anyone
    /// else. That's why any changes to the Post or Comment entity will be made through this entity only
    /// </summary>
    public class Post : Entity
    {
        // Using private fields for only those attributes who have validations before being assigned new
        // values
        private string _title;
        private string _description;
        private string _posterEmail;
        private IList<Comment> _comments;

        public Post()
        {
            
        }

        public Post(string title, string description, string category, string posterEmail)
        {
            Title = title;
            Description = description;
            Category = category;
            PosterEmail = posterEmail;
            Comments = new List<Comment>();
        }

        public void Update(string newTitle, string newDescripion, string newCategory)
        {
            Title = newTitle;
            Description = newDescripion;
            Category = newCategory;
        }

        public void AddNewComment(string authorId, string text)
        {
            var comment = new Comment(authorId, text, this);
            Comments.Add(comment);
        }

        public string Title
        {
            get { return _title; }
            // Keeping the setter private so no other entity can change this value other than this entity itself
            private set
            {
                // Only assign when the incoming value is not nul or empty, otherwise raise an exception
                Assertion.AssertStringNotNullorEmpty(value);
                _title = value;
            }
        }

        /// <summary>
        /// Description of the Post
        /// </summary>
        public string Description
        {
            get { return _description; }
            // Keeping the setter private so no other entity can change this value other than this entity itself
            private set
            {
                // Only assign when the incoming value is not nul or empty, otherwise raise an exception
                Assertion.AssertStringNotNullorEmpty(value);
                _description = value;
            }
        }

        public string Category
        {
            get;
            // Keeping the setter private so no other entity can change this value other than this entity itself
            private set; 
        }

        public string PosterEmail
        {
            get { return _posterEmail; }
            // Keeping the setter private so no other entity can change this value other than this entity itself
            private set
            {
                // Only assign when the incoming value is not null or empty, otherwise raise an exception
                Assertion.AssertStringNotNullorEmpty(value);
                _posterEmail = value;
            }
        }

        public virtual IList<Comment> Comments
        {
            /*get { return _comments; }
            private set { _comments = value; } */
            get;
            set;
        }
    }
}
