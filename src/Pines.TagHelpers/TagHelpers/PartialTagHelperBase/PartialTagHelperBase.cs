using JetBrains.Annotations;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Pines.TagHelpers.PartialTagHelperBase;

public class PartialTagHelperBase : TagHelper
{
  [HtmlAttributeNotBound] [ViewContext] public ViewContext? ViewContext { get; set; }
  private readonly IHtmlHelper _htmlHelper;

  protected PartialTagHelperBase(
    IHtmlHelper htmlHelper
  ) => _htmlHelper = htmlHelper;

  protected async Task<IHtmlContent> RenderPartial<T>(
    [AspMvcPartialView]string partialName,
    T model
  )
  {
    (_htmlHelper as IViewContextAware)?.Contextualize(ViewContext);

    return await _htmlHelper.PartialAsync(partialName, model);
  }
}
