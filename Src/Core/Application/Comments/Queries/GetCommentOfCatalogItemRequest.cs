using Application.Comments.Commands;
using Application.Interfaces.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace Application.Comments.Queries;

public class GetCommentOfCatalogItemQuery:IRequest<List<GetCommentDto>>
{
    public int CatalogItemId { get; set; }
}

public class GetCommentOfCatalogItemQuerytHandler : IRequestHandler<GetCommentOfCatalogItemQuery, List<GetCommentDto>>
{
    private readonly IDataBaseContext _context;

    public GetCommentOfCatalogItemQuerytHandler(IDataBaseContext context)
    {
        _context = context;
    }

    public Task<List<GetCommentDto>> Handle(GetCommentOfCatalogItemQuery request, CancellationToken cancellationToken)
    {
        var comments = _context.CatalogItemComments.Where(p => p.CatalogItemId == request.CatalogItemId)
            .Select(p => new GetCommentDto()
            {
                Id = p.Id,
                Title = p.Title,
                Comment = p.Comment
            }).ToList();

        return Task.FromResult(comments);
    }
}
public class GetCommentDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
}