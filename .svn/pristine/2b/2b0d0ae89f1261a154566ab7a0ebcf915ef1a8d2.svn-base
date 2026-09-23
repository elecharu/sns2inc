<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsLabel.ascx.cs" Inherits="ItsLabel" %>
    <!-- Label -->
    <div class="ItsLabel" 
        style="float:<%= _Float %>;margin:<%= _Margin %>;<% if (_Hidden == "true") { %>display:none;<% } %>">
        <div class="ItsLabel_table" style="<% if (_BackColor != "Transparent") { %>background-color:<%= _BackColor %>;<% } %>">
            <span <% if (_ID != "") { %>id="<%= _ID %>"<% } %>
                style="
                text-align:<%= _Align %>;
                <% if (_Width != -1) { %>width:<%= _Width %>px;<% } %>
                <% if (_FontSize != 12) { %>font-size:<%= _FontSize %>px;<% } %>
                <% if (_Bold == "true") { %>font-weight:bold;<% } %>
                <% if (_Italic == "true") { %>font-style:italic;<% } %>
                text-decoration:<% if (_UnderLine == "true") { %>underline<% } %><% if (_CancelLine == "true") { %> line-through<% } %>;
                <% if (_ForeColor != "Black") { %>color:<%= _ForeColor %>;<% } %>
            "><%= _Text %></span>
        </div>
    </div>