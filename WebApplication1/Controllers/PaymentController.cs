using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeSetting _mySettings;
        private int amount = 10000;

        public PaymentController(IOptions<StripeSetting> appIdentitySettingsAccessor)
        {
            _mySettings = appIdentitySettingsAccessor.Value;
        }
        public IActionResult Index()
        {
            ViewBag.PaymentAmount = amount;
            ViewBag.PublishableKey = _mySettings.PublishableKey;
            return View();
        }

        [HttpPost]
        [Route("Refund")]
        public IActionResult Refund(string RefundKey)
        {
            //Contact me for here code
            return View("RefundDone");
        }

        [HttpGet]
        [Route("Refund")]
        public IActionResult RefundGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            //Contact me for here code
            var options = new ChargeCreateOptions
            {
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            ViewBag.Chargeid = charge.Id;
            return View();
        }

    }
}
