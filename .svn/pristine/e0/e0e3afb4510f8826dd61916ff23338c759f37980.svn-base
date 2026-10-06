<%-- 'CodeFile', 'Inherits' --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" 
    CodeFile="MST3001_R03.aspx.cs" Inherits="MST3001_R03" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="MST3001_R03.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" Type="SearchPanel" ID="sdiv1">
        <Its:find runat="server" Label="부품코드" ID ="PARTCD" Field="PARTCD" GPCD="PARTCD" REF01="EQM" InputWidth="120" NameWidth="180"/>

    </Its:div>
</asp:Content>

<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    
    <Its:div runat="server" Type="SplitSingle">
        <Its:grid runat="server" ID="grid1" />
    </Its:div>



</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    <Its:pop runat="server" ID="pop1" Type="add" Title="설비부품 추가" Width="660">
         <Its:div runat="server" Type="SplitSingle" ID="pdiv1">
            <Its:div runat="server" Type="BasicFloat">     <%-- 이미지 패널 --%>

                <Its:div runat="server" Type="BorderFloat" >
                    <Its:div runat="server" Type="BorderBlock" >
                        <Its:img runat="server" ID="pop_img_PART" Height="117" Width="109" />
                    </Its:div>
                    <Its:newline runat="server" />
                    <Its:fileManager runat="server" StyleType="simple" FileType="image" Field="IMGFILEKEY" ID="pop_file_PART" bindImageId="pop_img_PART" />
                </Its:div>


                <Its:div runat="server" Type="BorderFloat">

                    <Its:text runat="server" Label="부품코드" ID="txt_PARTCD"  Field="PARTCD" InputWidth="150"  />
                    <Its:text runat="server" Label="부품명" ID="txt_PARTNM"  Field="PARTNM" InputWidth="150"  />                 
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="규격" ID="txt_SPEC"  Field="SPEC" InputWidth="150"  />
                    <Its:text runat="server" Label="타입" ID="txt_TYPE"  Field="TYPE" InputWidth="150"  />
                    <Its:newline runat="server" />
                    <Its:num runat="server" Label="재고수량" ID="num_STOCKQTY"  Field="STOCKQTY" InputWidth="150"  />
                    <Its:num runat="server" Label="안전재고수량" ID="num_SAFEQTY"  Field="SAFEQTY" InputWidth="150"  />
                    <Its:newline runat="server" />
                    <Its:combo runat="server" Label="단위" ID="cmb_UNIT" GPCD="ITEMUNIT"  Field="UNIT" InputWidth="110"  />
                    <Its:newline runat="server" />
                    <Its:textarea runat="server" Label="특이사항" ID="Textarea1"  Field="REMARK" InputWidth="393"  />
                </Its:div>
            </Its:div>

        </Its:div>
    </Its:pop>

     <Its:pop runat="server" ID="pop2" Type="common" Title="사진 등록" Width="320" Height="120">
        <Its:div runat="server" Type="SplitSingle" ID="pdiv2">
            <Its:fileManager runat="server" ID="pdiv2_FILEKEY" Field="FILEKEY" MarginLeft="20" MarginTop="20"/>
            <Its:text runat="server" Label="URL" Field="FILEURL" ID="pdiv2_FILEURL" Hidden="true" />
            <Its:button runat="server" Label="다운로드" ID="pdiv2_btn_DOWNLOAD" MarginLeft="20" MarginTop="5"/>
            <Its:button runat="server" Label="파일보기" ID="pdiv2_btn_OPEN_FILE" MarginLeft="10" MarginTop="5"/>
        </Its:div>
    </Its:pop>
</asp:Content>