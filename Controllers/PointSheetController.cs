using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myTestAngular.Interfaces;
using myTestAngular.Models;

namespace myTestAngular.Controllers
{
    [Route ("api/[controller]")]
    public class PointSheetController : Controller
    {
        private readonly IRepository<PointSheet> _pointSheetRepository;
        public PointSheetController (IRepository<PointSheet> pointSheetRepository) {
            _pointSheetRepository = pointSheetRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PointSheet>> GetAll () {            
            return await _pointSheetRepository.GetAll();
        }

        [HttpPost]
        public async Task Save (PointSheet item) {
            await _pointSheetRepository.Add(item);
        }
    }
}