using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CVHandler
/// </summary>
public class CVHandler : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {

        var content = GetCvContent(context.Server.MapPath("~/App_Data/cv.html"));
        context.Response.ContentType = "text/html";

        context.Response.Write(content);
    }

    private string GetCvContent(string path)
    {
        //get file html 
        string result;

        using (var reader = new StreamReader(path))
        {
            result = reader.ReadToEnd();
        }

        return result;
    }
}