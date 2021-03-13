using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using HMS.DAL.Repositories;
using HMS.DAL.Repositories.Interfaces;

namespace DMS.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {   
            Container.RegisterType<IHotelRepository,HotelRepository>();
            Container.RegisterType<IRoomRepository,RoomRepository>();
            Container.RegisterType<IBookingRepository,BookingRepository>();

        }
    }
}
