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
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			int length = 5;
			string merchantOrderId = "OD" + new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());

			IDictionary<string, object> options = new Dictionary<string, object>();
			options.Add("merchant_order_id", merchantOrderId);
			options.Add("amount", random.Next(1, 5) * 100);
			options.Add("currency", "INR");
			ViewData["merchant_order_id"] = merchantOrderId;

			var order = client.Order.Create(options);
			ViewData["OrderID"] = order.Id;
			ViewData["Amount"] = order.Amount;
			ViewData["access_id"] = Client.AccessID;
			return View();
		}

		public ActionResult Status()
		{
			Dictionary<string, string> superHeroDictionary = new Dictionary<string, string>
			{
				  {"Batman"        , "https://upload.wikimedia.org/wikipedia/en/thumb/2/22/Batman-DC-Comics.jpg/250px-Batman-DC-Comics.jpg"},
				  {"Superman"      , "https://upload.wikimedia.org/wikipedia/en/thumb/e/eb/SupermanRoss.png/250px-SupermanRoss.png"},
				  {"Aquaman"       , "https://upload.wikimedia.org/wikipedia/en/thumb/0/0a/Aquaman_issue_1%2C_the_new_52.jpg/220px-Aquaman_issue_1%2C_the_new_52.jpg"},
				  {"Spiderman"     , "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/Spiderman50.jpg/250px-Spiderman50.jpg"},
				  {"Wonder Woman"  , "https://upload.wikimedia.org/wikipedia/en/0/03/Wonder_Woman_%28DC_Rebirth%29.jpg"},
				  {"Iron Man"      , "https://i.annihil.us/u/prod/marvel//universe3zx/images/f/f5/IronMan_Head.jpg"},
				  {"Hulk"           , "https://upload.wikimedia.org/wikipedia/en/5/59/Hulk_%28comics_character%29.png"},
				  {"Captain America", "https://upload.wikimedia.org/wikipedia/en/thumb/9/91/CaptainAmerica109.jpg/250px-CaptainAmerica109.jpg"},
				  {"Falcon"         , "https://upload.wikimedia.org/wikipedia/en/thumb/2/2e/TheFalcon.jpg/250px-TheFalcon.jpg"},
				  {"Wasp"           , "https://upload.wikimedia.org/wikipedia/en/thumb/c/c0/AVEN071.jpg/250px-AVEN071.jpg"},
				  {"Quicksilver"    , "https://upload.wikimedia.org/wikipedia/en/thumb/6/6e/Quicksilver%21.jpg/250px-Quicksilver%21.jpg"},
				  {"Doctor Strange" , "https://upload.wikimedia.org/wikipedia/en/thumb/4/4f/Doctor_Strange_Vol_4_2_Ross_Variant_Textless.jpg/250px-Doctor_Strange_Vol_4_2_Ross_Variant_Textless.jpg"},
				  {"Hawkeye"        , "https://upload.wikimedia.org/wikipedia/en/thumb/9/99/Hawkeye_%28Clinton_Barton%29.png/220px-Hawkeye_%28Clinton_Barton%29.png"},
				  {"Wolverine"      , "https://upload.wikimedia.org/wikipedia/en/c/c8/Marvelwolverine.jpg"},
				  {"Black Widow"    , "https://i.annihil.us/u/prod/marvel//universe3zx/images/f/f9/BlackWidow.jpg"}

			};
			Random rand = new Random();
			var superHero = superHeroDictionary.ElementAt(rand.Next(0, superHeroDictionary.Count));

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
			client.Utility.VerifyPaymentSignature(options);

			return View();
		}

	}

}
