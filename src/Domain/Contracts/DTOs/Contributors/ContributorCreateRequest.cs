﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.DTOs.Contributors
{
    public class ContributorCreateRequest
    {
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Estatus { get; set; }
        public string Active { get; set; }
    }
}
