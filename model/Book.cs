using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace context;
public class Post
{
    [Key]
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string Author { get; set; }
    public ICollection<Comment> Comments { get; set; }

    public Post()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}

public class Comment
{
    [Key]
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Author { get; set; }

    [ForeignKey("PostId")]
    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public Comment()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}