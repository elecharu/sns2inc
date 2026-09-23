<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDateRange.ascx.cs" Inherits="ItsDateRange" %>
    <!-- Date -->
    <div class="ItsDateRange"<% if (_ReadOnly == "true") { %> readonly="readonly"<% } %> 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsDateRange_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsDateRange_box">
                <input type="text" <% if (_ID_F != "") { %>id="<%= _ID_F %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:aliceblue; <% } %>" 
                    class="ItsField ItsFieldFrom ItsDateRange_F" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _FieldFrom %>" 
                    data-value="<%= _ValueFrom %>"
                    data-default="<%= _ValueFrom %>"
                    value="<%= _ValueFrom %>"
                    autocomplete="off"
                    />
                <input type="text" <% if (_ID_T != "") { %>id="<%= _ID_T %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:aliceblue; <% } %>" 
                    class="ItsField ItsFieldTo ItsDateRange_T" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _FieldTo %>" 
                    data-value="<%= _ValueTo %>"
                    data-default="<%= _ValueTo %>"
                    value="<%= _ValueTo %>"
                    autocomplete="off"
                    />
                <div class="ItsDateRange_button"><i class="fa fa-calendar"></i></div>
                <div class="ItsControl_pop" style="display:none;">
                    <div>
                        <div class="ItsDateRange_calendar_F"></div>
                        <div class="ItsDateRange_calendar_T"></div>
                    </div>
                    <div style="padding:5px 0px;border-top:1px solid silver;text-align:center;">
                        <div class="ItsDateRange_close">확인</div>
                    </div>
                </div>
            </div>
        </div>
    </div>