using System;
namespace TdP2019TPFinalRichieri.Mapper.Profiles
{
    using AutoMapper;
    using DTO;
    using Entities;

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(destination => destination.Id,
                    map => map.MapFrom(source => source.Id)
                )
                .ForMember(destination => destination.Name,
                    map => map.MapFrom(source => source.Name)
                );
        }
    }
}
