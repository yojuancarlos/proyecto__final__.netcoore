using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string PropertAddress { get; set; }
        public string PropertyDescription { get; set; }
        public int Price { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CheckinData { get; set; }
        public string CheckoutData { get; set; }
        public string Details { get; set; }
        public bool Pets { get; set; }
        public bool Freezer { get; set; }
        public bool LaundryService { get; set; }
        public CityDTO City { get; set; }
        public PropertyOwnerDTO PropertyOwner { get; set; }

    }
}
