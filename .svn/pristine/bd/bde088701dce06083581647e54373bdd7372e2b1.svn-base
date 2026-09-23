<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetTag.aspx.cs" Inherits="GetTag" %>

<% if (TYPE.ToUpper() == "TEXT") { %>

    <Its:text runat="server" Label="Label" Field="Field" ID="TEXT_ID"/>

<% } else if (TYPE.ToUpper() == "NUM") { %>

    <Its:num runat="server" Label="Label" Field="Field" ID="NUM_ID"/>

<% } else if (TYPE.ToUpper() == "FIND") { %>

    <Its:find runat="server" Label="Label" Field="Field" GPCD="GPCD" REF01="REF01" REF02="REF02" REF03="REF03" REF04="REF04" REF05="REF05" ID="FIND_ID"/>

<% } else if (TYPE.ToUpper() == "FIND_HEAD") { %>
    
    _HEAD_TAG_<%= _FIND_TAG_HEAD %>_HEAD_TAG_
    _GridField_<%= _FIND_GridField %>_GridField_
    _GridTitle_<%= _FIND_GridTitle %>_GridTitle_
    _GridWidth_<%= _FIND_GridWidth %>_GridWidth_
    _GridLength_<%= _FIND_GridLength %>_GridLength_

<% } else if (TYPE.ToUpper() == "COMBO") { %>

    <Its:combo runat="server" Label="Label" Field="Field" GPCD="GPCD" REF01="REF01" REF02="REF02" REF03="REF03" REF04="REF04" REF05="REF05" ID="COMBO_ID"/>

<% } else if (TYPE.ToUpper() == "DATE") { %>

    <Its:date runat="server" Label="Label" Field="Field" ID="DATE_ID"/>

<% } else if (TYPE.ToUpper() == "ONOFF") { %>

    <Its:onoff runat="server" Label="Label" Field="Field"  ID="ONOFF_ID"/>

<% } else if (TYPE.ToUpper() == "BUTTON") { %>

    <Its:button runat="server" Label="Label" ID="BUTTON_ID"/>

<% } %>