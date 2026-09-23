<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsOnoff.ascx.cs" Inherits="ItsOnoff" %>
    <!-- Onoff -->
    <div class="ItsOnoff" 
        style="float:<%= _Float %>;
        <% if (_Hidden == "true") { %>display:none;<% } %>
        <% if (_MarginLeft != -1) { %>margin-left:<%= _MarginLeft %>px;<% } %>
        <% if (_MarginRight != -1) { %>margin-right:<%= _MarginRight %>px;<% } %>
        <% if (_MarginTop != -1) { %>margin-top:<%= _MarginTop %>px;<% } %>
        <% if (_MarginBottom != -1) { %>margin-bottom:<%= _MarginBottom %>px;<% } %>">
        <div class="ItsOnoff_table" <% if (_Tooltip != "") { %>title="<%= _Tooltip %>" <% } %> >
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
                <div class="ItsOnoff_on">
                    <p class="ItsOnoff_button_on">●</p>
                    <span class="ItsOnoff_button_onText"><%= _OnText %></span>
                </div>
                <%}
                else
                { %>
                <div class="ItsOnoff_off">
                    <span class="ItsOnoff_button_offText"><%= _OffText %></span>
                    <p class="ItsOnoff_button_off" >●</p>
                </div>
                <%} %>
            </div>
        </div>
    </div>