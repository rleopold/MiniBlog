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
        string content; 
        if (context.Request.HttpMethod == "POST")
        {
            content = GetResumeContent(context.Server.MapPath("~/App_Data/resume.json"));
            context.Response.ContentType = "application/json";
        }
        else //GET
        {
            content = GetResumeContent(context.Server.MapPath("~/App_Data/resume.html"));
            context.Response.ContentType = "text/html";
        }

        context.Response.Write(content);
    }

    private string GetResumeContent(string path)
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