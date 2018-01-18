using System.Collections;
using System.Collections.Generic;
using ForumApp.Common.Domain.Model;
using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Domain.Model.CategoryAggregate
{
    /// <summary>
    /// Represents an association with the Post, which category the Post resides in
    /// </summary>
    public class Category : Entity
    {
        private string _name;
        public Category()
        {
            
        }

        public Category(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            // Keeping the setter private so no other entity can change this value other than this entity itself
            private set
            {
                // Only assign when the incoming value is not nul or empty, otherwise raise an exception
                Assertion.AssertStringNotNullorEmpty(value);
                _name = value;
            }
        }
    }
}
