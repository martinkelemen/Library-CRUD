using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLibrary.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IPersonLogic logic;

        public WorkerController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Worker> GetAll()
        {
            return this.logic.GetAllWorkers();
        }

        [HttpGet("{id}")]
        public Worker GetOne(int id)
        {
            return this.logic.GetWorkerById(id);
        }

        [HttpPost]
        public void Create([FromBody] Worker value)
        {
            this.logic.AddWorker(value);
        }

        [HttpPut("{id}")]
        public void UpdateSalary(int id, [FromBody] int value)
        {
            this.logic.ChangeWorkerSalary(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteWorker(id);
        }
    }
}
