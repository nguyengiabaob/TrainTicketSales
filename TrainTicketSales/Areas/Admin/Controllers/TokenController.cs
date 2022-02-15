using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


using TrainTicketSales.Helpers;
using TrainTicketSales.ModelsViews;
using TrainTicketSales.Interfaces;

namespace TrainTicketSales.Controllers
{
    [Route("api/[controller]")]
    [Area("Admin")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IUsersService _userService;

        private readonly IGeneral _general;
        public TokenController(IUsersService userService, IGeneral general)
        {
            _userService = userService;
            _general = general;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult EncodeToken(AuthenticateModel model)
        {

            //var pass = _userService.EnCryptWebServiceTicket(model.Password);
            var pass = _general.Encrypt(model.Password, true);
            var user = _userService.EncodeToken(model.Username, pass);

            if (user == null)
                return Ok(new TokenModel { Token = "" });

            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        public IActionResult DecodeToken()
        {
            var re = Request;
            var headers = re.Headers;
            string a = headers["Authorization"];

            var users = _userService.DecodeToken(a);
            return Ok(users);
        }
        
    }
}
