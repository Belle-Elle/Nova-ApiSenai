using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovaApi_SenaiHotspot.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o NIF do usuário!")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

    }
}
