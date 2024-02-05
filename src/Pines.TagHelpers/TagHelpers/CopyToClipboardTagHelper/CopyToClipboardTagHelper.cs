using Alpine.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Tailwind.Heroicons;

namespace Pines.TagHelpers.CopyToClipboardTagHelper;

public class CopyToClipboardTagHelperOptions
{
  public string? CopyText { get; set; }
  public bool CopyNotification { get; set; }
  public IconSymbol? Icon { get; set; }

  [JsonConverter(typeof(RawStringConverter))]
  public string CopyToClipboard => @"
    function() {
            navigator.clipboard.writeText(this.copyText);
            this.copyNotification = true;
            let that = this;
            setTimeout(function(){
                that.copyNotification = false;
            }, 3000);
        }
    ";
}

public class CopyToClipboardTagHelper : PartialTagHelperBase.PartialTagHelperBase
{
  public CopyToClipboardTagHelper(
    IHtmlHelper htmlHelper
  ) : base(htmlHelper)
  {
  }

  [HtmlAttributeName("text")] public string? Text { get; set; }
  [HtmlAttributeName("label")] public string? Label { get; set; }
  [HtmlAttributeName("success-label")] public string? SuccessLabel { get; set; }
  [HtmlAttributeName("icon")] public IconSymbol? Icon { get; set; }

  [HtmlAttributeName("copy-notification")]
  public bool CopyNotification { get; set; }

  public override async Task ProcessAsync(
    TagHelperContext context,
    TagHelperOutput output
  )
  {
    var options = new Dictionary<string, object?>
    {
      { "text", Text },
      { "copyNotification", CopyNotification },
      { "icon", Icon },
      { "label", Label },
      { "successLabel", SuccessLabel }
    };
    var someContent = await RenderPartial(
      "~/Templates/CopyToClipboardTagHelper/CopyToClipboardTagHelper.cshtml",
      options
    );

    output.PreContent.AppendHtml(someContent);
  }
}
