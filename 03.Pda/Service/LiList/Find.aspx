<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Find.aspx.cs" Inherits="Find" %>
<% for (int i = 0; i < LiList.Rows.Count; i++) { %>
                        <li>
                            <span class="no"><%= (i + 1) %></span>
                            <% for (int j = 1; j < _TITLE_LIST.Length; j++) { %>
                            <span class="list" style="white-space:normal; width:<%= _WIDTH_LIST[j] %>px;"><%= LiList.Rows[i][j-1] %></span>
                            <% } %>
                        </li><% } %>