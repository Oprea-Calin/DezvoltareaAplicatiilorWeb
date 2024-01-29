﻿using Lab9.Models.Base;
using Proiect.Data.DTOs;

namespace Proiect.Data.Models
{
    public class Provider: BaseEntity
    {
        public string? Nume { get; set; }
        public string? Adresa {  get; set; }
        public int? CUI {  get; set; }
        public Articol? articol { get; set; }
       // public Guid articolID { get; set; }

    }
}