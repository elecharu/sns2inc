<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsPop.ascx.cs" Inherits="ItsPop" %>
<!-- ItsPop -->
<div <% if (_ID != "") { %>id="<%= _ID %>" <% } %> class="ItsPop" title="<%= _Title %>" 
    data-width="<%= _Width %>" data-modal="<%= _Modal %>" data-resizable="<%= _Resizable %>" data-type="<%= _Type %>"
    style="display:none; <% if (_Type == "add") {%> padding:10px <% } %> ">
    <%= Text %>
    <% if (_Type == "add")
        { %>
        <div style="clear:both;height:0px"></div>
        <div class="BasicBlock" style="background-color:White;position: absolute; bottom:5px; left: 50%; margin-left: -66px;">
            <div id="<%= _AddID %>" class="ItsButton addPop" style="float:left;" data-disabled="false" data-loading="true">
                <div class="ItsButton_table" tabindex="0" style="background-color:rgb(56, 169, 182);color:white;border-color:rgb(56, 169, 182);text-align:center;padding-left: 20px;padding-right: 20px;">
                    <span style="font-weight:bold;">저장</span>
                </div>
            </div>
            <div id="<%= _CancelID %>" class="ItsButton addPop" style="float:left;" data-disabled="false" data-loading="true">
                <div class="ItsButton_table" tabindex="0" style="background-color:rgb(245, 245, 245);color:rgb(118, 118, 118);border-color:rgb(245, 245, 245);text-align:center;padding-left: 20px;padding-right: 20px;">
                    <span style="font-weight:bold;">취소</span>
                </div>
            </div>
        <div style="clear:both;height:0px"></div>   
        </div>
    <%  } %>
</div>