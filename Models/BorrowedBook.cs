namespace CSE325_Group_Project.Models;

public class BorrowedBook
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid BookId { get; set; }
    public Book? Book { get; set; }

    public DateTime BorrowedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnedDate { get; set; }
}