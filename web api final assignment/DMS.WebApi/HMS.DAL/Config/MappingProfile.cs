using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HMS.Models;

namespace HMS.DAL.Config
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            //Database to Model
            Mapper.CreateMap<Database.Hotel,Hotel>();
            Mapper.CreateMap<Database.Room,Room>();
            Mapper.CreateMap<Database.Booking,Booking>();
            

            //Model to Database
            Mapper.CreateMap<Hotel,Database.Hotel>();
            Mapper.CreateMap<Room,Database.Room>();
            Mapper.CreateMap<Booking,Database.Booking>();

        }
    }
}
