using Application.Catalogs.CatalogItems.CatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Comments.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.EndPoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IGetCatalogItemPLPService _catalogPLPService;
    private readonly IGetCatalogItemPDPService _catalogPDPService;
    private readonly IMediator _mediator;

    public ProductController(IGetCatalogItemPLPService catalogPlpService, IGetCatalogItemPDPService catalogPdpService, IMediator mediator)
    {
        _catalogPLPService = catalogPlpService;
        _catalogPDPService = catalogPdpService;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] CatlogPLPRequestDto request)
    {
        return Ok(_catalogPLPService.Execute(request));
    }

    [HttpGet]
    [Route("PDP")]
    public IActionResult Get([FromQuery] string slug)
    {
        return Ok(_catalogPDPService.Execute(slug));
    }

    [HttpPost]
    public IActionResult Post([FromBody] CommentDto commentDto)
    {
        SendCommentCommand sendComment = new SendCommentCommand(commentDto);
        var result = _mediator.Send(sendComment).Result;
        return Ok(result);
    }
}