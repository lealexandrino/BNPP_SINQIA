#pragma checksum "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef030a08cdcb694da8be209c75cb70b505ae6c90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProdutoCosifs_Index), @"mvc.1.0.view", @"/Views/ProdutoCosifs/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProdutoCosifs/Index.cshtml", typeof(AspNetCore.Views_ProdutoCosifs_Index))]
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
#line 1 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\_ViewImports.cshtml"
using TESTE_BNPP;

#line default
#line hidden
#line 2 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\_ViewImports.cshtml"
using TESTE_BNPP.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef030a08cdcb694da8be209c75cb70b505ae6c90", @"/Views/ProdutoCosifs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce96720250a0e05612a35f173c8d479792cc6203", @"/Views/_ViewImports.cshtml")]
    public class Views_ProdutoCosifs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Domain.ProdutoCosif>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(84, 38, true);
            WriteLiteral("\r\n<h2>Produtos Cosif</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(122, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd70921893da4a868dc3b2e92fe3aff0", async() => {
                BeginContext(145, 13, true);
                WriteLiteral("Novo Cadastro");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(162, 395, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Código Classificação
            </th>
            <th>
                Status
            </th>
            <th>
                Código Produto
            </th>
            <th>
                Código Cosif
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 31 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(589, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(638, 51, false);
#line 34 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodClassificacao));

#line default
#line hidden
            EndContext();
            BeginContext(689, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(745, 44, false);
#line 37 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StaStatus));

#line default
#line hidden
            EndContext();
            BeginContext(789, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(845, 45, false);
#line 40 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodProduto));

#line default
#line hidden
            EndContext();
            BeginContext(890, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(946, 43, false);
#line 43 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CodCosif));

#line default
#line hidden
            EndContext();
            BeginContext(989, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1045, 111, false);
#line 46 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.ActionLink("Editar", "Edit", new { codProduto = item.CodProduto.Trim(), codCosif = item.CodCosif.Trim() }));

#line default
#line hidden
            EndContext();
            BeginContext(1156, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1177, 114, false);
#line 47 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
           Write(Html.ActionLink("Deletar", "Delete", new { codProduto = item.CodProduto.Trim(), codCosif = item.CodCosif.Trim() }));

#line default
#line hidden
            EndContext();
            BeginContext(1291, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 50 "C:\Users\Leandro\source\repos\lealexandrino\BNPP_SINQIA\TESTE_BNPP\Views\ProdutoCosifs\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1330, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Domain.ProdutoCosif>> Html { get; private set; }
    }
}
#pragma warning restore 1591
