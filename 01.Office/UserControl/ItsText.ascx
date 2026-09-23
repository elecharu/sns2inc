<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsText.ascx.cs" Inherits="ItsText" %>
    <!-- Text -->
    <div class="ItsText<% if (_ReadOnly == "true") { %> readonly<% } %>" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsText_table"  <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %>  >
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <input 
                <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                class="ItsField ItsText" 
                style="width:<%= _InputWidth %>px; <% if (_Type == "password") { %> -webkit-text-security:disc;<% } %>"
                data-field="<%= _Field %>" 
                data-default="<%= _Value %>"
                data-mask="<%= _Mask %>"
                autocomplete="off"
                <% if (_Placeholder != "") { %> placeholder="<%=_Placeholder %>" <% } %>
                <% if (_Type == "tel") { %> data-telno="Y" <% } %>
                <% else if (_Type == "regno") { %> data-regno="Y" <% } %>
                <% else if (_Type == "hhmm") { %> data-hhmm="Y" <% } %>
                <% else if (_Type == "hhmmss") { %> data-hhmmss="Y" <% } %>
                <% else if (_Type == "hhmm99") { %> data-hhmm99="Y" <% } %>
                <% if (_MaxLength != -1) { %>maxlength="<%= _MaxLength %>" <% } %>
                value="<%= _Value %>" <% if (_ReadOnly == "true") { %>readonly="readonly" tabindex="-1" <% } %>/>
        </div>
    </div>