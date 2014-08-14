using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class ResumeHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        var s = GetJsonResume(context.Server.MapPath("~/App_Data/resume.json"));
        context.Response.ContentType = "application/json";
        context.Response.Write(s);
    }

    private string GetJsonResume(string path)
    {
        //get file and return some json OR maybe use azure storage etc. etc.
        string result;

        using(var reader = new StreamReader(path))
        {
            result = reader.ReadToEnd();
        }

        return result;
    }
}