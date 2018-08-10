using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Payabbhi;

namespace SuperHeroes.Controllers
{
	public class HomeController : Controller
	{
		Client client = new Client("<ACCESS-ID>", "<SECRET-KEY>");
		public ActionResult Index()
		{
			IDictionary<string, object> options = new Dictionary<string, object>();
			string merchantOrderId = Helpers.Extension.GenerateOrderID();
			int amount = Helpers.Extension.GenerateAmount();
			options.Add("merchant_order_id", merchantOrderId);
			options.Add("amount", amount);
			options.Add("currency", "INR");
			ViewData["merchant_order_id"] = merchantOrderId;

			ViewData["error"] = null;
			try
			{
				var order = client.Order.Create(options);
				ViewData["OrderID"] = order.Id;
				ViewData["Amount"] = order.Amount;
				ViewData["access_id"] = Client.AccessID;
			}
			catch (Exception e)
			{
				ViewData["error"] = e;
			}

			return View();
		}

		public ActionResult Status()
		{
			var superHero = Helpers.Extension.FetchSuperHero();
			//Retrieving the payment_id and merchant_order_id from the Payment Response
			ViewData["payment_id"] = Request.Form["payment_id"];
			ViewData["merchant_order_id"] = Request.Form["merchant_order_id"];
			ViewData["hero_name"] = superHero.Key;
			ViewData["hero_url"] = superHero.Value;

			IDictionary<string, string> options = new Dictionary<string, string>();

			//Step2 validation of payment signature
			options.Add("payment_signature", Request.Form["payment_signature"]);
			options.Add("order_id", Request.Form["order_id"]);
			options.Add("payment_id", Request.Form["payment_id"]);
			ViewData["error"] = null;

			//Step3 exception handling
			try
			{
				client.Utility.VerifyPaymentSignature(options);
			}
			catch (Exception e)
			{
				ViewData["error"] = e;
			}

			return View();
		}

	}

}
