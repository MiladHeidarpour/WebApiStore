using Application.Dtos;
using Application.Dtos.CatalogTypes;
using Application.Interfaces.Contexts;
using AutoMapper;
using Common;
using Domain.Catalogs;

namespace Application.Catalogs.CatalogTypes.CrudService;

public class CatalogTypeService : ICatalogTypeService
{
    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;

    public CatalogTypeService(IDataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
    {
        var model = _mapper.Map<CatalogType>(catalogType);
        _context.CatalogTypes.Add(model);
        _context.SaveChanges();
        return new BaseDto<CatalogTypeDto>(true, new List<string> { $"تایپ {model.Type}  با موفقیت در سیستم ثبت شد" }, _mapper.Map<CatalogTypeDto>(model));
    }

    public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
    {
        var model = _context.CatalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
        _mapper.Map(catalogType, model);
        _context.SaveChanges();
        return new BaseDto<CatalogTypeDto>(true, new List<string> { $"تایپ {model.Type} با موفقیت ویرایش شد" }, _mapper.Map<CatalogTypeDto>(model));
    }

    public BaseDto<CatalogTypeDto> FindById(int Id)
    {
        var data = _context.CatalogTypes.Find(Id);
        var result = _mapper.Map<CatalogTypeDto>(data);
        return new BaseDto<CatalogTypeDto>(true, null, result);
    }

    public PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
    {
        int totalCount = 0;
        var model = _context.CatalogTypes
            .Where(p => p.ParentCatalogTypeId == parentId)
            .PagedResult(page, pageSize, out totalCount);
        var result = _mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
        return new PaginatedItemsDto<CatalogTypeListDto>(page, pageSize, totalCount, result);
    }

    public BaseDto Remove(int Id)
    {
        var catalogType = _context.CatalogTypes.Find(Id);
        _context.CatalogTypes.Remove(catalogType);
        _context.SaveChanges();
        return new BaseDto(true, new List<string> { $"ایتم با موفقیت حذف شد" });
    }
}