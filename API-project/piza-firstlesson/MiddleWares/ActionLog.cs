using System.Diagnostics;
using System.Globalization;
using fileService;
using System.Text.Json;

namespace piza_firstlesson.Middlewares
{
    public class ActionLogMiddleware
    {
    private readonly RequestDelegate _next;
    private IfileService<string> _wr;

    public ActionLogMiddleware(RequestDelegate next)
    {
        _next = next;
        
    }

    public async Task InvokeAsync(HttpContext context, IfileService<string> wr)
    {
        try{
            _wr=wr;
            _wr.FileName="log.txt";
            string mr = context.Request.Method;
            string pr = context.Request.Path;
            string ptc= context.Request.Protocol;
            if(pr!="/index.html" && pr!="/favicon.ico"){
                string xr="the request:  date time: "+DateTime.Now +" method: "+mr +" path: "+pr+" protocol: "+ptc;
                _wr.WriteLog(xr);
            }

            await _next(context);

            _wr.FileName="log.txt";
            int ss = context.Response.StatusCode;
            //string bs= JsonSerializer.Serialize(context.Response.Body);
            if(pr!="/index.html" && pr!="/favicon.ico"){
                string xs="the response:  date time: "+DateTime.Now +" status code: " +ss;
                _wr.WriteLog(xs);
            }
        }
        catch(Exception ex){
            throw ex;
        }
    }
    }
}