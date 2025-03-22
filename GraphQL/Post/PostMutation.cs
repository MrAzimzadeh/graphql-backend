using GraphQLDemo.repository;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Post;

public class PostMutation
{
    [Authorize]
    public async Task<context.Post> AddEmployee(AddMutation input, [Service] PostRepository repository)
    {
        var employee = await repository.AddEmployeeAsync(new context.Post()
        {
            Content = input.Content,
            Author = input.author,
            Title = input.Title
        });
        return employee;
    }
    /*
     *  Example Request
     * mutation {
         addEmployee(input: {
           author: "User",
           content: "Test",
           title: "Salammm",
           date: null
         }) {
           id
         }
       }
     *
     */
}

public record AddMutation(
    [GraphQLDescription("Post Title")]
    String Title,
    String author,
    String Content,
    DateTime? date);