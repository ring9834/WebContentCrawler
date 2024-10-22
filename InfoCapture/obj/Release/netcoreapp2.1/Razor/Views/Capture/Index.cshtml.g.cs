#pragma checksum "F:\Myprojects\2、AspCoreProject\InfoCaputureForWeixin\InfoCaptureForWeixin2\Views\Capture\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74852bd18ed4d06ef0dd7c6ba84211450f2a6fe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Capture_Index), @"mvc.1.0.view", @"/Views/Capture/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Capture/Index.cshtml", typeof(AspNetCore.Views_Capture_Index))]
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
#line 1 "F:\Myprojects\2、AspCoreProject\InfoCaputureForWeixin\InfoCaptureForWeixin2\Views\_ViewImports.cshtml"
using InfoCaptureForWeixin2;

#line default
#line hidden
#line 2 "F:\Myprojects\2、AspCoreProject\InfoCaputureForWeixin\InfoCaptureForWeixin2\Views\_ViewImports.cshtml"
using InfoCaptureForWeixin2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74852bd18ed4d06ef0dd7c6ba84211450f2a6fe3", @"/Views/Capture/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ef7c56c46623929a8f3cca44e46d33153e5cb8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Capture_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("body", async() => {
                BeginContext(17, 4451, true);
                WriteLiteral(@"
    <div class=""container-fluid"">
        <table id=""buyingTable""></table>
    </div>
    <script>
        var canExecute = false;
        var counter = 0;
        var counterMax = 2;
        var ordial = 0;
        var itemCount = 10;//每页中的条目项总数
        var myInterval;
        var daysBefore = -1;//抓取目前为止前几天的消息，默认-2天

        $(function () {
            executeByTime();
        });

        var executeByTime = function () {
            myInterval = setInterval(getCapturedInfoOnce, 3000);
        }

        var getCapturedInfoOnce = function () {
            if (counter < counterMax) {
                var pageOrdial = counter * itemCount;
                getBaiduInfos(pageOrdial, daysBefore);//百度的页是从0开始的
                counter++;

                pageOrdial = counter;
                getZhongSouInfos(pageOrdial, daysBefore);//中搜的页是从1开始的
                getWeiboInfos(pageOrdial, daysBefore);//微博的页是从1开始的
            }
            else { //执行超过最高次数，就停止定时执行程序
                clea");
                WriteLiteral(@"rInterval(myInterval);
            }
            console.log(counter);
        }

        //从百度中抓取
        var getBaiduInfos = function (startRec, daysBefore) {
            $.ajax({
                type: 'POST',
                url: ""/Capture/GetCapturedBaiduInfos"",
                data: { startRec: startRec, daysBefore: daysBefore },
                dataType: ""JSON"",
                success: function (data) {
                    if (data.rst.length > 0) {
                        //alert(data.rst.length);
                        var table = $('#buyingTable');
                        for (var i = 0; i < data.rst.length; i++) {
                            var url = data.rst[i].Url;
                            var title = data.rst[i].Title;
                            ordial++;
                            table.append('<tr><td><span>[' + ordial + ']</span><a href=""' + url + '"" target=""_blank"">' + title + '</a></td></tr>');
                        }
                    }
                   ");
                WriteLiteral(@" $(""#h_loading_mask"").css(""display"", ""none"");//加载成功后关闭加载提示
                    $(""#h_loading"").css(""display"", ""none"");
                }
            });
        }

        //从中搜中抓取
        var getZhongSouInfos = function (startRec, daysBefore) {
            $.ajax({
                type: 'POST',
                url: ""/Capture/GetCapturedZhongSouInfos"",
                data: { startRec: startRec, daysBefore: daysBefore },
                dataType: ""JSON"",
                success: function (data) {
                    if (data.rst.length > 0) {
                        //alert(data.rst.length);
                        var table = $('#buyingTable');
                        for (var i = 0; i < data.rst.length; i++) {
                            var url = data.rst[i].Url;
                            var title = data.rst[i].Title;
                            ordial++;
                            table.append('<tr><td><span>[' + ordial + ']</span><a href=""' + url + '"" target=""_blank"">' + title + ");
                WriteLiteral(@"'</a></td></tr>');
                        }
                    }
                    $(""#h_loading_mask"").css(""display"", ""none"");//加载成功后关闭加载提示
                    $(""#h_loading"").css(""display"", ""none"");
                }
            });
        }

        //从微博中抓取
        var getWeiboInfos = function (startRec, daysBefore) {
            $.ajax({
                type: 'POST',
                url: ""/Capture/GetCapturedWeiboInfos"",
                data: { startRec: startRec, daysBefore: daysBefore },
                dataType: ""JSON"",
                success: function (data) {
                    if (data.rst.length > 0) {
                        //alert(data.rst.length);
                        var table = $('#buyingTable');
                        for (var i = 0; i < data.rst.length; i++) {
                            var url = data.rst[i].Url;
                            var title = data.rst[i].Title;
                            ordial++;
                            table.append('<tr>");
                WriteLiteral(@"<td><span>[' + ordial + ']</span><a href=""' + url + '"" target=""_blank"">' + title + '</a></td></tr>');
                        }
                    }
                    $(""#h_loading_mask"").css(""display"", ""none"");//加载成功后关闭加载提示
                    $(""#h_loading"").css(""display"", ""none"");
                }
            });
        }
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
