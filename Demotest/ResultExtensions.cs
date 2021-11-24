using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demotest
{
  public static class ResultExtensions
  {
    public static int? GetOkObjectResult(this IResult result)
    {
      return (int?)Type.GetType("Microsoft.AspNetCore.Http.Result.OkObjectResult, Microsoft.AspNetCore.Http.Results")?
        .GetProperty("StatusCode",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)?
        .GetValue(result);
    }
    public static T? GetOkObjectResultValue<T>(this IResult result)
    {
      return (T?)Type.GetType("Microsoft.AspNetCore.Http.Result.OkObjectResult, Microsoft.AspNetCore.Http.Results")?
        .GetProperty("Value",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)?
        .GetValue(result);
    }

    public static int? GetNotFoundObjectResultStatusCode(this IResult result)
    {
      return (int?)Type.GetType("Microsoft.AspNetCore.Http.Result.NotFoundObjectResult, Microsoft.AspNetCore.Http.Results")?
        .GetProperty("StatusCode",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)?
        .GetValue(result);
    }
  }

}
