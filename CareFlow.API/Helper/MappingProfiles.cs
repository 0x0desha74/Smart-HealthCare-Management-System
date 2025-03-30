using AutoMapper;
using CareFlow.Core.DTOs.In;
using CareFlow.Data.Entities;

namespace CareFlow.API.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();
        }
    }
}
