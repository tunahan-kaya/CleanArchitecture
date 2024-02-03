using Application.Features.Brands.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        /*
            eğer birisi brand ile createBrandCommand map etmek isterse onları maple.
            ReverseMap() ile de tam tersini de mapleyebiliriz. 
        */

        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();

    }
}
