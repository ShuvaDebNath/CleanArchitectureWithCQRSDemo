using AutoMapper;
using CRUD.Application.Commands.ClientCommands;
using CRUD.Application.Response;
using CRUD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<Client, CreateClientCommand>().ReverseMap();
            CreateMap<Client, EditClientCommand>().ReverseMap();
        }
    }
}
