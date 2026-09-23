<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDate.ascx.cs" Inherits="ItsDate" %>
    <!-- Date -->
    <div class="ItsDate"
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsDate_table" <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsDate_box">
                <input type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                    style="width:<%= _InputWidth %>px;" 
                    class="ItsField ItsDate" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _Field %>" 
                    data-value="<%= _Value %>"
                    data-default="<%= _Value %>"
                    autocomplete="off"
                    value="<%= _Value %>"
                    />
                <div class="ItsDate_button"></div>
            </div>
        </div>
    </div>