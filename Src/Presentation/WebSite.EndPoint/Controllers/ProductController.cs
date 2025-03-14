using Application.Catalogs.CatalogItems.CatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Comments.Commands;
using Application.Comments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers;

public class ProductController : Controller
{
    private readonly IGetCatalogItemPLPService _catalogPLPService;
    private readonly IGetCatalogItemPDPService _catalogPDPService;
    private readonly IMediator _mediator;
    public ProductController(IGetCatalogItemPLPService catalogPLPService, IGetCatalogItemPDPService catalogPdpService, IMediator mediator)
    {
        _catalogPLPService = catalogPLPService;
        _catalogPDPService = catalogPdpService;
        _mediator = mediator;
    }

    public IActionResult Index(CatlogPLPRequestDto request)
    {
        var data = _catalogPLPService.Execute(request);
        return View(data);
    }

    public IActionResult Details(string slug)
    {
        var data = _catalogPDPService.Execute(slug);

        GetCommentOfCatalogItemQuery itemDto = new GetCommentOfCatalogItemQuery()
        {
            CatalogItemId = data.Id,
        };

        var result = _mediator.Send(itemDto).Result;

        return View(data);
    }

    public IActionResult SendComment(CommentDto commentDto, string slug)
    {
        SendCommentCommand sendComment = new SendCommentCommand(commentDto);
        var result = _mediator.Send(sendComment).Result;
        return RedirectToAction(nameof(Details), new { slug = slug });
    }
}