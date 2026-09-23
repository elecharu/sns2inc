<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsButton.ascx.cs" Inherits="ItsButton" %>
    <!-- Button -->
    <div class="ItsButton <%= DisabledCls %>"  <% if (_ID != "") { %> id="<%= _ID %>" <% } %>
        
        style="float:<%= _Float %>;
               <% if (_Hidden == "true") { %> display:none;<% } %>
               <% if (_Margin != "") { %>margin:<%= _Margin %>;<% } %>
               <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
               <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
               <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
               <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>"
                data-disabled="<%= _Disabled %>"
                data-loading="<%= _Loading %>"
        <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %>
        
        <% 
            string style = "";
            if (_Label != "") {
                style = "background-color:" + _BackColor + ";color:" + _ForeColor + ";border-color:" + _BorderColor + ";";
            } else {
                style = "background-color:transparent; color:" + _ForeColor + ";border-color:transparent;";
            } 
        %>>
        <div class="ItsButton_table <%=_BackColorClass %>" 
             tabindex="<%= _TabIndex %>""
             style="<%= style %>
                    <% if (_Width != "") { %>width:<%= _Width %>px;<% } %>
                    <% if (_Height != "") { %>height:<%= _Height %>px;<% } %>
                    text-align:center">
            <% if (_FaIcon != "") { %><i class="<%= _FaIcon %>"></i> <% } %>
            <% if (_Label != "") { %><span class="ItsButton_span" style="font-weight:bold;"><%= _Label %></span><% } %>
        </div>
    </div>