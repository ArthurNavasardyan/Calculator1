using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebCalculator1.Entity;

namespace WebCalculator1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathCalculationController : ControllerBase
    {

        public readonly Context context;

        public MathCalculationController(Context context)
        {
            this.context = context;
        }

        [HttpGet("/CreateMathCalculation")]
        public async Task<double> GetAsync(double a, string action, double b)
        {
            double result;



            Entity.Action action1 = new Entity.Action();

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
            
            return result;

        }


        [HttpGet("/AllMathCalculation")]
        public async Task<List<Entity.Action>> GetAllActionAsync()
        {
           
            return await this.context.Actions.ToListAsync();
           
        }

    }


}