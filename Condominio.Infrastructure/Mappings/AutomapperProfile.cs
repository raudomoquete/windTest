using AutoMapper;
using Condominio.Core.DTOs;
using Condominio.Core.Entities;

namespace Condominio.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Residential, ResidentialDto>();
            CreateMap<ResidentialDto, Residential>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            CreateMap<Due, DueDto>();
            CreateMap<DueDto, Due>();

            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();
        }
    }
}
