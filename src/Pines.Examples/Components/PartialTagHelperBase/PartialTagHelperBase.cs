using JetBrains.Annotations;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Pines.Examples.Components.PartialTagHelperBase;

public class PartialTagHelperBase : TagHelper
{
  [HtmlAttributeNotBound] [ViewContext] public ViewContext? ViewContext { get; set; }
  private readonly IHtmlHelper _html;

  public PartialTagHelperBase(
    IHtmlHelper html
  ) => _html = html;

  protected async Task<IHtmlContent> RenderPartial<T>(
    [AspMvcPartialView]string partialName,
    T model
  )
  {
    (_html as IViewContextAware)?.Contextualize(ViewContext);

    return await _html.PartialAsync(partialName, model);
  }
}
