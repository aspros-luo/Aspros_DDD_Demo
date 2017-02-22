using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;

namespace Aspros_DDD_Infrastructure.Utility.Filter
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class StaticFileHandlerFilterAttribute : ActionFilterAttribute
    {
        public string Key { get; set; }
        //Action执行前
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["Controller"].ToString().ToLower();
            var actionName = context.RouteData.Values["Action"].ToString().ToLower();
            var areaName = context.RouteData.Values["Area"].ToString().ToLower();

            var id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString() : "";
            if (string.IsNullOrEmpty(id) && context.HttpContext.Request.Query.ContainsKey(Key))
            {
                id = context.HttpContext.Request.Query[Key];
            }

            var filePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", areaName, controllerName + "-" + actionName + ((string.IsNullOrEmpty(id) ? "" : "-" + id)) + ".html");

            if (File.Exists(filePath))
            {
                var fs = File.Open(filePath, FileMode.Open);
                var sr = new StreamReader(fs, Encoding.UTF8);
                var contentResult = new ContentResult()
                {
                    Content = sr.ReadToEnd(),
                    ContentType = "text/html",
                };
                context.Result = contentResult;
            }
        }
        //Action执行后
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //获取结果内容
            var actionResult = context.Result;
            //判断结果是否是VIewResult
            if (actionResult is ViewResult)
            {
                var viewResult = actionResult as ViewResult;
                var services = context.HttpContext.RequestServices;
                var executor = services.GetRequiredService<ViewResultExecutor>();
                var option = services.GetRequiredService<IOptions<MvcViewOptions>>();
                var result = executor.FindView(context, viewResult);
                result.EnsureSuccessful(originalLocations: null);
                var view = result.View;

                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                var viewContext = new ViewContext(context, view, viewResult.ViewData, viewResult.TempData, sw, option.Value.HtmlHelperOptions);

                view.RenderAsync(viewContext).GetAwaiter().GetResult();
                sw.Flush();

                string areaName = context.RouteData.Values["Area"].ToString().ToLower();
                string controllerName = context.RouteData.Values["Controller"].ToString().ToLower();
                string actionName = context.RouteData.Values["Action"].ToString().ToLower();
                string id = context.RouteData.Values.ContainsKey(Key) ? context.RouteData.Values[Key].ToString().ToLower() : "";
                if (string.IsNullOrEmpty(id) && context.HttpContext.Request.Query.ContainsKey(Key))
                {
                    id = context.HttpContext.Request.Query[Key];
                }

                //获取文件目录
                var devicedir = Path.Combine(AppContext.BaseDirectory, "wwwroot", areaName);
                //判断目录是否存在
                if (!Directory.Exists(devicedir)) { Directory.CreateDirectory(devicedir); }

                //获取文件路径
                var filePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", areaName, controllerName + "-" + actionName + ((string.IsNullOrEmpty(id) ? "" : "-" + id)) + ".html");

                //获取文件信息
                var fileInfo = new FileInfo(filePath);
                //计算时间间隔
                var ts = DateTime.Now - fileInfo.CreationTime;
                if (ts.TotalMinutes <= 2)
                {
                    //写入内容
                    var fs = File.Open(filePath, FileMode.Create);
                    var streamWriter = new StreamWriter(fs, Encoding.UTF8);
                    streamWriter.Write(sb);

                    var contentResult = new ContentResult()
                    {
                        Content = sb.ToString(),
                        ContentType = "text/html"
                    };
                    context.Result = contentResult;
                }

            }
        }

    }
}
