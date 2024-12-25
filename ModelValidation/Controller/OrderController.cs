using Microsoft.AspNetCore.Mvc;
using UdemyAssignment.Models;

namespace UdemyAssignment.Controller
{
    public class OrderController : ControllerBase
    {

        [Route("/order")]
        [HttpPost]
        public IActionResult Order([FromForm]Order order)
        {
            //print all the errors messgaes if there are any validation errors
            if (!ModelState.IsValid)
            {
                List<string> errorList = new List<string>();
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                }
                string errors = string.Join('\n', errorList);
                StatusCode(400);
                return BadRequest(errors);
            }
            else
            {
                Random random = new Random();
                int randomOrderNumber = random.Next(1, 99999);
                var data = new
                {
                    OrderNo =randomOrderNumber
                };
                StatusCode(200);
                return new JsonResult(data);
            }
           
        }
    }
}
