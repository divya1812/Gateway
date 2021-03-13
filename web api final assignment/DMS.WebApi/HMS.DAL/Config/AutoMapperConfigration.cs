using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Config
{
    public class AutoMapperConfigration
    {
 
        public static void Configure()
        {
            Mapper.Initialize(x=>x.AddProfile<MappingProfile>());
        }

    }
}
