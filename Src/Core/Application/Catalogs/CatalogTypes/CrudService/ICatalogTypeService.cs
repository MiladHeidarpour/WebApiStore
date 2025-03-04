﻿using Application.Dtos;
using Application.Dtos.CatalogTypes;

namespace Application.Catalogs.CatalogTypes.CrudService;

public interface ICatalogTypeService
{
    BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
    BaseDto Remove(int Id);
    BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
    BaseDto<CatalogTypeDto> FindById(int Id);
    PaginatedItemsDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize);
}