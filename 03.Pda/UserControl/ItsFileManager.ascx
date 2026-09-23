<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItsFileManager.ascx.cs" Inherits="ItsFileManager" %>
    <!-- FileManager -->
<div class='ItsFileManager' 
    <% if (_ID != "") { %>id="<%= _ID %>" <% } %> <% if (_bindImageId != "") { %>
    data-bindimageid="<%= _bindImageId %>" <% } %> 
    data-disabled="<%= _Readonly %>"
    <% if (_StyleType == "simple") { %> style="text-align:center;" <% } %>
    <% if (_Hidden == "True") { %> style="display:none;" <% } %>>
    <input <% if (_ID != "") { %>id="<%= _ID_FIMEKEY_HIDDEN %>" <% } %> style="display:none" autocomplete="off" class="ItsField ItsFileManager" data-field="<%= _Field %>""/>
    <input <% if (_ID != "") { %>id="<%= _ID_FIMENAME_VISIBLE %>" <% } %> class='upload-name' value='파일선택' disabled='disabled' autocomplete="off"
    <% if (_StyleType == "simple") { %> style="display:none;" <% } %>>
    <label <% if (_ID != "") { %>for="<%= _ID_EX_FILENAME %>" <% } %> style='margin-bottom:0px; margin-left: -6px;'>선택</label>
    <input <% if (_ID != "") { %>id="<%= _ID_EX_FILENAME %>" <% } %> type='file' <% if (_FileType == "image") { %> accept='image/*' <% } %> class='upload-hidden' autocomplete="off" onchange="ItsFileManager.$nameChange(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)">
    <% if (_StyleType == "basic")
        { %>  
        <label class="upload-btn" style="color:CornflowerBlue;">
            <i class="fa fa-upload" onclick="ItsFileManager.$upload(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)"></i>
        </label>
        <label class="upload-btn" style="color:LightCoral;margin-left: -6px;">
            <i class="fa fa-times" onclick="ItsFileManager.$delete(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)"></i>
        </label>
    <% } else if (_StyleType == "simple")
       { %>
        <label style='margin-bottom:0px; margin-left: -6px;' onclick="ItsFileManager.Clear(<% if (_ID != "") {%> '<%=_ID%>' <% } %>)">삭제</label>
    <% } %>
</div>