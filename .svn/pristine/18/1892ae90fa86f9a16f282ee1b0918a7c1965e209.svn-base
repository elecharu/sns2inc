<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsPop.ascx.cs" Inherits="ItsPop" %>
<!-- ItsPop -->
<div <% if (_ID != "") { %>id="<%= _ID %>" <% } %> class="ItsPop" title="<%= _Title %>" 
    data-width="<%= _Width %>" data-height="<%= _Height %>" data-modal="<%= _Modal %>" data-resizable="<%= _Resizable %>" data-type="<%= _Type %>"
    style="display:none; <% if (_Type == "add") { %> padding:10px <% } %> ">
    <%= Text %>
    <% if (_Type == "add")
        { %>
        <div class="ItsPopButtons">
            <div class="ItsPopButtonsInner">
                <div id="<%= _AddID %>" class="ItsButton addPop" style="float:left;" data-disabled="false" data-loading="true">
                    <div class="ItsButton_table" tabindex="0" >
                        <span style="font-weight:bold;"><%= _AddBtnName %></span>
                    </div>
                </div>
                <div id="<%= _CancelID %>" class="ItsButton addPop" style="float:left;" data-disabled="false" data-loading="true">
                    <div class="ItsButton_table" tabindex="0" >
                        <span style="font-weight:bold;"><%= _CancelBtnName %></span>
                    </div>
                </div>
            </div>
        </div>
    <%  } %>
</div>