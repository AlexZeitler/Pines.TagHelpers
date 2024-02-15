using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Pines.TagHelpers.RazorTagHelperBase;
using Tailwind.Heroicons;

namespace Pines.Examples.Components.NavigationItemTagHelper;

public class NavigationItem
{
  public string? Text { get; set; }
  public string? Href { get; set; }
  public string? UriTemplate { get; set; }
  public string[] Hrefs { get; set; } = [];
  public IconSymbol? Icon { get; set; }

  public bool IsMatch(
    string url
  )
  {
    var regexPattern = Regex.Escape(UriTemplate)
      .Replace("\\{", "(?<")
      .Replace("}", ">[^\\/\\?]+)")
      .Replace("/", "\\/")
      .Replace("\\?", "\\?") + "$";

    var regex = new Regex(regexPattern);
    return regex.IsMatch(url);
  }
}


public class NavigationItemTagHelper : RazorTagHelperBase<NavigationItem>
{
  public NavigationItemTagHelper(
    IHtmlHelper htmlHelper
  ) : base(htmlHelper)
  {
  }

  [HtmlAttributeName("item")] public NavigationItem? Item { get; set; }

  public override async Task ProcessAsync(
    TagHelperContext context,
    TagHelperOutput output
  )
  {
    SetPartialName("NavigationItemTagHelper", Item);
    await base.ProcessAsync(context, output);
  }
}
