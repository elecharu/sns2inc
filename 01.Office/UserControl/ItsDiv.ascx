<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDiv.ascx.cs" Inherits="ItsDiv" %>
<!-- Panel Start: <%= _ID %> -->
<% if(_TabTitle != "") {%> <div><a><%= _TabTitle %></a> <%} %> 
<div <% if (_ID != "") { %>id="<%= _ID %>" <% } %>
    class="<%= _Type %>"  <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> 
    <% if (_LeftWidthPc != ""){ %>data-leftwidthpc="<%= _LeftWidthPc %>"<% }%>
    <% if (_TopHeightPc != ""){ %>data-topheightpc="<%= _TopHeightPc %>"<% }%>
    style="background-color:<%= _BackColor %>;
           <% if (_Float == "right"){ %>float:right; <% }%>
           <% if (_LeftPosPc != null){ %>position:relative;left:<%= _LeftPosPc %>%;"<% }%>">
    <%= Text %>
    <!-- Last Clear -->
    <div style="clear:both;height:0px"></div>

<!-- Panel End: <%= _ID %> -->
    
</div>
<% if(_TabTitle != "") {%> </div> <%} %>