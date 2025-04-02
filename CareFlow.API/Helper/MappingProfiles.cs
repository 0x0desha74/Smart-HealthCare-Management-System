using AutoMapper;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;

namespace CareFlow.API.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<Patient, PatientToReturnDto>();
            CreateMap<PhoneDto, Phone>().ReverseMap();
            CreateMap<Phone, PhoneToReturnDto>();
        }
    }
}
