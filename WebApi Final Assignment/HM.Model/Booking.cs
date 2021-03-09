using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Model
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public System.DateTime Bookingdate { get; set; }
        public int Roomid { get; set; }
        public int IsActive { get; set; }
        public virtual Room Room { get; set; }
    }
}
