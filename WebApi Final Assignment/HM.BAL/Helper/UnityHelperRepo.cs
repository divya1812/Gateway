using HM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace HM.BAL.Helper
{
    public class UnityHelperRepo : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Ihotelrepo, Hotelrepo>();
        }
    }
}
