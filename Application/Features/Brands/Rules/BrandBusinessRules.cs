using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

     //Kodlarımızı dökümantasyon hazırlar gibi yazmalıyız. Projenin üstünden zaman geçince çalışan kodu hatırlamayız.
    public async Task BrandNameCannotBeDuplicatedWhenInsert(string name)
    {
        Brand? result = await _brandRepository.GetAsync(predicate:b=>b.Name.ToLower()==name.ToLower()); //farklı veritabanlarında büyük küçük harf duyarlılığı değişebiliir.
        if (result is not null)
        {
            throw new BusinessException(BrandsMessages.BrandNameExists); //Her hata türünü gruplandırmalısınız.
        }
    }
}
