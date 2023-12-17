using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using aspnet.dto;
using AutoMapper;

namespace aspnet.Mappings
{
    // SneakerProfile is a class responsible for defining AutoMapper mappings
    public class SneakerProfile : Profile
    {
        // Constructor for SneakerProfile
        public SneakerProfile()
        {
            // CreateMap is used to define a mapping between source and destination types

            // CreateMap for mapping from Sneaker to SneakerReadDto
            CreateMap<Sneaker, SneakerReadDto>();

            // CreateMap for mapping from SneakerWriteDto to Sneaker
            CreateMap<SneakerWriteDto, Sneaker>();

            // CreateMap for mapping from SneakerUpdateDto to Sneaker
            CreateMap<SneakerUpdateDto, Sneaker>();
            // No implementaion of update in the MAUI app
        }
    }
}
