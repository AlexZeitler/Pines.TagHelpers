using Microsoft.AspNetCore.Mvc;

namespace Pines.Examples.Features.GetCopyToClipboard;

public class GetCopyToClipboardController: Controller
{
  [Route("/tag-helpers/copy-to-clipboard")]
  public IActionResult GetCopyToClipboard() => View();
}
