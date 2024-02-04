using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pines.Examples.Models;

namespace Pines.Examples.Controllers;

public class GetHomeController : Controller
{
  private readonly ILogger<GetHomeController> _logger;

  public GetHomeController(
    ILogger<GetHomeController> logger
  ) =>
    _logger = logger;

  public IActionResult GetHome() => View();

  [ResponseCache(
    Duration = 0,
    Location = ResponseCacheLocation.None,
    NoStore = true
  )]
  public IActionResult Error()
  {
    return View(
      new ErrorViewModel
      {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      }
    );
  }
}
