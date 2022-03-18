using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyLibrary.Data;
using MyLibrary.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;

        public WorkerController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("WorkerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Worker value)
        {
            this.logic.UpdateWorker(value);
            this.hub.Clients.All.SendAsync("WorkerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var workerToDelete = this.logic.GetWorkerById(id);
            this.logic.DeleteWorker(id);
            this.hub.Clients.All.SendAsync("WorkerDeleted", workerToDelete);
        }
    }
}
