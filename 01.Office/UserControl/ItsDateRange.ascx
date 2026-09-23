<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsDateRange.ascx.cs" Inherits="ItsDateRange" %>
    <!-- Date -->
    <div class="ItsDateRange"<% if (_ReadOnly == "true") { %> readonly="readonly"<% } %> 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsDateRange_table" <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsDateRange_box">
                <input type="text" <% if (_ID_F != "") { %>id="<%= _ID_F %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:whitesmoke; <% } %>" 
                    class="ItsField ItsFieldFrom ItsDateRange_F" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _FieldFrom %>" 
                    data-value="<%= _ValueFrom %>"
                    data-default="<%= _ValueFrom %>"
                    value="<%= _ValueFrom %>"
                    autocomplete="off"
                    />
                <input type="text" <% if (_ID_T != "") { %>id="<%= _ID_T %>"<% } %>
                    style="width:<%= _InputWidth %>px;<% if (_ReadOnly == "true") { %> background-color:whitesmoke; <% } %>" 
                    class="ItsField ItsFieldTo ItsDateRange_T" 
                    <% if (_ReadOnly == "true") { %> readonly="readonly" <% } %>
                    data-field="<%= _FieldTo %>" 
                    data-value="<%= _ValueTo %>"
                    data-default="<%= _ValueTo %>"
                    value="<%= _ValueTo %>"
                    autocomplete="off"
                    />
                <div class="ItsDateRange_button"></div>
                <div class="ItsControl_pop" style="display:none;">
                    <div>
                        <div class="ItsDateRange_calendar_F"></div>
                        <div class="ItsDateRange_calendar_T"></div>
                    </div>
                    <div class="ItsDateRange_innerbtn_div">
                        <div class="ItsDateRange_innerbtn" data-btnrange="d0">당일</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="x1">당월</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="x2">전월</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="d6">1주일</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="m1">1개월</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="yt">오늘까지</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="y0">당년</div>
                        <div class="ItsDateRange_innerbtn" data-btnrange="y1">전년</div>
                        <div class="ItsDateRange_close">확인</div>
                    </div>
                </div>
            </div>
        </div>
    </div>