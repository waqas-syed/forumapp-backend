using System;

namespace ForumApp.Common.Domain.Model
{
    public class Entity
    {
        private string _id = Guid.NewGuid().ToString();

        /// <summary>
        /// Unique GUID for every entity.
        /// </summary>
        public string Id
        {
            get { return _id; }
            private set { _id = value; }
        }
    }
}
