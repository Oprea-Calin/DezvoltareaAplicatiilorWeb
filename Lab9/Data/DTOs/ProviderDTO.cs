﻿using Proiect.Data.Models;

namespace Proiect.Data.DTOs
{
    public class ProviderDTO
    {
        public string Name {  get; set; }
        public string Adresa { get; set; }
        public int CUI { get; set; }
        public Articol articol { get; set; }
    }
}
