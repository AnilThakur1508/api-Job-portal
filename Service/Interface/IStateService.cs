﻿using AutoMapper;
using DataAccessLayer.Entity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IStateService
    {

        Task<IEnumerable<StateDto>> GetAllAsync();
        Task<StateDto> GetByIdAsync(Guid Id);
    }
}   

