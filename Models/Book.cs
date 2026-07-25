namespace CSE325_Group_Project.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime DateReleased { get; set; }
        public string Author { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public int Rating { get; set; }
        public bool IsLiked { get; set; }
    }
}
