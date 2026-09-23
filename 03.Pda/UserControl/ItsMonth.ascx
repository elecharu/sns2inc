<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsMonth.ascx.cs" Inherits="ItsMonth" %>
    <!-- Date -->
    <div class="ItsMonth"<% if (_ReadOnly == "true") { %> readonly="readonly"<% } %> 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsMonth_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsMonth_box">
                <input type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:aliceblue; <% } %>" 
                    class="ItsField ItsDate" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _Field %>" 
                    data-value="<%= _Value %>"
                    data-default="<%= _Value %>"
                    value="<%= _Value %>"
                    autocomplete="off"
                    />
                <div class="ItsMonth_button"><i class="fa fa-calendar"></i></div>
            </div>
        </div>
    </div>