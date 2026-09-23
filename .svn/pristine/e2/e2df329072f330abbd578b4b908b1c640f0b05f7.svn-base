<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsNum.ascx.cs" Inherits="ItsNum" %>
    <!-- Text -->
    <div class="ItsNum<% if (_ReadOnly == "true") { %> readonly <% } %>" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsNum_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <input <% if (_ID != "") { %>id="<%= _ID %>" <% } %>type="text" 
                style="width:<%= _InputWidth %>px; padding-right: <%= _PaddingRWidth%>px; display:none;" class="ItsField ItsNum" 
                data-point="<%= _DecimalPoint %>" 
                data-default="<%= _Value %>"
                data-field="<%= _Field %>" 
                data-readonly="<%= _ReadOnly %>"
                data-minvalue="<%= _MinValue %>"
                data-maxvalue="<%= _MaxValue %>"
                autocomplete="off"
                value="<%= _Value %>" <% if (_ReadOnly == "true") { %>readonly="readonly" <% } %>
                />
            <input type="text" class="ItsNumView" autocomplete="off" style="width:<%= _InputWidth %>px; padding-right: <%= _PaddingRWidth%>px; " 
                <% if (_ReadOnly == "true") { %>readonly="readonly" <% } %> 
                />
            <div class="ItsNum_button" style="width:<%= _ButtonWidth %>px; border-left:<%= _ButtonBorder %>; margin-right:<%= _MarginRight %>px;">
                <div class="ItsNum_plus"><i class="fa fa-sort-up"></i></div>
                <div class="ItsNum_bar"></div>
                <div class="ItsNum_minus"><i class="fa fa-sort-down"></i></div>
            </div>
        </div>
    </div>