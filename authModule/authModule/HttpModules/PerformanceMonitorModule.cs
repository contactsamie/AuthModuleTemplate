using System;
using System.Diagnostics;
using System.Web;

namespace authModule.HttpModules
{
    public class PerformanceMonitorModule : IHttpModule
    {
        public void Init(HttpApplication httpApp)
        {
            httpApp.BeginRequest += OnBeginRequest;
            httpApp.EndRequest += OnEndRequest;
            httpApp.PreSendRequestHeaders += OnHeaderSent;
        }

        public void OnHeaderSent(object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            httpApp.Context.Items["HeadersSent"] = true;
        }

        // Record the time of the begin request event.
        public void OnBeginRequest(Object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            if (httpApp.Request.Path.StartsWith("/media/")) return;
            var timer = new Stopwatch();
            httpApp.Context.Items["Timer"] = timer;
            httpApp.Context.Items["HeadersSent"] = false;
            timer.Start();
        }

        public void OnEndRequest(Object sender, EventArgs e)
        {
            var httpApp = (HttpApplication)sender;
            if (httpApp.Request.Path.StartsWith("/media/")) return;
            var timer = (Stopwatch)httpApp.Context.Items["Timer"];

            if (timer != null)
            {
                timer.Stop();
                if (!(bool)httpApp.Context.Items["HeadersSent"])
                {
                    httpApp.Context.Response.AppendHeader("ProcessTime",
                                                          ((double)timer.ElapsedTicks / Stopwatch.Frequency) * 1000 +
                                                          " ms.");
                }
            }

            httpApp.Context.Items.Remove("Timer");
            httpApp.Context.Items.Remove("HeadersSent");
        }

        public void Dispose()
        {
            /* Not needed */
        }
    }
}