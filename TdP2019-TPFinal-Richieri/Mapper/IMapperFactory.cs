using System;
namespace TdP2019TPFinalRichieri.Mapper
{
    using AutoMapper;

    public interface IMapperFactory
    {
        IMapper GetMapper();
    }
}
