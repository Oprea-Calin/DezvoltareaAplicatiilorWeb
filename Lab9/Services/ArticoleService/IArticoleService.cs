﻿using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Proiect.Services.ArticoleService
{
    public interface IArticoleService
    {
        Task AddArticol(ArticolDTO articol);
        Task<List<Articol>> GetAllAsync();
    }
}
