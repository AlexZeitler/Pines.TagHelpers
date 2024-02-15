using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Tailwind.Heroicons;

namespace Pines.TagHelpers.AccordionTagHelper;

public class AccordionItem
{
  public string Preview { get; set; }
  public string Content { get; set; }
  
  public AccordionItem(
    string preview,
    string content
  )
  {
    Preview = preview;
    Content = content;
  }
}

public class Accordion
{
  public IconSymbol? Icon { get; set; }
  public string IconTransformClasses { get; set; } = "rotate-180";
  public List<AccordionItem> Items { get; set; } = new();
}

public class AccordionTagHelper : RazorTagHelperBase.RazorTagHelperBase<Accordion>
{
  [HtmlAttributeName("accordion")] public Accordion Accordion { get; set; }

  public AccordionTagHelper(
    IHtmlHelper htmlHelper
  ) : base(htmlHelper)
  {
  }

  public override async Task ProcessAsync(
    TagHelperContext context,
    TagHelperOutput output
  )
  {
    SetPartialName("~/Templates/AccordionTagHelper/AccordionTagHelper.cshtml", Accordion);
    await base.ProcessAsync(context, output);
  }
}
