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
    public class RenterController : ControllerBase
    {
        IPersonLogic logic;
        IHubContext<SignalRHub> hub;

        public RenterController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Renter> GetAll()
        {
            return this.logic.GetAllRenters();
        }

        [HttpGet("{id}")]
        public Renter GetOne(int id)
        {
            return this.logic.GetRenterById(id);
        }

        [HttpPost]
        public void Create([FromBody] Renter value)
        {
            this.logic.AddRenter(value);
            this.hub.Clients.All.SendAsync("RenterCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Renter value)
        {
            this.logic.UpdateRenter(value);
            this.hub.Clients.All.SendAsync("RenterUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var renterToDelete = this.logic.GetRenterById(id);
            this.logic.DeleteRenter(id);
            this.hub.Clients.All.SendAsync("RenterDeleted", renterToDelete);
        }
    }
}
