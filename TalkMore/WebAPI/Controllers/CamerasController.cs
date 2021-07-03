using Data;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamerasController : ControllerBase
    {
        private readonly ILogger<CamerasController> _logger;

        public CamerasController(ILogger<CamerasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Camera> Get()
        {
            return Importer.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public IEnumerable<Camera> Get(int id)
        {
            return Importer.GetByID(id).ToList();
        }

    }
}
