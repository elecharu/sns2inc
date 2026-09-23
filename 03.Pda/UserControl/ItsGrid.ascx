<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsGrid.ascx.cs" Inherits="ItsGrid" %>
<!-- ItsGrid -->
<div <% if (_ID != "") { %>id="<%= _ID %>" <% } %>
    class="ItsGrid"
    style="<% if (_Float == "right") { %>float:right; <% } %>
    <% if (_Height != "") { %>height:<%= _Height%>px; <% } %>">
</div>