using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC.Web.CustomTagHelpers
{
    public class ThumbNailImageTagHelper : TagHelper
    {
        public string Url { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            var path = Url.Split(".");

            var thumbnailUrl = $"{path[0]}250x250.{path[1]}";
            output.Attributes.Add("src", thumbnailUrl);
        }
    }
}