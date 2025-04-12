using AutoMapper;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;

namespace CareFlow.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<Patient, PatientToReturnDto>();
            CreateMap<PhoneDto, Phone>().ReverseMap();
            CreateMap<Phone, PhoneToReturnDto>();
            CreateMap<AllergyDto, Allergy>().ReverseMap();
            CreateMap<Allergy, AllergyToReturnDto>();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDetailsDto>().ReverseMap();
            CreateMap<Appointment, AppointmentToReturnDto>()
                .ForMember(d => d.Clinic, O => O.MapFrom(s => s.Clinic.Name))
                .ForMember(d => d.Patient, O => O.MapFrom(s => $"{s.Patient.FirstName} {s.Patient.LastName}"))
                .ForMember(d => d.Doctor, O => O.MapFrom(s => $"{s.Doctor.FirstName} {s.Doctor.LastName}"));
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
            CreateMap<Clinic, ClinicDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Clinic, ClinicToReturnDto>();
            CreateMap<Location, LocationToReturnDto>();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, DoctorToReturnDto>().ReverseMap();

        }
    }
}
