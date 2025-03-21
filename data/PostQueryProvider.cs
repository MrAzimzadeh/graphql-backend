namespace Blogosphere.Data;

public class PostQueryProvider
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Post> GetPosts([Service] BlogDbContext context) => context.Posts;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Comment> GetComments([Service] BlogDbContext context) => context.Comments;



}

public class Mutation
{
    public async Task<Comment> AddCommentAsync(
        [Service] BlogDbContext context,
        string content,
        string author,
        int postId)
    {
        var post = await context.Posts.FindAsync(postId);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        var comment = new Comment
        {
            Content = content,
            Author = author,
            CreatedAt = DateTime.Now,
            Post = post
        };

        context.Comments.Add(comment);
        await context.SaveChangesAsync();

        return comment;
    }
}