#pragma checksum "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afb1f2d939c1459cbe72510391a5ee9a6c6bb214"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BlogApp.Pages.Pages_Detail), @"mvc.1.0.razor-page", @"/Pages/Detail.cshtml")]
namespace BlogApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using BlogApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using BlogApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using BlogApp.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\_ViewImports.cshtml"
using BlogApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afb1f2d939c1459cbe72510391a5ee9a6c6bb214", @"/Pages/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3857c3c1978343e0e79d3cfb31ce449fc6f86365", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Detail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Home\Desktop\BlogApp-Razorpages\BlogApp\Pages\Detail.cshtml"
Write(Html.Raw(Model.Blog.Content));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApp.Pages.DetailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BlogApp.Pages.DetailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BlogApp.Pages.DetailModel>)PageContext?.ViewData;
        public BlogApp.Pages.DetailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
