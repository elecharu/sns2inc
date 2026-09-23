<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsFind.ascx.cs" Inherits="ItsFind" %>
    <!-- Find -->
    <div class="ItsFind<% if (_ReadOnly == "true")
        { %> readonly<% } %>" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsFind_table"  <% if (_Tooltip != "")
            { %>title="<%= _Tooltip %>" data-html="true" <% } %>  >
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsFind_box">
                <input type="text" <% if (_ID != "")
                    { %>id="<%= _ID %>"<% } %> 
                    <% if (_ReadOnly == "true")
                    { %> readonly="readonly"<% } %>
                    style="<%if(_FindType == "mini") { %> display:none; <%; }%> width:<%= _InputWidth %>px; " 
                    class="ItsField ItsFind ItsFind_code"
                    data-field="<%= _Field %>" 
                    data-oldvalue="<%= _Value %>" data-default="<%= _Value %>" 
                    data-gpcd="<%= _GPCD %>" 
                    data-proc="<%= _PROC %>"" 
                    data-ref01="<%= _REF01 %>" data-ref02="<%= _REF02 %>" 
                    data-ref03="<%= _REF03 %>" data-ref04="<%= _REF04 %>"
                    data-ref05="<%= _REF05 %>" data-ref06="<%= _REF06 %>"
                    data-ref07="<%= _REF07 %>" data-ref08="<%= _REF08 %>"
                    data-ref09="<%= _REF09 %>" data-ref10="<%= _REF10 %>"
                    data-value="<%= _Value %>" data-findtype="<%= _FindType %>"
                    autocomplete="off"
                    value="<%= _Value %>" />
                <input class="ItsFind_name" readonly="readonly"  <% if (_FindType != "mini")
                    { %>" tabindex="-1" <% } %>
                    style="<%if(_FindType == "mini") { %> width:<%= _InputWidth %>px; <% if (_ReadOnly == "false") {%> background-color:white; <%; } }
                           else { %> width:<%= _NameWidth %>px; margin-left: -6px; <%; } %> "/>
                <div class="ItsFind_button"></div>
                <div class="ItsControl_pop" style="min-width:<%= (_InputWidth + _NameWidth + 39) %>px;"
                    data-field="<%= GridField %>"
                    data-title="<%= GridTitle %>"
                    data-width="<%= GridWidth %>"
                    data-length="<%= GridLength %>"
                    data-limit="100">
                    <div class="ItsFind_Pophead" >
                        <%= _TAG_HEAD %>
                    </div>
                    <ul style="width:100%; white-space:nowrap; overflow-y:scroll;color:black;">
                        <%= _TAG_LIST %>
                    </ul>
                    <div class="ItsFind_limit" >
                        <a><i class="fa fa-chevron-left"></i></a>
                        <input type="number" value="1" />
                        <a><i class="fa fa-chevron-right"></i></a>
                        <span data-limit="100" class="select">100건</span>
                        <span data-limit="500">500건</span>
                        <span data-limit="1000">1000건</span>
                        <span data-limit="1000000">전체</span>
                    </div>
                </div>
            </div>
        </div>
    </div>