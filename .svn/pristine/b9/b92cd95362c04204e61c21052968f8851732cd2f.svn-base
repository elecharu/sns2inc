<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsText.ascx.cs" Inherits="ItsText" %>
    <!-- Text -->
    <div class="ItsText<% if (_ReadOnly == "true") { %> readonly<% } %>" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsText_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <input 
                <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                class="ItsField ItsText" 
                style="width:<%= _InputWidth %>px; <% if (_Type == "password") { %> -webkit-text-security:disc;<% } %>"
                data-field="<%= _Field %>" 
                data-default="<%= _Value %>"
                data-mask="<%= _Mask %>"
                autocomplete="off"
                value="<%= _Value %>" <% if (_ReadOnly == "true") { %>readonly="readonly" tabindex="-1" <% } %>/>
        </div>
    </div>