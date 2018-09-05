using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using myTestAngular.Interfaces;
using myTestAngular.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace myTestAngular.Data
{
    public class PointSheetRepository : IRepository<PointSheet>
    {
        private readonly Context _context = null;
        public PointSheetRepository (IOptions<Settings> settings) {
            _context = new Context (settings);
        }

        public async Task Add(PointSheet item)
        {
            try {
                await _context.PointSheets.InsertOneAsync(item);
            } catch (Exception ex) {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<List<PointSheet>> GetAll()
        {
            try
            {
                return await _context.PointSheets.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<PointSheet> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}