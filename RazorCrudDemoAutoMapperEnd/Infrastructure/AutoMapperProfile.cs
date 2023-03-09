using AutoMapper;
using RazorCrudDemo_FACIT.Data;
using RazorCrudDemo_FACIT.Data.Viewmodels;

namespace RazorCrudDemo_FACIT.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Källa => Mål
            // CreateEmployeeViewModel => Employee
            CreateMap<CreateEmployeeViewModel, Employee>()
                .ReverseMap();

            // Källa => Mål
            // UpdateEmployeeViewModel => Employee
            CreateMap<UpdateEmployeeViewModel, Employee>()
                .ReverseMap();

        }
    }
}
