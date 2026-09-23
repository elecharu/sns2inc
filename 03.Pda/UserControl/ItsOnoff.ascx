<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsOnoff.ascx.cs" Inherits="ItsOnoff" %>
    <!-- Onoff -->
    <div class="ItsOnoff" 
        style="float:<%= _Float %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsOnoff_table">
            <span style="width:<%= _LabelWidth %>px;<% if (_Required) { %>color:red;<% } %>"><%= _Label %></span>
            <div <% if (_ID != "")
                { %>id="<%= _ID %>" <% } %>
                class="ItsField ItsOnoff_button"
                tabindex="0"
                data-value="<%= _Value %>""
                data-field="<%= _Field %>"
                data-default="<%= _Value %>"
                data-ontext="<%= _OnText %>"
                data-offtext="<%= _OffText %>"
                data-readonly="<%= _ReadOnly %>"
                data-oncolor="<%= _OnColor %>"
                data-offcolor="<%= _OffColor %>"
                <% if (_InputWidth > 0){%>style=" width:<%= _InputWidth%>px;"<%}%>
                >
                <% if (_Value == "Y")
                {%>
                <div style="vertical-align:middle;">
                    <strong class="ItsOnoff_button_on"><%= _OnText %></strong>
                    <span style="margin: 0px 5px; padding: 2px 5px; "><%= _OffText %></span>
                </div>
                <%}
                else
                { %>
                <div style="vertical-align:middle;">
                    <span style="margin: 0px 5px; padding: 2px 5px;"><%= _OffText %></span>
                    <strong class="ItsOnoff_button_off" ><%= _OnText %></strong>
                </div>
                <%} %>
            </div>
        </div>
    </div>