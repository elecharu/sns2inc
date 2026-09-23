<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDisplay.ascx.cs" Inherits="ItsDisplay" %>
    <!-- Display -->
    <div class="ItsDisplay" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsDisplay_table">
            <span style="width:<%= _LabelWidth %>px;"><%= _Label %></span>
            <span <% if (_ID != "") { %>id="<%= _ID %>"<% } %> 
                class="ItsField ItsDisplay" 
                data-field="<%= _Field %>" 
                data-default="<%= _Value %>"
                style="width:<%= _InputWidth %>px; text-align:left;"><%= _Value %></span>
        </div>
    </div>