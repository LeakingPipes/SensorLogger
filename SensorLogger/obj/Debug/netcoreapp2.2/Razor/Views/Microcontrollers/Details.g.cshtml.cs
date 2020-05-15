#pragma checksum "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e364dd083d0602ec96e9be385b059daf716ccb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Microcontrollers_Details), @"mvc.1.0.view", @"/Views/Microcontrollers/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Microcontrollers/Details.cshtml", typeof(AspNetCore.Views_Microcontrollers_Details))]
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
#line 1 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\_ViewImports.cshtml"
using SensorLogger;

#line default
#line hidden
#line 2 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\_ViewImports.cshtml"
using SensorLogger.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e364dd083d0602ec96e9be385b059daf716ccb6", @"/Views/Microcontrollers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8dccc9acb23acb1f7471cf183912036672c6059", @"/Views/_ViewImports.cshtml")]
    public class Views_Microcontrollers_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SensorLogger.Models.Microcontroller>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(89, 270, true);
            WriteLiteral(@"
<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
<script type=""text/javascript"">
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
");
            EndContext();
#line 13 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
          
            List<string> valueType = new List<string>();

            foreach(Reading reading in Model.Readings)
            {
                

#line default
#line hidden
#line 18 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                 foreach(ReadingValue readingValue in reading.ReadingValues)
                {
                    valueType.Add(readingValue.ValueType);
                }

#line default
#line hidden
#line 21 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                 
            }
        

#line default
#line hidden
            BeginContext(704, 612, true);
            WriteLiteral(@"
        

        var data = google.visualization.arrayToDataTable([

            
            ['Time', 'Sales', 'Expenses'],
            ['2004', 1000, 400],
            ['2005', 1170, 460],
            ['2006', 660, 1120],
            ['2007', 1030, 540]
        ]);

        var options = {
            title: 'Company Performance',
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

        chart.draw(data, options);
    }
</script>

<div>
    ");
            EndContext();
            BeginContext(1317, 31, false);
#line 50 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
Write(Html.DisplayForModel(valueType));

#line default
#line hidden
            EndContext();
            BeginContext(1348, 69, true);
            WriteLiteral("\r\n\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1418, 55, false);
#line 54 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MicrocontrollerName));

#line default
#line hidden
            EndContext();
            BeginContext(1473, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1535, 51, false);
#line 57 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
       Write(Html.DisplayFor(model => model.MicrocontrollerName));

#line default
#line hidden
            EndContext();
            BeginContext(1586, 178, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            API URL\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <p>https://localhost:44396/api/microcontroller?id=");
            EndContext();
            BeginContext(1765, 49, false);
#line 63 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                                                         Write(Html.DisplayFor(model => model.MicrocontrollerID));

#line default
#line hidden
            EndContext();
            BeginContext(1814, 64, true);
            WriteLiteral("</p>\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1879, 44, false);
#line 66 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Readings));

#line default
#line hidden
            EndContext();
            BeginContext(1923, 288, true);
            WriteLiteral(@"
        </dt>

        <div id=""curve_chart"" style=""width: 800px; height: 300px""></div>

        <dd class=""col-sm-10"">
            <table class=""table"">
                <tr>
                    <th>Date and time</th>
                    <th>Values</th>
                </tr>
");
            EndContext();
#line 77 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                 foreach (var _reading in Model.Readings)
                {

#line default
#line hidden
            BeginContext(2289, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2374, 44, false);
#line 81 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                       Write(Html.DisplayFor(model => _reading.Date_time));

#line default
#line hidden
            EndContext();
            BeginContext(2418, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 84 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                             foreach (var _readingvalue in _reading.ReadingValues)
                            {
                                

#line default
#line hidden
            BeginContext(2629, 45, false);
#line 86 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                           Write(Html.DisplayFor(model => _readingvalue.Value));

#line default
#line hidden
            EndContext();
            BeginContext(2714, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2757, 49, false);
#line 88 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                           Write(Html.DisplayFor(model => _readingvalue.ValueType));

#line default
#line hidden
            EndContext();
            BeginContext(2808, 40, true);
            WriteLiteral("                                <br />\r\n");
            EndContext();
#line 90 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                            }

#line default
#line hidden
            BeginContext(2879, 58, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 93 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(2956, 67, true);
            WriteLiteral("            </table>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3023, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e364dd083d0602ec96e9be385b059daf716ccb611237", async() => {
                BeginContext(3084, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 99 "C:\Users\Mads\Documents\GitHub\SensorLogger\SensorLogger\Views\Microcontrollers\Details.cshtml"
                           WriteLiteral(Model.MicrocontrollerID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3092, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3100, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e364dd083d0602ec96e9be385b059daf716ccb613589", async() => {
                BeginContext(3122, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3138, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SensorLogger.Models.Microcontroller> Html { get; private set; }
    }
}
#pragma warning restore 1591
