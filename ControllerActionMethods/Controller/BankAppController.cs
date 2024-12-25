using Microsoft.AspNetCore.Mvc;

namespace Practice.Controller
{
    public class BankAppController : Microsoft.AspNetCore.Mvc.Controller
    {
        
        [Route("/")]
        [HttpGet]
        public string Index()
        {
            return "Welcome to the Best Bank\r\n\r\n";
        }

        [Route("/account-details")]
        [HttpGet]
        public JsonResult accDetails() 
        {
            AccountDetails accountDetails = new AccountDetails();
            accountDetails.accountHolderName = "Example Name";
            accountDetails.accountNumber = 1001;
            accountDetails.currentBalance = 5000;
            return new JsonResult(accountDetails);
        }

        [Route("/account-statement")]
        [HttpGet]
        public VirtualFileResult accstatement()
        {
            return new VirtualFileResult("/GnanaSpringSchedule.Pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber?}")]
        [HttpGet]

        public IActionResult accstatus() {
            int accNo = Convert.ToInt32(ControllerContext.HttpContext.Request.RouteValues["accountNumber"]);
            if(accNo == 1001)
            {
                new StatusCodeResult(200);
                return Content("5000");

            }
            else if (accNo == 0)
            {
                new StatusCodeResult(404);
                return Content("Account Number should be supplied");
            }
            else
            {
                new StatusCodeResult(400);
                return Content("Account Number should be 1001");

            }

        }  
    }
    public class AccountDetails
    {
        public int accountNumber { get; set; }
        public string accountHolderName { get; set; }
        public int currentBalance { get; set; }
    }
}
