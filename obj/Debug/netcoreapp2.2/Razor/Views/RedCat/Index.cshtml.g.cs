#pragma checksum "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a10974ce2000d89cbb5abad6c1ebd9a1a8b0340e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RedCat_Index), @"mvc.1.0.view", @"/Views/RedCat/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RedCat/Index.cshtml", typeof(AspNetCore.Views_RedCat_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\_ViewImports.cshtml"
using MiMWebsite;

#line default
#line hidden
#line 2 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\_ViewImports.cshtml"
using MiMWebsite.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a10974ce2000d89cbb5abad6c1ebd9a1a8b0340e", @"/Views/RedCat/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ab2ce05ed6e52c358a317967e0eda996dab5613", @"/Views/_ViewImports.cshtml")]
    public class Views_RedCat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MiMWebsite.Models.RedCatModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(5, 17, false);
#line 1 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(22, 7, true);
            WriteLiteral("</h1>\r\n");
            EndContext();
#line 3 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
  
	ViewData["Title"] = "RedCat index";

#line default
#line hidden
            BeginContext(125, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(130, 17, false);
#line 6 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(147, 182, true);
            WriteLiteral("</h1>\r\n<table class=\"table\">\r\n\t<tr>\r\n\t\t<th>รหัสภาพยนต์</th>\r\n\t\t<th>ชื่อภาพยนต์</th>\r\n\t\t<th>รูป</th>\r\n\t\t<th>เข้าฉายเมื่อ</th>\r\n\t\t<th>หมวดหมู่</th>\r\n\t\t<th>ความยาว (นาที)</th>\r\n\t</tr>\r\n");
            EndContext();
#line 16 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
     foreach (var item in Model)
	{

#line default
#line hidden
            BeginContext(364, 15, true);
            WriteLiteral("\t\t<tr>\r\n\t\t\t<td>");
            EndContext();
            BeginContext(380, 7, false);
#line 19 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
           Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(387, 14, true);
            WriteLiteral("</td>\r\n\t\t\t<td>");
            EndContext();
            BeginContext(402, 10, false);
#line 20 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
           Write(item.title);

#line default
#line hidden
            EndContext();
            BeginContext(412, 24, true);
            WriteLiteral("</td>\r\n\t\t\t<td>\r\n\t\t\t\t<img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 436, "\"", 456, 1);
#line 22 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
WriteAttributeValue("", 442, item.coverImg, 442, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(457, 36, true);
            WriteLiteral(" height=\"80px\" />\r\n\t\t\t</td>\r\n\t\t\t<td>");
            EndContext();
            BeginContext(494, 16, false);
#line 24 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
           Write(item.releaseDate);

#line default
#line hidden
            EndContext();
            BeginContext(510, 14, true);
            WriteLiteral("</td>\r\n\t\t\t<td>");
            EndContext();
            BeginContext(525, 10, false);
#line 25 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
           Write(item.genre);

#line default
#line hidden
            EndContext();
            BeginContext(535, 14, true);
            WriteLiteral("</td>\r\n\t\t\t<td>");
            EndContext();
            BeginContext(550, 13, false);
#line 26 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
           Write(item.duration);

#line default
#line hidden
            EndContext();
            BeginContext(563, 16, true);
            WriteLiteral("</td>\r\n\t\t</tr>\r\n");
            EndContext();
#line 28 "C:\Users\ter12\OneDrive\เดสก์ท็อป\MiMWebsite\Views\RedCat\Index.cshtml"
	}

#line default
#line hidden
            BeginContext(583, 8, true);
            WriteLiteral("</table>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MiMWebsite.Models.RedCatModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591