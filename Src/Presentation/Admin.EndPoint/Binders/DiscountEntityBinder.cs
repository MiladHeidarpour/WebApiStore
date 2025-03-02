using Application.Discounts.AddNewDiscountService;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Admin.EndPoint.Binders;

public class DiscountEntityBinder:IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext==null)
        {
            throw new ArgumentException(nameof(bindingContext));
        }

        string fieldName = bindingContext.FieldName;


        AddNewDiscountDto discountDto = new AddNewDiscountDto()
        {
            Name = bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.Name)}").Values.ToString(),

            UsePercentage = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),


            DiscountPercentage = int.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.DiscountPercentage)}").Values.ToString()),


            DiscountAmount = int.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),


            StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.StartDate)}").Values.ToString()),


            EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.EndDate)}").Values.ToString()),


            RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.RequiresCouponCode)}").FirstValue.ToString()),


            CouponCode = bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.CouponCode)}").Values.ToString(),


            DiscountTypeId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),

            DiscountLimitationId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),

            LimitationTimes = int.Parse(bindingContext.ValueProvider
                .GetValue($"{fieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),
        };
        var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.appliedToCatalogItem");

        if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
        {
            discountDto.appliedToCatalogItem =
                bindingContext.ValueProvider
                    .GetValue($"{fieldName}.{nameof(discountDto.appliedToCatalogItem)}")
                    .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
        }


        bindingContext.Result = ModelBindingResult.Success(discountDto);
        return Task.CompletedTask;
    }
}