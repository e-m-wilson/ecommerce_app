using System;
using AutoMapper;
using main.Domain;

namespace main.Service.Core;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
    }

}
