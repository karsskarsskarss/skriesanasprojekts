﻿using Microsoft.EntityFrameworkCore;
using mvcprojekts.Data;
using mvcprojekts.Interfaces;
using mvcprojekts.Models;
using mvcprojekts.Extensions;

namespace mvcprojekts.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByZipCode(int zipCode)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Zip == zipCode);
        }
        public async Task<List<City>> GetLocationSearch(string location)
        {
            List<City> result;
            if (location.Length > 0 && char.IsDigit(location[0]))
            {
                return await _context.Cities.Where(x => x.Zip.ToString().StartsWith(location)).Take(4).Distinct().ToListAsync();
            }
            else if (location.Length > 0)
            {
                result = await _context.Cities.Where(x => x.CityName == location).Take(10).ToListAsync();
            }
            result = await _context.Cities.Where(x => x.RegionCode == location).Take(10).ToListAsync();

            return result;
        }
    }
}