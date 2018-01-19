namespace ForumApp.Forum.Application.ApplicationServices.Commands
{
    /// <summary>
    /// Update a post
    /// </summary>
    public class UpdatePostCommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
