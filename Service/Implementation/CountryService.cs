﻿using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.PortalRepository;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            return countries.Select(c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name,


            }).ToList();
        }

        public async Task<CountryDto> AddAsync(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.AddAsync(country);
            return countryDto;
        }

    }
}

