using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalcController : ControllerBase
{
    public CalcController()
    {
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (Numerical(firstNumber) && Numerical(secondNumber))
        {
            var sum = ToDecimal(firstNumber) + ToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input provided!");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (Numerical(firstNumber) && Numerical(secondNumber))
        {
            var subtraction = ToDecimal(firstNumber) - ToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }
        return BadRequest("Invalid input provided!");
    }

    [HttpGet("times/{factorOne}/{factorTwo}")]
    public IActionResult Times(string factorOne, string factorTwo)
    {
        if (Numerical(factorOne) && Numerical(factorTwo))
        {
            var times = ToDecimal(factorOne) * ToDecimal(factorTwo);
            return Ok(times.ToString());
        }

        return BadRequest("Invalid input provided!");
    }

    [HttpGet("division/{numerator}/{denominator}")]
    public IActionResult Division(string numerator, string denominator)
    {
        if (Numerical(numerator) && Numerical(denominator))
        {
            if (ToDecimal(denominator) == 0)
            {
                return BadRequest("Denominator must not be equal to 0!");
            }
            var division = ToDecimal(numerator) / ToDecimal(denominator);
            return Ok(division.ToString());
        }

        return BadRequest("Invalid input provided!");
    }

    [HttpGet("squareRoot/{number}")]
    public IActionResult SquareRoot(string number)
    {

        if (Numerical(number))
        {
            var parsedNumber = ToDecimal(number);
            if (parsedNumber < 0)
                return BadRequest("The number must be greater or equal to 0!");

            var doubleNumber = Decimal.ToDouble(parsedNumber);
            var squareRoot = Math.Sqrt(doubleNumber);

            return Ok(squareRoot.ToString());
        }

        return BadRequest("Invalid input provided!");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
        if (Numerical(firstNumber) && Numerical(secondNumber))
        {
            var mean = (ToDecimal(firstNumber) + ToDecimal(secondNumber)) / 2.0M;
            return Ok(mean.ToString());
        }
        return BadRequest("Invalid input provided!");
    }

    private static bool Numerical(string parameter)
    {
        return double.TryParse(
            parameter,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo, out _);
    }

    private static decimal ToDecimal(string strNumber)
    {
        if (decimal.TryParse(strNumber, out decimal decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }
}
