<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDate.ascx.cs" Inherits="ItsDate" %>
    <!-- Date -->
    <div class="ItsDate"
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsDate_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsDate_box">
                <input type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:aliceblue; <% } %>" 
                    class="ItsField ItsDate" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _Field %>" 
                    data-value="<%= _Value %>"
                    data-default="<%= _Value %>"
                    autocomplete="off"
                    value="<%= _Value %>"
                    />
                <div class="ItsDate_button"><i class="fa fa-calendar"></i></div>
            </div>
        </div>
    </div>