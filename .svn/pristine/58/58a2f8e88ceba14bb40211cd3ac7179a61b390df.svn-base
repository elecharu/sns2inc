<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsTextArea.ascx.cs" Inherits="ItsTextArea" %>
    <!-- TextArea -->
    <div class="ItsTextArea<% if (_ReadOnly == "true") { %> readonly<% } %>" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsTextArea_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <textarea type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                class="ItsField ItsTextArea" 
                style="width:<%= _InputWidth %>px;height:<%= _InputHeight %>px"
                data-field="<%= _Field %>"
                autocomplete="off"
                <% if (_ReadOnly == "true") { %>readonly="readonly" <% } %>><%= _Value %></textarea>
        </div>
    </div>