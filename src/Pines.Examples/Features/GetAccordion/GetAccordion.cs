using Microsoft.AspNetCore.Mvc;

namespace Pines.Examples.Features.GetAccordion;

public class GetAccordionController: Controller
{
  [Route("/tag-helpers/accordion")]
  public IActionResult GetAccordion() => View();
}
