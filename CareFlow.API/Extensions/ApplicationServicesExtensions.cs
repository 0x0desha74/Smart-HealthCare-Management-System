using CareFlow.API.Errors;
using CareFlow.API.Helper;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Repository.Repositories;
using CareFlow.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CareFlow.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));
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
