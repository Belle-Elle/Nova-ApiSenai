﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaApi_SenaiHotspot.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NIF { get; set; }
        public string Senha { get; set; }

    }
}
