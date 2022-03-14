using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ILibraryLogic logic;

        public StatController(ILibraryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IList<GroupByLanguage> GetRentalByLanguage()
        {
            return this.logic.GetRentByLanguage();
        }

        [HttpGet]
        public IList<GroupByMembership> GetRentalByMembership()
        {
            return this.logic.GetRentByMembership();
        }

        [HttpGet]
        public IList<RentalWithNames> GetAllRentsWithNames()
        {
            return this.logic.ListAllRents();
        }
    }
}
