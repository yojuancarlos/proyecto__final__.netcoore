using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class PropertyOwnerModel
    {
        new public int Id { get; set; }
      
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        
        [DisplayName("Apellido")]
        public string FamilyName { get; set; }
        
        [DisplayName("Correo")]
        public string Email { get; set; }
        
        [DisplayName("Celular")]
        public string Cellphone { get; set; }
      
        [DisplayName("Foto")]
        public string Photo { get; set; }

       

        



    }
}