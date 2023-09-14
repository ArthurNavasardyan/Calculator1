using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebCalculator1.Entity;
using WebCalculator1.Hubs;


namespace WebCalculator1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathCalculationController : ControllerBase
    {

        public readonly Context context;
        private readonly IHubContext<HubClass> hubContext;

        public MathCalculationController(Context context, IHubContext<HubClass> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [HttpGet("/CreateMathCalculation")]
        public async Task<double> GetAsync(double a, string action, double b)
        {
            double result;



            Entity.Action action1 = new Entity.Action();
            //HubClass hub = new HubClass();

            action1.FirstNumber = a;
            action1.SecondNumber = b;
            action1.MathAction = action;
            action1.RegistrationDate = DateTime.Now;

            switch (action)
            {
                case "+":
                    result = a + b;
                    action1.Result = result;
                    break;
                case "-":
                    result = a - b;
                    action1.Result = result;
                    break;
                case "*":
                    result = a * b;
                    action1.Result = result;
                    break;
                case "/":
                    if (b != 0)
                    {
                        result = a / b;
                        action1.Result = result;
                        break;
                    }
                    else
                    {
                        throw new ArithmeticException("the number can't division by zero");
                    }

                default:
                    {
                        throw new Exception("There is no such action,the action must be․" +
                                       "mount(+) or subtraction(-) or multiplication(*) or division(/)");
                    }

            }
                        
            context.Actions.Add(action1);
            await context.SaveChangesAsync();
            //await hub.SendResult(result);
            await hubContext.Clients.All.SendAsync("Send", result);

            return result;

        }


        [HttpGet("/AllMathCalculation")]
        public async Task<List<Entity.Action>> GetAllActionAsync()
        {
           
            return await this.context.Actions.ToListAsync();
           
        }

    }


}