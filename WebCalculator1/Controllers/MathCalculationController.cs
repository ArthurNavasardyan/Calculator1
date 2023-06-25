using Microsoft.AspNetCore.Mvc;


namespace WebCalculator1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathCalculationController : ControllerBase
    {

        [HttpGet(Name = "MathCalculation")]
        public double Get(double a, string action, double b)
        {
            double result;

            
            switch (action)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if (b != 0)
                    {
                        result = a / b;
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
         return result;
        }
        
    }

    
}