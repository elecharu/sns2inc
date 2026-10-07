<%-- PAGE --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Master/MasterBase.master" AutoEventWireup="true" CodeFile="TOL0003_R05.aspx.cs" Inherits="TOL0003_R05" %>

<%-- HEAD --%>
<asp:Content ContentPlaceHolderID="CPH_HEAD" Runat="Server">
    <script type="text/javascript" src="TOL0003_R05.js?ver=<%= BasePage.srcVersion %>"></script>
</asp:Content>

<%-- SEARCH --%>
<asp:Content ContentPlaceHolderID="CPH_SEARCH" Runat="Server">
    <Its:div runat="server" ID="sdiv1" Type="SearchPanel">
        <Its:month runat="server" Label="조회년월" Field="SMONTH" ID="sdiv1_mon_SMONTH" />
        <Its:find runat="server" Label="금형" ID="sfind_TOOLCD" Field="TOOLCD" GPCD="TOOLCD" InputWidth="95" />
    </Its:div>
</asp:Content>


<%-- BODY --%>
<asp:Content ContentPlaceHolderID="CPH_BODY" Runat="Server">
    <Its:div runat="server" Type="SplitLeft" ID="bdiv1" LeftWidthPc="16">
        <Its:grid runat="server" ID="grid_TOOL" />
    </Its:div>

    <Its:split runat="server" Type="Vertical" Resizeable="false" />

    <Its:div runat="server" Type="SplitRight" ID="Div2">
        <Its:div runat="server" Type="SplitLeft" ID="Div13">
            <Its:grid runat="server" ID="grid_List" />
        </Its:div>

        <Its:split runat="server" Type="Vertical" Resizeable="false" />

        <Its:div runat="server" Type="SplitRight" ID="Div14">
            <Its:div runat="server" Type="SplitTop" ID="Div3" TopHeightPc="22.5">
                <Its:div runat="server" Type="BasicFloat">
                    <Its:div runat="server" Type="BorderFloat" ID="BDIVTOOL">
                        <Its:text runat="server" Label="금형코드" Field="TOOLCD" ReadOnly="true" />
                        <Its:text runat="server" Label="금형명" Field="TOOLNM" ReadOnly="true" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="고객사" Field="MKCUST" ReadOnly="true" />
                        <Its:text runat="server" Label="품명" Field="TOOLNO" ReadOnly="true" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="차수" Field="CHKKNDCD" ReadOnly="true" />
                        <Its:text runat="server" Label="품번" Field="TOOLNO" ReadOnly="true" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" Label="모델명" Field="MODEL" ReadOnly="true" />
                        <Its:text runat="server" Label="현재타수" Field="CURCNT" ReadOnly="true" />
                        <Its:newline runat="server" />
                        <Its:combo runat="server" Label="정비 항목" ID="TOOLCHK" Field="TOOLCHK" GPCD="TOOLCHK" />
                        <Its:newline runat="server" />
                        <Its:date runat="server" Label="점검일시" ID="b1date_BASEDATE" Field="BASEDATE" ReadOnly="true" />
                        <Its:find runat="server" Label="작업자" ID="b1find_EMPCD" Field="EMPCD" GPCD="EMPCD" />
                        <Its:newline runat="server" />
                    </Its:div>
                </Its:div>

                <Its:div runat="server" Type="BasicFloat">
                    <Its:div runat="server" Type="BorderFloat">
                        <Its:textarea runat="server" ID="tea_CHECKREMARK" Field="CHECKREMARK" Label="" LabelWidth="0" InputWidth="360" InputHeight="140"  />
                    </Its:div>
                </Its:div>

                <Its:div runat="server" Type="BasicFloat">
                    <Its:div runat="server" Type="BorderFloat">
                        <Its:label runat="server" Text="금형 등급 기준" Bold="true" MarginLeft="5" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" ID="LAB_A1" Label="" LabelWidth="10" ReadOnly="true" InputWidth="50" />
                        <Its:text runat="server" ID="LAB_A2" Label="" LabelWidth="0" ReadOnly="true"
                            InputWidth="150" Field="A" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" ID="LAB_B1" Label="" LabelWidth="10" ReadOnly="true" InputWidth="50" />
                        <Its:text runat="server" ID="LAB_B2" Label="" LabelWidth="0" ReadOnly="true"
                            InputWidth="150" Field="B" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" ID="LAB_C1" Label="" LabelWidth="10" ReadOnly="true" InputWidth="50" />
                        <Its:text runat="server" ID="LAB_C2" Label="" LabelWidth="0" ReadOnly="true"
                            InputWidth="150" Field="C" />
                        <Its:newline runat="server" />
                        <Its:text runat="server" ID="LAB_D1" Label="" LabelWidth="10" ReadOnly="true" InputWidth="50" />
                        <Its:text runat="server" ID="LAB_D2" Label="" LabelWidth="0" ReadOnly="true"
                            InputWidth="150" Field="D" />
                        <Its:newline runat="server" />
                        <Its:label runat="server" Text=" " />
                    </Its:div>
                </Its:div>

            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" ID="Div1">

            <Its:div runat="server" Type="SplitTop" ID="Div10" TopHeightPc="24">
          
                    <Its:grid runat="server" ID="grid_CHECKSCO" />

            </Its:div>

            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" ID="Div17">

                <Its:div runat="server" Type="SplitTop" ID="Div4" TopHeightPc="21">
                    
                    <Its:div runat="server" Type="SplitTop" ID="Div18">
                        <Its:label runat="server" Text="세척 주기" />
                    </Its:div>

                    <Its:split runat="server" Type="Horizon" Resizeable="false" />

                    <Its:div runat="server" Type="SplitDown" ID="Div19" TopHeightPc="15">
                        <Its:grid runat="server" ID="grid_PURI" />
                    </Its:div>

                </Its:div>
                    

                    <Its:split runat="server" Type="Horizon" Resizeable="false" />

                    <Its:div runat="server" Type="SplitDown" ID="Div5">
                        <Its:div runat="server" Type="SplitTop" ID="Div7">

                            <Its:div runat="server" Type="SplitLeft" ID="Div6" LeftWidthPc="50">
                                
                                <Its:div runat="server" Type="SplitTop" ID="Div20">
                                    <Its:label runat="server" Text="A 등급 이상 정비 내용" />
                                </Its:div>
                                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                <Its:div runat="server" Type="SplitDown" ID="Div21">
                                    <Its:grid runat="server" ID="grid_A" />
                                </Its:div>


                            </Its:div>
                            <Its:split runat="server" Type="Vertical" Resizeable="false" />

                            <Its:div runat="server" Type="SplitRight" ID="Div8">

                                
                                <Its:div runat="server" Type="SplitTop" ID="Div22">
                                    <Its:label runat="server" Text="B 등급 이상 정비 내용" />
                                </Its:div>
                                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                <Its:div runat="server" Type="SplitDown" ID="Div23">
                                    <Its:grid runat="server" ID="grid_B" />
                                </Its:div>

                            </Its:div>
                        </Its:div>


                        <Its:split runat="server" Type="Horizon" Resizeable="false" />

                        <Its:div runat="server" Type="SplitDown" ID="Div9">

                            <Its:div runat="server" Type="SplitTop" ID="Div15">
                                <Its:div runat="server" Type="SplitLeft" ID="Div11" LeftWidthPc="50">

                                    <Its:div runat="server" Type="SplitTop" ID="Div24" >
                                        <Its:label runat="server" Text="C 등급 이상 정비 내용 (경정비)" />
                                    </Its:div>
                                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                    <Its:div runat="server" Type="SplitDown" ID="Div25">
                                        <Its:grid runat="server" ID="grid_C" />
                                    </Its:div>

                                </Its:div>
                                <Its:split runat="server" Type="Vertical" Resizeable="false" />

                                <Its:div runat="server" Type="SplitRight" ID="Div12">
                                    
                                    <Its:div runat="server" Type="SplitTop" ID="Div26">
                                        <Its:label runat="server" Text="D 등급 이상 정비 내용 (경정비)" />
                                    </Its:div>
                                    <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                    <Its:div runat="server" Type="SplitDown" ID="Div27">
                                        <Its:grid runat="server" ID="grid_D" />
                                    </Its:div>

                                </Its:div>
                            </Its:div>

                            <Its:split runat="server" Type="Horizon" Resizeable="false" />

                            <Its:div runat="server" Type="SplitDown" ID="Div16">
                                <Its:textarea runat="server" ID="Tea_REMARK" Label="금형 정비 및 개선 사항" InputWidth="360" InputHeight="40" />
                            </Its:div>
                        </Its:div>
                    </Its:div>
                </Its:div>

            </Its:div>
        </Its:div>
        
        </Its:div>
</asp:Content>

<%-- POP --%>
<asp:Content ContentPlaceHolderID="CPH_POP" runat="server">
    
    <Its:pop runat="server" ID="pop1" Title="점검항목 등록" Type="add" Width="1300" Height="750">
        <Its:div runat="server" Type="SplitTop" ID="PDiv17" TopHeightPc="25">
            <Its:div runat="server" Type="BasicFloat">
                <Its:div runat="server" Type="BorderFloat" ID="PDiv18">
                    <Its:text runat="server" Label="금형코드" ID="p_TOOLCD" Field="TOOLCD" ReadOnly="true" />
                    <Its:text runat="server" Label="금형명" Field="TOOLNM" ReadOnly="true" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="고객사" Field="MKCUST" ReadOnly="true" />
                    <Its:text runat="server" Label="품명" Field="TOOLNO" ReadOnly="true" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="차수" Field="CHKKNDCD" ReadOnly="true" />
                    <Its:text runat="server" Label="품번" Field="TOOLNO" ReadOnly="true" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" Label="모델명" Field="MODEL" ReadOnly="true" />
                    <Its:num runat="server" Label="현재타수" ID="p_CURCNT" Field="CURCNT" ReadOnly="true" />
                    <Its:newline runat="server" />
                    <Its:combo runat="server" Label="정비 항목" ID="p_TOOLCHK" Field="TOOLCHK" GPCD="TOOLCHK" />
                    <Its:newline runat="server" />
                    <Its:date runat="server" Label="점검일시" ID="p_BASEDATE" Field="BASEDATE" />
                    <Its:find runat="server" Label="작업자" ID="p_EMPCD" Field="EMPCD" GPCD="EMPCD" />
                </Its:div>
            </Its:div>

            <Its:div runat="server" Type="BasicFloat">
                <Its:div runat="server" Type="BorderFloat">
                    <Its:textarea runat="server" ID="tea_CHECKREMARK_P" Field="CHECKREMARK" Label="" LabelWidth="0" InputWidth="360" InputHeight="140"  />
                </Its:div>
            </Its:div>

            <Its:div runat="server" Type="BasicFloat">
                <Its:div runat="server" Type="BorderFloat">
                    <Its:label runat="server" Text="금형 보증 Shot 수" Bold="true" MarginLeft="5" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" ID="LAB_PA1" Label="" LabelWidth="10" ReadOnly="true" />
                    <Its:text runat="server" ID="LAB_PA2" Label="" LabelWidth="0" ReadOnly="true" InputWidth="150" Field="A" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" ID="LAB_PB1" Label="" LabelWidth="10" ReadOnly="true" />
                    <Its:text runat="server" ID="LAB_PB2" Label="" LabelWidth="0" ReadOnly="true" InputWidth="150" Field="B" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" ID="LAB_PC1" Label="" LabelWidth="10" ReadOnly="true" />
                    <Its:text runat="server" ID="LAB_PC2" Label="" LabelWidth="0" ReadOnly="true" InputWidth="150" Field="C" />
                    <Its:newline runat="server" />
                    <Its:text runat="server" ID="LAB_PD1" Label="" LabelWidth="10" ReadOnly="true" />
                    <Its:text runat="server" ID="LAB_PD2" Label="" LabelWidth="0" ReadOnly="true" InputWidth="150" Field="D" />
                    <Its:newline runat="server" />
                </Its:div>
            </Its:div>

        </Its:div>

        <Its:split runat="server" Type="Horizon" Resizeable="false" />

        <Its:div runat="server" Type="SplitDown" ID="Div30">
            <Its:div runat="server" Type="SplitTop" ID="PDiv20" TopHeightPc="23.5">
                <Its:grid runat="server" ID="grid_CHECKSCO_P" />            
            </Its:div>
            
            <Its:split runat="server" Type="Horizon" Resizeable="false" />

            <Its:div runat="server" Type="SplitDown" >
                <Its:div runat="server" Type="SplitTop" ID="Div28" TopHeightPc="16">
                    <Its:grid runat="server" ID="grid_PPURI" />  
                </Its:div>       
                
                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                <Its:div runat="server" Type="SplitDown" ID="PDiv19">
                    <Its:div runat="server" Type="SplitTop" ID="PDiv22">
                        <Its:div runat="server" Type="SplitTop" ID="Div31">
                            <Its:div runat="server" Type="SplitLeft" ID="Div35">

                                <Its:div runat="server" Type="SplitTop" ID="Div36">
                                    <Its:label runat="server" Text="A 등급 이상 정비 내용" />
                                </Its:div>

                                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                                <Its:div runat="server" Type="SplitDown" ID="Div37">
                                    <Its:grid runat="server" ID="grid_PA" />
                                </Its:div>

                            </Its:div>

                            <Its:split runat="server" Type="Vertical" Resizeable="false" />

                            <Its:div runat="server" Type="SplitRight" ID="Div38">
                                <Its:div runat="server" Type="SplitTop" ID="Div39">
                                    <Its:label runat="server" Text="B 등급 이상 정비 내용" />
                                </Its:div>

                                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                <Its:div runat="server" Type="SplitDown" ID="Div40">
                                    <Its:grid runat="server" ID="grid_PB" />
                                </Its:div>

                            </Its:div>

                        </Its:div>
                        <Its:split runat="server" Type="Horizon" Resizeable="false" />
                        
                        <Its:div runat="server" Type="SplitDown" ID="Div32">

                            <Its:div runat="server" Type="SplitLeft" ID="Div41">

                                <Its:div runat="server" Type="SplitTop" ID="Div42">
                                    <Its:label runat="server" Text="C 등급 이상 정비 내용 (경정비)" />
                                </Its:div>

                                <Its:split runat="server" Type="Horizon" Resizeable="false" />

                                <Its:div runat="server" Type="SplitDown" ID="Div43">                                                
                                 <Its:grid runat="server" ID="grid_PC" />
                                </Its:div>

                            </Its:div>

                            <Its:split runat="server" Type="Vertical" Resizeable="false" />

                            <Its:div runat="server" Type="SplitRight" ID="Div44">
                                <Its:div runat="server" Type="SplitTop" ID="Div45">
                                    <Its:label runat="server" Text="D 등급 이상 정비 내용 (경정비)" />
                                </Its:div>

                                <Its:split runat="server" Type="Horizon" Resizeable="false" />
                                <Its:div runat="server" Type="SplitDown" ID="Div46">
                                    <Its:grid runat="server" ID="grid_PD" />
                                </Its:div>

                            </Its:div>


                            
                        </Its:div>  

                    </Its:div>
                    <Its:split runat="server" Type="Horizon" Resizeable="false" />

                    <Its:div runat="server" Type="SplitDown" ID="Div29">
                        <Its:textarea runat="server" ID="PTea_REMARK" Field="REMARK" Label="금형 정비 및 개선 사항" InputWidth="500" InputHeight="50"  />
                    </Its:div>  

                </Its:div> 
                

        </Its:div>
        </Its:div>
    </Its:pop>



</asp:Content>