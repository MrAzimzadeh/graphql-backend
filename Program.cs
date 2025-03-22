using Blogosphere.Data;
using GraphQLDemo.GraphQL.Post;
using GraphQLDemo.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));
// Add services to the container.
builder.Services.AddScoped<PostRepository>();

// Add authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-auth-server";
        options.Audience = "your-api";
    });

// Add authorization services
builder.Services.AddAuthorization();

// GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<PostQuery>()
    .AddMutationType<PostMutation>()
    .AddAuthorizationCore()
    ;

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL(path: "/");
app.UseHttpsRedirection();
app.Run();