<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDisplay.ascx.cs" Inherits="ItsDisplay" %>
    <!-- Display -->
    <div class="ItsDisplay" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsDisplay_table" <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
            <span style="width:<%= _LabelWidth %>px;"><%= _Label %></span>
            <span <% if (_ID != "") { %>id="<%= _ID %>"<% } %> 
                class="ItsField ItsDisplay" 
                data-field="<%= _Field %>" 
                data-default="<%= _Value %>"
                style="width:<%= _InputWidth %>px; text-align:<%= _textAlign %>;"><%= _Value %></span>
        </div>
    </div>