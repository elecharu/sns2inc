<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsTab.ascx.cs" Inherits="ItsTab" %>
<!-- Tab Start: <%= _ID %> -->
<div <% if (_ID != "") { %>id="<%= _ID %>" <% } %>class="ItsTab"><%= Text %>
<!-- Tab End: <%= _ID %> -->
</div>