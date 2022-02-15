using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainTicketSales.Helpers;
using TrainTicketSales.Interfaces;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private IUsersService _userService;

        private readonly IGeneral _general;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IUsersService userService, IGeneral general, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _general = general;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            //return View();
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return (RedirectToAction("Login"));
            }

            //if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(),
            //    _config["Jwt:Issuer"].ToString(), token))
            //{
            //    return (RedirectToAction("Index"));
            //}

            //ViewBag.Message = BuildMessage(token, 50);
            return View();
        }

        public IActionResult Login(string Username, string Password)
        {
            if (Username != null)
            {

                if (Username.ToString() != "")
                {
                    //return View();
                    //var pass = _userService.EnCryptWebServiceTicket(model.Password);
                    var pass = _general.Encrypt(Password, true);
                    var user = _userService.EncodeToken(Username, pass);

                    if (user != null)
                    {
                        string domain = _httpContextAccessor.HttpContext.Request.Host.Value;
                        string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
                        string delimiter = System.Uri.SchemeDelimiter;
                        string fullDomainToUse = scheme + delimiter + domain;
                        HttpContext.Session.SetString("Token", user.Token);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return (RedirectToAction("Error"));
                    }
                }
            }
            return View();
        }
        public JsonResult Login1(string Username, string Password)
        {
            string domain = _httpContextAccessor.HttpContext.Request.Host.Value;
            string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            string delimiter = System.Uri.SchemeDelimiter;
            string fullDomainToUse = scheme + delimiter + domain;
            if (Username != null)
            {
                if (Username.ToString() != "")
                {
                    //return View();
                    //var pass = _userService.EnCryptWebServiceTicket(model.Password);
                    var pass = _general.Encrypt(Password, true);
                    var user = _userService.EncodeToken(Username, pass);

                    if (user != null)
                    {



                        HttpContext.Session.SetString("Token", user.Token);
                        return Json(new { status = true, result = fullDomainToUse + "/Admin/Home/Index" });
                    }
                    else
                    {
                        return Json(new { status = true, result = fullDomainToUse + "/Admin/Home/Login" });
                    }
                }
            }
            return Json(new { status = true, result = fullDomainToUse + "/Admin/Home/Login" });
        }
    }
}
