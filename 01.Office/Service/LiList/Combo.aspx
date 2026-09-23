<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Combo.aspx.cs" Inherits="Combo" %>
<% for (int i = 0; i < LiList.Rows.Count; i++) { %>
                    <li data-label="<%= LiList.Rows[i]["Label"] %>" data-value="<%= LiList.Rows[i]["Value"] %>"
                        data-ref01="<%= LiList.Rows[i]["REF01"] %>" data-ref11="<%= LiList.Rows[i]["REF11"] %>"
                        data-ref02="<%= LiList.Rows[i]["REF02"] %>" data-ref12="<%= LiList.Rows[i]["REF12"] %>"
                        data-ref03="<%= LiList.Rows[i]["REF03"] %>" data-ref13="<%= LiList.Rows[i]["REF13"] %>"
                        data-ref04="<%= LiList.Rows[i]["REF04"] %>" data-ref14="<%= LiList.Rows[i]["REF14"] %>"
                        data-ref05="<%= LiList.Rows[i]["REF05"] %>" data-ref15="<%= LiList.Rows[i]["REF15"] %>"
                        data-ref06="<%= LiList.Rows[i]["REF06"] %>" data-ref16="<%= LiList.Rows[i]["REF16"] %>"
                        data-ref07="<%= LiList.Rows[i]["REF07"] %>" data-ref17="<%= LiList.Rows[i]["REF17"] %>"
                        data-ref08="<%= LiList.Rows[i]["REF08"] %>" data-ref18="<%= LiList.Rows[i]["REF18"] %>"
                        data-ref09="<%= LiList.Rows[i]["REF09"] %>" data-ref19="<%= LiList.Rows[i]["REF19"] %>"
                        data-ref10="<%= LiList.Rows[i]["REF10"] %>" data-ref20="<%= LiList.Rows[i]["REF20"] %>"
                        ><%= LiList.Rows[i]["Label"] %></li><% } %>