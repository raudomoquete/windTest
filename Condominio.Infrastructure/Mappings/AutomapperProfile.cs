using AutoMapper;
using Condominio.Core.DTOs;
using Condominio.Core.Entities;

namespace Condominio.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<Residential, ResidentialDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();

            CreateMap<Due, DueDto>().ReverseMap();

            CreateMap<Status, StatusDto>().ReverseMap();
        }
    }
}
