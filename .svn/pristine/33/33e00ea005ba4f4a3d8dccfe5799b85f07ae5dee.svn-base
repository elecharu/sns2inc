<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsRadio.ascx.cs" Inherits="ItsRadio" %>
<!-- RadioButton -->

<div class="ItsField ItsRadio"<% if (_ReadOnly == "true"){ %> readonly="readonly"<% } %>
    style="float: <%= _Float %>; <% if (_Hidden == "true") { %>display: none; <% } %>
                <% if (_Hidden == "true") { %>display: none; <% } %>
                <% if (_Margin != "") { %>margin: <%= _Margin %>; <% } %>">
    
    <div class="ItsRadio_table" <% if (_ID != "") { %>id="<%= _ID %>"<% } %>  
        data-field="<%= _Field %>" data-value="<%= _Value %>"
        data-default="<%= _Value %>" data-gpcd="<%= _GPCD %>"
        data-ref01="<%= _REF01 %>" data-ref02="<%= _REF02 %>"
        data-ref03="<%= _REF03 %>" data-ref04="<%= _REF04 %>"
        data-ref05="<%= _REF05 %>" data-length="<%= _Length %>"
        data-name ="<%= _NAME %>"
        >
        <span class="ItsRadio_span" style="width:<%= _LabelWidth %>px ; <% if(_HiddenLabel){%> display: none;<%} %>"><%= _Label %></span>    
    </div>
    
</div>
