<%@ Page Language="C#" %>
<%
    StringBuilder sb = new StringBuilder();
    System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(Server.MapPath("."));
    System.IO.FileInfo[] fileList = dinfo.GetFiles();
    foreach(System.IO.FileInfo fInfo in fileList)
    {
        if (fInfo.Extension.ToUpper() == ".DLL")
        {
            sb.Append("|" + fInfo.Name);
        }
    }

    Response.Write(sb.ToString());
    Response.End();
%>