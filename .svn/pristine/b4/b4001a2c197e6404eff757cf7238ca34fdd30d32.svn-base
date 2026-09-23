<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsButton.ascx.cs" Inherits="ItsButton" %>
    <!-- Button -->
    <div <% if (_ID != "") { %>id="<%= _ID %>" <% } %>
        class="ItsButton <%= DisabledCls %>" 
        style="float:<%= _Float %>;
               <% if (_Hidden == "true") { %>display:none;<% } %>
               <% if (_Margin != "") { %>margin:<%= _Margin %>;<% } %>
               <% if (_Margin_Left != "") { %>margin-left:<%= _Margin_Left %>;<% } %>
               <% if (_Margin_Right != "") { %>margin-right:<%= _Margin_Right %>;<% } %>
               <% if (_Margin_Top != "") { %>margin-top:<%= _Margin_Top %>;<% } %>
               <% if (_Margin_Bottom != "") { %>margin-bottom:<%= _Margin_Bottom %>;<% } %>"
        data-disabled="<%= _Disabled %>"
        data-loading="<%= _Loading %>"
        <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %>
        >
        <% 
            string style = "";
            if (_Label != "") {
                style = "background-color:" + _BackColor + ";color:" + _ForeColor + ";border-color:" + _BorderColor + ";";
            } else {
                style = "background-color:transparent; color:" + _ForeColor + ";border-color:transparent;";
            } 
        %>
        <div class="ItsButton_table" 
             tabindex="0"
             style="<%= style %>
                    <% if (_Width != "") { %>width:<%= _Width %>px;<% } %>
                    <% if (_Height != "") { %>height:<%= _Height %>px;<% } %>
                    text-align:center">
            <% if (_FaIcon != "") { %><i class="<%= _FaIcon %>"></i> <% } %>
            <% if (_Label != "") { %><span style="font-weight:bold;"><%= _Label %></span><% } %>
        </div>
    </div>