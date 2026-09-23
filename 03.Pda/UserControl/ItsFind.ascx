<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsFind.ascx.cs" Inherits="ItsFind" %>
    <!-- Find -->
    <div class="ItsFind<% if (_ReadOnly == "true") { %> readonly<% } %>" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsFind_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div class="ItsFind_box">
                <input type="text" <% if (_ID != "") { %>id="<%= _ID %>"<% } %> 
                    <% if (_ReadOnly == "true") { %> readonly="readonly"<% } %>
                    style="width:<%= _InputWidth %>px;" class="ItsField ItsFind"
                    data-field="<%= _Field %>" 
                    data-oldvalue="<%= _Value %>" data-default="<%= _Value %>" 
                    data-gpcd="<%= _GPCD %>" 
                    data-proc="<%= _PROC %>"" data-ref01="<%= _REF01 %>" 
                    data-ref02="<%= _REF02 %>" data-ref03="<%= _REF03 %>" 
                    data-ref04="<%= _REF04 %>" data-ref05="<%= _REF05 %>"
                    data-value="<%= _Value %>"
                    autocomplete="off"
                    value="<%= _Value %>" />
                <span class="ItsFind_name" style="width:<%= _NameWidth %>px;"></span>
                <div class="ItsFind_button"><i class="fa fa-search"></i></div>
                <div class="ItsControl_pop" style="min-width:<%= (_InputWidth + _NameWidth + 39) %>px;"
                    data-field="<%= GridField %>"
                    data-title="<%= GridTitle %>"
                    data-width="<%= GridWidth %>"
                    data-length="<%= GridLength %>"
                    data-limit="100">
                    <div style="background-color:whitesmoke;">
                        <%= _TAG_HEAD %>
                    </div>
                    <div class="" style="height:1px;background-color:silver;"></div>
                    <ul style="width:100%; white-space:nowrap; overflow-y:scroll;color:black;">
                        <%= _TAG_LIST %>
                    </ul>
                    <div style="height:1px;background-color:silver;"></div>
                    <div class="ItsFind_limit">
                        <span data-limit="100" class="select">100건</span>
                        <span data-limit="500">500건</span>
                        <span data-limit="1000">1000건</span>
                        <span data-limit="1000000">전체</span>
                    </div>
                </div>
            </div>
        </div>
    </div>