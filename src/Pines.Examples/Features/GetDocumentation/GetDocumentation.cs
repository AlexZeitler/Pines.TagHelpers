using Microsoft.AspNetCore.Mvc;

namespace Pines.Examples.Features.GetDocumentation;

public class GetDocumentationController : Controller
{
  [Route("/documentation/introduction")]
  public IActionResult GetIntroduction() => View();
}
