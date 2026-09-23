<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Radio.aspx.cs" Inherits="Radio" %>

<% for (int i = 0; i < LENGTH; i++)
    {
        %>
    <input class="ItsRadio_input" type="radio" <%if (FIELD != "")
        {%> name="<%=NAME%>" id="<%= FIELD + i %>" <% }
        else
        { %> name="noname"<%} %>
        style="width: 13px; height: 13px;" value="<%= LiList.Rows[i]["Value"] %>" 
        data-label="<%= LiList.Rows[i]["Label"] %>" data-value="<%= LiList.Rows[i]["Value"] %>"
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
    />
    <label <%if (FIELD != ""){ %> for="<%= FIELD + i %>"<%} %> style="width: 80px; align-content :center; color: black; font-weight:normal; display:inline; vertical-align: text-bottom;"><% if (LiList.Columns.Contains("Tag")) { %> <%= LiList.Rows[i]["Tag"] %><% } else { %><%= LiList.Rows[i]["Label"] %><%} %></label>
<% } %>

<%--<% for (int i = 0; i < LiList.Rows.Count; i++)
    { %>
    <input type="radio" id="<%= i %>" <%if (FIELD != ""){%> name="<%=FIELD%>" <% } %>
        class="ItsField ItsRadioButton" style="width: <%= _InputWidth %>px; height: <%= _InputWidth %>px;" value: <%= LiList.Rows[i][1] %> />
    <span style="width: <%= _LabelWidth %>px;"><%= LiList.Rows[i][0] %></span>
<% } %>--%>