using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyModel
    {

        [DisplayName("propiedad")]
        public int Id { get; set; }

        [DisplayName("PropertyAddress")]
       
    

        public string PropertyAddress { get; set; }

        [DisplayName("Descripción")]
        public string PropertyDescription { get; set; }

        [DisplayName("Precio")]
        public int Price { get; set; }

        [DisplayName("Latitude")]
        public string Latitude { get; set; }
        [DisplayName("Lomgitude")]
        public string Longitude { get; set; }

        [DisplayName("fechaentrada")]
        public string CheckinData { get; set; }
        [DisplayName("fechasalida")]
        public string CheckoutData { get; set; }

        [DisplayName("detalles")]
        public string Details { get; set; }


        [DisplayName("mascotas")]
        public bool Pets { get; set; }

        [DisplayName("neveras")]
        public bool Freezer { get; set; }

        [DisplayName("lavanderia")]
        public bool LaundryService { get; set; }


    
        public CityModel City { get; set; }

        public IEnumerable<CityModel> CityList { get; set; }

      
        public PropertyOwnerModel PropertyOwner { get; set; }

        public IEnumerable<PropertyOwnerModel> PropertyOwnerList { get; set; }

    }
}