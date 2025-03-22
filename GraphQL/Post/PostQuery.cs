using GraphQLDemo.repository;

namespace GraphQLDemo.GraphQL.Post;

public class PostQuery
{
    public async Task<List<context.Post>> GetEmployees([Service] PostRepository repository) =>
        await repository.GetAllEmployeeAsync();

    public async Task<context.Post> GetEmployee(int id, [Service] PostRepository repository) =>
        await repository.GetEmployeeAsync(id);
}