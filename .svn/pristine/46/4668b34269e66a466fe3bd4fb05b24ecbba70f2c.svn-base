<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsTaxFileManager.ascx.cs" Inherits="ItsTaxFileManager" %>
    <!-- FileManager -->
<div class='ItsTaxFileManager' 
    <% if (_ID != "") { %>id="<%= _ID %>" <% } %> <% if (_Type != "") { %>
    data-type="<%= _Type %>" <% } %> 
    data-disabled="<%= _Readonly %>"
    <% if (_Hidden == "True") { %> style="display:none;" <% } %>  >
    <input <% if (_ID != "") { %>id="<%= _ID_FIMEKEY_HIDDEN %>" <% } %> style="display:none" class="ItsField ItsTaxFileManager" data-field="<%= _Field %>""/>
    <input <% if (_ID != "") { %>id="<%= _ID_FIMENAME_VISIBLE %>" <% } %> class='upload-name' value='파일선택' disabled='disabled'>
    <label <% if (_ID != "") { %>for="<%= _ID_EX_FILENAME %>" <% } %> style='margin-bottom:0px; margin-left: -3px;'>선택</label>
    <input <% if (_ID != "") { %>id="<%= _ID_EX_FILENAME %>" <% } %> type='file' autocomplete="off" <% if (_FileType == "image") { %> accept='image/*' <% } %> class='upload-hidden' onchange="ItsTaxFileManager.$nameChange(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)">
    <input <% if (_ID != "") { %>id="<%= _ID_EX_FILEPATH %>" <% } %> style="display:none" />
    <input <% if (_ID != "") { %>id="<%= _ID_COMPREGNO %>" <% } %> style="display:none" />
    <label class="upload-btn" style="color:CornflowerBlue;"><i class="fa fa-upload" onclick="ItsTaxFileManager.$upload(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)"></i></label>
</div>