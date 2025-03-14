using Application.Interfaces.Contexts;
using Domain.Catalogs;

namespace Application.Comments.Commands;
using MediatR;

public class SendCommentCommand:IRequest<SendCommentResponseDto>
{
    public SendCommentCommand(CommentDto comment)
    {
        Comment=comment;
    }
    public CommentDto Comment { get; set; }
}

public class SendCommentCommandHandler : IRequestHandler<SendCommentCommand, SendCommentResponseDto>
{
    private readonly IDataBaseContext _context;

    public SendCommentCommandHandler(IDataBaseContext context)
    {
        _context = context;
    }

    public Task<SendCommentResponseDto> Handle(SendCommentCommand request, CancellationToken cancellationToken)
    {
        var catalogItem = _context.CatalogItems.Find(request.Comment.CatalogItemId);

        CatalogItemComment comment = new CatalogItemComment()
        {
            Comment = request.Comment.Comment,
            Email = request.Comment.Email,
            Title = request.Comment.Title,
            CatalogItem = catalogItem,
        };
        var entity = _context.CatalogItemComments.Add(comment);
        _context.SaveChanges();
        return Task.FromResult(new SendCommentResponseDto()
        {
            Id = entity.Entity.Id,
        });
    }
}

public class CommentDto
{
    public string Title { get; set; }
    public string Comment { get; set; }
    public string Email { get; set; }
    public int CatalogItemId { get; set; }
}

public class SendCommentResponseDto
{
    public int Id { get; set; }
}