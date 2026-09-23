<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsCheck.ascx.cs" Inherits="ItsCheck" %>
    <!-- Onoff -->
    <div class="ItsCheck" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsCheck_table" <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
            <% if (_LabelPos == "left")
                { %>
                <span class="ItsCheck_LeftSpan" <% if(_LabelWidth > -1)  { %>style="width:<%= _LabelWidth %>px;<% } %> <% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <%} %>
            <div <% if (_ID != "")
                { %>id="<%= _ID %>" <% } %>
                class="ItsField ItsCheck_button"
                tabindex="0"
                data-value="<%= _Value %>""
                data-field="<%= _Field %>"
                data-default="<%= _Value %>"
                data-readonly="<%= _ReadOnly %>"
                data-type ="<%= _Type %>"
                <% if (_InputWidth > 0){%>style=" width:<%= _InputWidth%>px;"<%}%>
                >
                <% if (_Value == "Y")
                {%>
                <div class="ItsCheck_icon" style="vertical-align:middle; padding-top: 3px;">
                    <%--<i class="fa fa-check-square fa-optisco"></i>--%>
                    <div class="icon ontype_<%= _Type %>"></div>
                </div>
                <%}
                else
                { %>
                <div class="ItsCheck_icon" style="vertical-align:middle; padding-top: 3px;">
                    <%--<i class="fa fa-square-o fa-silver"></i>--%>
                    <div class="icon offtype_<%= _Type %>"></div>
                </div>
                <%} %>
            </div>
            <% if (_LabelPos == "right")
                { %>
                <span class="ItsCheck_RightSpan" <% if(_LabelWidth > -1)  { %>style="width:<%= _LabelWidth %>px;<% } %> <% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <%} %>
        </div>
    </div>