using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTagHelpers.Library
{
    public class ThumbNailImageTagHelper : TagHelper
    {
        public string Url { get; set; } = default!;
        public string Dimension { get; set; } = "250x250";

        public bool IsDefault { get; set; } = true;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            var path = Url.Split(".");
            var pathWithoutExtension = path[0];
            var extension = path[1];


            var thumbnailUrl = $"{pathWithoutExtension}{Dimension}.{extension}";

            var url = $"{Directory.GetCurrentDirectory()}/wwwroot{thumbnailUrl}";
            if (!File.Exists(url))
            {
                thumbnailUrl = IsDefault ? "/images/default.jpg" : url;
            }

            output.Attributes.Add("src", thumbnailUrl);
        }
    }
}