using KidsGaming.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KidsGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : GenericController<MemberShip>
    {
        public MembershipController(Interface.IGeneric<MemberShip> igenric) : base(igenric)
        {

        }
    }
}
