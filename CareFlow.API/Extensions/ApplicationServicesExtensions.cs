using CareFlow.API.Errors;
using CareFlow.API.Helper;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Repository.Repositories;
using CareFlow.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));
            services.AddScoped(typeof(IPhoneService), typeof(PhoneService));
            services.AddScoped(typeof(IAllergyService), typeof(AllergyService));
            services.AddScoped(typeof(IClinicService), typeof(ClinicService));
            services.AddScoped(typeof(ISpecializationService), typeof(SpecializationService));
            services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
            services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddAutoMapper(typeof(MappingProfiles));










            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {

                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count > 0)
                                                            .SelectMany(P => P.Value.Errors)
                                                            .Select(E => E.ErrorMessage)
                                                            .ToArray();



                    var validationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });


            return services;
        }
    }
}
