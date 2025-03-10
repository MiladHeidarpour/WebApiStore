using Application.Catalogs.CatalogTypes.CrudService;
using Application.Dtos.CatalogTypes;
using AutoMapper;
using Infrastructure.MappingProfile;
using UnitTest.Builders;

namespace UnitTest.Core.Applications.CatalogTypeTest;

public class GetListTest
{
    [Fact]
    public void List_should_return_list_of_catalogtypes()
    {
        //Arrange
        var dataBasebuilder = new DatabaseBuilder();
        var dbContext = dataBasebuilder.GetDbContext();

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CatalogMappingProfile());
        });
        var mapper = mockMapper.CreateMapper();

        var service = new CatalogTypeService(dbContext, mapper);

        service.Add(new CatalogTypeDto
        {
            Id = 1,
            Type = "t1"
        });
        service.Add(new CatalogTypeDto
        {
            Id = 2,
            Type = "t21"
        });

        var result = service.GetList(null, 1, 20);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

    }
}