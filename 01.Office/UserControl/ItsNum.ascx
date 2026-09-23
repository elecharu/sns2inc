<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsNum.ascx.cs" Inherits="ItsNum" %>
    <!-- Text -->
    <div class="ItsNum<% if (_ReadOnly == "true") { %> readonly <% } %>" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsNum_table" 
            <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <input <% if (_ID != "") { %>id="<%= _ID %>" <% } %>type="text" 
                style="width:<%= _InputWidth %>px;  display:none; <% if (_TriggerButton) { %> padding-right : 25px <% } %> "
                class="ItsField ItsNum" 
                data-point="<%= _DecimalPoint %>" 
                data-default="<%= _Value %>"
                data-field="<%= _Field %>" 
                data-readonly="<%= _ReadOnly %>"
                data-minvalue="<%= _MinValue %>"
                data-maxvalue="<%= _MaxValue %>"
                autocomplete="off"
                maxlength="20"
                value="<%= _Value %>" <% if (_ReadOnly == "true") { %>readonly="readonly" <% } %>
                />
            <input type="text" class="ItsNumView" autocomplete="off" style="width:<%= _InputWidth %>px;  <% if (_TriggerButton) { %> padding-right : 25px <% } %>" 
                <% if (_ReadOnly == "true") { %>readonly="readonly" <% } %> 
                />
            <% if (_TriggerButton) { %>
            <div class="ItsNum_button">
                <div class="ItsNum_plus"></div>
                <div class="ItsNum_bar"></div>
                <div class="ItsNum_minus"></div>
            </div>
            <% } %>
        </div>
    </div>