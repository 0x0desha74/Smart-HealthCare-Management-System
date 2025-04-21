using AutoMapper;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Entities;
using CareFlow.Data.Entities;

namespace CareFlow.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<Patient, PatientToReturnDto>();
            CreateMap<PatientRegisterDto, Patient>()
                .ForMember(d => d.FirstName, O => O.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, O => O.MapFrom(s => s.LastName))
                .ForMember(d => d.BirthDate, O => O.MapFrom(s => s.BirthDate))
                .ForMember(d => d.Gender, O => O.MapFrom(s => s.Gender)).ReverseMap();
            CreateMap<PatientRegisterDto, RegisterDto>();


            CreateMap<PhoneDto, Phone>().ReverseMap();
            CreateMap<Phone, PhoneToReturnDto>();

            CreateMap<AllergyDto, Allergy>().ReverseMap();
            CreateMap<Allergy, AllergyToReturnDto>();

            CreateMap<Appointment, AppointmentCreateDto>().ReverseMap();
            CreateMap<Appointment, AppointmentUpdateDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDetailsDto>().ReverseMap();
            CreateMap<Appointment, AppointmentToReturnDto>()
                .ForMember(d => d.Clinic, O => O.MapFrom(s => s.Clinic.Name))
                .ForMember(d => d.Patient, O => O.MapFrom(s => $"{s.Patient.FirstName} {s.Patient.LastName}"))
                .ForMember(d => d.Doctor, O => O.MapFrom(s => $"{s.Doctor.FirstName} {s.Doctor.LastName}"));

            CreateMap<Specialization, SpecializationDto>().ReverseMap();

            CreateMap<Clinic, ClinicDto>().ReverseMap();
            CreateMap<Clinic, ClinicToReturnDto>();

            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationToReturnDto>();

            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, DoctorToReturnDto>().ReverseMap();
            CreateMap<DoctorRegisterDto, Doctor>().ReverseMap();
            CreateMap<DoctorRegisterDto, RegisterDto>();

            CreateMap<PrescriptionToCreateDto, Prescription>();
            CreateMap<Prescription, PrescriptionToReturnDto>()
                .ForMember(d => d.Doctor, O => O.MapFrom(s => $"{s.Doctor.FirstName} {s.Doctor.LastName}"))
                .ForMember(d => d.Patient, O => O.MapFrom(s => $"{s.Patient.FirstName} {s.Patient.LastName}")).ReverseMap();

            CreateMap<Medicine, MedicineToReturnDto>();
            CreateMap<MedicineToCreateDto, Medicine>();
            CreateMap<MedicineToUpdateDto, Medicine>();

            CreateMap<PrescriptionToCreateDto, MedicalHistoryToCreateDto>();
            CreateMap<MedicalHistoryToCreateDto, MedicalHistory>();

            CreateMap<InstructionToCreateDto, Instruction>();
            CreateMap<Instruction, InstructionToReturnDto>();


        }
    }
}
