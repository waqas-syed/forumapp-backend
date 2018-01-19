using ForumApp.Common.Domain.Model;
using ForumApp.Forum.Domain.Model.CategoryAggregate;
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
        private string _title;
        private string _description;
        private IList<Comment> _comments;

        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            Comments = new List<Comment>();
        }

        public void AddNewComment(Comment comment)
        {
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

        public IList<Category> Categories { get; set; }

        public IList<Comment> Comments
        {
            // We only show the Read-Only collection to the world outside of this entity, so that no one can
            // change it, thus honoring the Single Responsiblity principle
            //get { return new ReadOnlyCollection<Comment>(_comments); }
            get;
            set;
        }

        public bool Test { get; set; }
    }
}
