using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Controllers
{
    public class CartController : Controller
    {
        public const string CARTKEY = "cart";
        List<CartItemViewModel> GetCartItems () {

        var session = HttpContext.Session;
        string jsoncart = session.GetString (CARTKEY);
        if (jsoncart != null) {
            return JsonConvert.DeserializeObject<List<CartItemViewModel>> (jsoncart);
        }
        return new List<CartItemViewModel> ();
        }
        bool AddItem(CartItemViewModel item)
        {
            var cart = GetCartItems();
           var olditem= cart.Find(p => p.Id == item.Id);
            if(olditem != null)
            {
                cart.Remove(olditem);
            }
            else
            {
                cart.Add(item);
            }
          return  SaveCartSession(cart);
        }
        bool removeItem(CartItemViewModel item)
        {
            var cart = GetCartItems();
            var olditem = cart.Find(p => p.Id == item.Id);
            if (olditem != null)
            {
                cart.Remove(olditem);
            }
            return SaveCartSession(cart);
        }
        bool SaveCartSession(List<CartItemViewModel> ls)
        {
            try
            {
                var session = HttpContext.Session;
                string jsoncart = JsonConvert.SerializeObject(ls);
                session.SetString(CARTKEY, jsoncart);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        [HttpGet]
        public JsonResult ListCart ()
        {
            var cart = GetCartItems();

            return Json(new { status = true, result = cart });
        }
        [HttpPost]
        public JsonResult addItemCart (CartItemViewModel item)
        {
           if( AddItem(item)== true)
            {
                return Json(new { status =true });
            }
            else
            {
                return Json(new { status = false });
            }
           
        }
        [HttpPost]
        public JsonResult DeleteItemCart(CartItemViewModel item)
        {
            if (AddItem(item) == true)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }

        }

    }
}
