<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsSplit.ascx.cs" Inherits="ItsSplit" %>
<!-- Splitter -->
<div class="Split<%= _Type %>Bar <% if(_Resizeable) { %>resizeableSplit <% } %>"
<%
    if (_Type == "V")
    {
        if(_Resizeable)
        {
            %> style="width: <%= _WidthVbar %>px;" <%
        }
        else
        {
            %> style="width: 3px;background-color:#E9E9E9;border:none;" <%
        }
    }
    else
    {
        if(_Resizeable)
        {
            %> style="height: <%= _HeightHbar %>px;" <%
        }
        else
        {
            %> style="height: 3px;background-color:#E9E9E9;border:none;" <%
        }
    }
%>
></div>

