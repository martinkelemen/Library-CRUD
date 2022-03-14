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
    public class RenterController : ControllerBase
    {
        IPersonLogic logic;

        public RenterController(IPersonLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut("{id}")]
        public void UpdateMembershipType(int id, [FromBody] string value)
        {
            this.logic.ChangeRenterMembershipType(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteRenter(id);
        }
    }
}
