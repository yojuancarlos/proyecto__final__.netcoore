using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class CityModel
    {
        [DisplayName("Ciudad")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
       
        public string Name { get; set; }


        
        public CountryModel Country { get; set; }

        public IEnumerable<CountryModel> CountryList { get; set; }
    }
}
