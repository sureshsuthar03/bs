using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EntitiesLayer.Entities;
using EntitiesLayer.DTOs.Request;
using AutoMapper;

namespace BusinessAccessLayer.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().
                ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name)).
                ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email)).
                ForMember(dest => dest.Password, source => source.MapFrom(src => src.Password)).
                ForMember(dest => dest.Role, source => source.MapFrom(src => src.Role)).
                ForMember(dest => dest.Status, source => source.MapFrom(src => src.Status)).ReverseMap();
            
            CreateMap<User, UpdateUserDTO>().
                ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name)).
                ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email)).                
                ForMember(dest => dest.Role, source => source.MapFrom(src => src.Role)).
                ForMember(dest => dest.Status, source => source.MapFrom(src => src.Status)).ReverseMap();


            CreateMap<Product, ProductDTO>().
                ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name)).
                ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description)).
                ForMember(dest => dest.Category, source => source.MapFrom(src => src.Category)).
                ForMember(dest => dest.Price, source => source.MapFrom(src => src.Price)).ReverseMap();

            CreateMap<Invoice, InvoiceDTO>().
                ForMember(dest => dest.ProductId, source => source.MapFrom(src => src.ProductId)).
                ForMember(dest => dest.UserId, source => source.MapFrom(src => src.UserId)).
                ForMember(dest => dest.QuantitySold, source => source.MapFrom(src => src.QuantitySold)).
                ForMember(dest => dest.Amount, source => source.MapFrom(src => src.Amount)).
                ForMember(dest => dest.Discount, source => source.MapFrom(src => src.Discount)).
                ForMember(dest => dest.Tax, source => source.MapFrom(src => src.Tax)).
                ForMember(dest => dest.TotalAmount, source => source.MapFrom(src => src.TotalAmount)).
                ForMember(dest => dest.Date, source => source.MapFrom(src => src.Date)).ReverseMap();
        }
    }
}
