using Blogosphere.Data;
using context;
using Microsoft.EntityFrameworkCore;


namespace GraphQLDemo.repository;

public class PostRepository
{
    private readonly BlogDbContext _context;
    public PostRepository(BlogDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Post> AddEmployeeAsync(Post employee)
    {
        await _context.Posts.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task<Post> GetEmployeeAsync(int id)
    {
        var employee = await _context.Posts.FindAsync(id);
            
        if (employee == null)
        {
            throw new Exception($"Employee with id {id} not found.");
        }

        return employee;
    }

    public async Task<List<Post>> GetAllEmployeeAsync()
    {
        return await _context.Posts.ToListAsync();
    }

}