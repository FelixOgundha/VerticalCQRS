using Carter;
using MediatR;
using VerticalCQRS.Data;
using VerticalCQRS.Entities;
using static VerticalCQRS.Features.Articles.CreateArticle;

namespace VerticalCQRS.Features.Articles
{
    public static class CreateArticle
    {
        public class Command : IRequest<Guid>
        {
            public string Title { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public List<string> Tags { get; set; } = new();
        }

        internal sealed class Handler : IRequestHandler<Command, Guid>
        {
            private readonly DataDbContext _context;

            public Handler(DataDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var article = new Article {
                    Id = new Guid(),
                    Title = request.Title, 
                    Content = request.Content,
                    CreatedOnUtc = DateTime.UtcNow,
                    Tags = request.Tags,
                };

                await _context.Articles.AddAsync(article);

                return article.Id;
            }
        }

     
       


    }
}
public class CreateArtcileEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/articles", async (Command command, ISender sender) =>
        {
            var articleId = await sender.Send(command);

            return Results.Ok(articleId);
        });
    }
}