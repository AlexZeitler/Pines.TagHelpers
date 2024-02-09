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
  public List<AccordionItem> Items { get; set; } = new();
}

public class AccordionTagHelper : PartialTagHelperBase.PartialTagHelperBase
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
    var htmlContent = await RenderPartial(
      "~/Templates/AccordionTagHelper/AccordionTagHelper.cshtml",
      Accordion
    );

    output.SuppressOutput();
    output.PreContent.AppendHtml(htmlContent);
  }
}
