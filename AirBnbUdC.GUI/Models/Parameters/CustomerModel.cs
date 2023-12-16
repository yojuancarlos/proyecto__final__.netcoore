using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Models.Parameters
{
    public class CustomerModel
    {
        [DisplayName("Cliente")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string FirstName { get; set; }
        [DisplayName("Apellido")]
        public string FamilyName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [DisplayName("Foto")]
        public string Photo { get; set; }
    }


    




}