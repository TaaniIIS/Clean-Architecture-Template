﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HRLeaveManagement.Application.Profiles
{
    // This class inherits from AutoMapper's 'Profile' base class.
    // A 'Profile' is where you define all your object-to-object mappings.
    public class MappingProfile : Profile
    {
        // Constructor where all the mapping configurations are added.
        public MappingProfile()
        {
            // This mapping tells AutoMapper how to map between the 'Position' entity and the 'PositionDto'.
            // 'CreateMap<Source, Destination>()' automatically maps properties with the same names and types.
            // 'ReverseMap()' adds the reverse mapping as well, i.e., from PositionDto to Position.
        // CreateMap<Position, PositionDto>()
         //.ReverseMap();

            // Optional: You can customize mappings like this if property names don't match:
            // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }

}
