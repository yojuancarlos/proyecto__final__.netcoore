using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class ReservationDTO
    {

        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }

        public PropertyDTO Property { get; set; }
        public CustomerDTO Customer { get; set; }

    }
}
