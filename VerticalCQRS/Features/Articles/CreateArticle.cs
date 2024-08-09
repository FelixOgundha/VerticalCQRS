using MediatR;

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

    }
}
