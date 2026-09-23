<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsCheck.ascx.cs" Inherits="ItsCheck" %>
    <!-- Onoff -->
    <div class="ItsCheck" 
        style="float:<%= _Float %>;margin-left:<%= _MarginLeft %>px;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsCheck_table">
            <div <% if (_ID != "")
                { %>id="<%= _ID %>" <% } %>
                class="ItsField ItsCheck_button"
                tabindex="0"
                data-value="<%= _Value %>""
                data-field="<%= _Field %>"
                data-default="<%= _Value %>"
                data-readonly="<%= _ReadOnly %>"
                <% if (_InputWidth > 0){%>style=" width:<%= _InputWidth%>px;"<%}%>
                >
                <% if (_Value == "Y")
                {%>
                <div class="ItsCheck_icon" style="vertical-align:middle;">
                    <i class="fa fa-check-square-o fa-dimGray"></i>
                </div>
                <%}
                else
                { %>
                <div class="ItsCheck_icon" style="vertical-align:middle;">
                    <i class="fa fa-square-o fa-dimGray"></i>
                </div>
                <%} %>
            </div>
            <span <% if(_LabelWidth > -1)  { %>style="width:<%= _LabelWidth %>px;<% } %> <% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
        </div>
    </div>