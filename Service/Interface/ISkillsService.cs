﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISkillsService
    {
        Task<IEnumerable<SkillsDto>> GetAllAsync();
        Task<IEnumerable<SkillsDto>> GetByCategoryAsync(Guid categoryId);


    }
}
