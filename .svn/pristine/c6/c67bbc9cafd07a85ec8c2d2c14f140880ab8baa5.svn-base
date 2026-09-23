/// <reference path="../Script/reference.js" />
/********************************************
 * >>>>> Market: 오픈마켓 요청 >>>>>
 * 2018-12-10: 문재원
 *******************************************/
var ItsMarket = {
    Auction: {
        baseUrl: "../../Service/Market/Auction/",
        
        RevisePolicy_ReqData : function() {
            this.TransPolicyName = "순차발송";                   // 발송정책
            this.ReadyDurationDay = "2";                        // 기간
            this.TransCloseTime = "";                           // 마감시간
            this.TransType = "DomesticInOrderDelivery";  // 발송타입 - 정책과 동일한 타입
        },

        AddItem_ReqData: function () {
            this.CategoryCode = "55090800";             // 카테고리 코드
            this.Name = "";                     // 상품명
            this.Price = "";                    // 가격
            this.SellerDiscount = "0";           // 판매자 할인
            this.IsBundleShipping = "";         // 묶음배송 가능여부
            this.ShipingFeeType = "";           // 묶음배송 여부
            this.ShippingType = "Door2Door";
            this.ShippingFeeChargeType = "";    // 배송비 부담방식
            this.TransPolicyNo = "";            // 발송 정책 번호
            this.Condition = "";                // 금액별 무료배송 설정
            this.Fee = "2500";
            this.ItemHtml = "";                 // 상세설명
            this.Picture1 = "";                 // 이미지
            this.Picture2 = "";
            this.Picture3 = "";
            this.Picture4 = "";
            this.NotiItemValue1 = "상세페이지 참조";   // 품명 및 모델명
            this.NotiItemValue2 = "상세페이지 참조";   // 허가 관련
            this.NotiItemValue3 = "상세페이지 참조";   // 제조국 또는 원산지
            this.NotiItemValue4 = "상세페이지 참조";   // 제조자/수입자
            this.NotiItemValue5 = "상세페이지 참조";   // 관련 연락처
            this.NotiItemValue6 = "상세페이지 참조";    // 예상 배송기간
            this.Status = "OnSale";     // 판매 상태
            this.ApplyPeriod = "90";     // 판매 기간
            this.Type = "NotAvailable";     // 주문옵션 사용방식
            this.Quantity = "9999";         // 재고
            this.Price = "";                // 가격
            this.OptCount;
            this.GridNum = 0;                       // 옵션 구분을 위해 
            this.Option = [];                // 옵션타이틀, 옵션명, 가격
        },

        AddOfficialNotice_ReqData: function () {
            this.ItemID = "";                           // 상품코드
            this.NotiItemValue1 = "상세페이지 참조";   // 품명 및 모델명
            this.NotiItemValue2 = "상세페이지 참조";   // 허가 관련
            this.NotiItemValue3 = "상세페이지 참조";   // 제조국 또는 원산지
            this.NotiItemValue4 = "상세페이지 참조";   // 제조자/수입자
            this.NotiItemValue5 = "상세페이지 참조";   // 관련 연락처
            this.NotiItemValue6 = "상세페이지 참조";   // 예상 배송기간
        },

        ReviseItemSelling_ReqData: function () {
            this.ItemID = "";           // 상품번호
            this.Status = "OnSale";     // 판매 상태
            this.ApplyPeriod = "90";     // 판매 기간
        },

        ReviseItemStock_ReqData: function () {
            this.ItemID = "";               // 상품번호
            this.Quantity = "9999";         // 재고
        },

        ReviseItem_ReqData: function () {
            this.ItemID = "";               // 상품번호
            this.Name = "";
            this.Price = "";
            this.SellerDiscount = "";
            this.TransPolicyNo = "";
            this.ShippingType = "";
            this.ShipingFeeType = "";
            this.ShippingFeeChargeType = "";
            this.Fee = "";
            this.ShipingFeeType = "";
            this.ItemHtml = "";
            this.Picture1 = "";
            this.Picture2 = "";
            this.Picture3 = "";
        },
        ViewItem_ReqData: function () {
            this.ItemID = "";                           // 상품번호
        },
        GetSellingItemList_ReqData: function () {
            this.SearchValue = "";                      // 검색값
            this.SearchTermType = "RegistDate";         // 일자 구분 CloseDate : 마감일, RegistDate: 등록일
            this.SearchTermFrom = "2000-01-01";         // 조회 시작일자
            this.SearchTermTo = "2999-12-31";           // 조회 종료 일자
            this.CategoryCode = "";                     // 카테고리
            this.ModelName = "";                        // 모델명
            this.StatusCode = "All";                    // 판매 상태 전체:All/판매진행:OnSale/일시중지:Pause/판매중지:Stop/직권중지:Block
            this.TransPolicyName = "";                  // 배송정책
        },
        GetPaidOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
        },
        ConfirmReceivingOrder_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        GetDeliveryPrepareList_ReqData: function() {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.AddDay(1); // 조회 종료 일자
        },
        DoShippingGeneral_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.SendDate = ItsHelper.GetYearMonthDay();// 배송일
            this.InvoiceNo = "";                        // 송장번호 (필수)
            this.MessageForBuyer = "";                  // 메세지
            this.ShippingMethodClassficationType = "Door2Door"; //배송타입
            this.DeliveryAgency = "";                   // 택배사 (필수)
            this.DeliveryAgencyName = "";               // 택배사명 (필수)
            this.ShippingEtcMethod = "Nothing";         // 기타배송방법
            this.ShippingEtcAgencyName = "";            // 기타배송방법이름
        },
        GetShippingOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1)
        },
        AddQnAReply_ReqData: function () {
            this.ItemID = ""                            // 상품 번호 (필수)
            this.QuestionNo = "";                       // 질문번호 (필수)
            this.Title = "";                            // 제목 (필수)
            this.Content = "";                          // 내용 (필수)
        },
        GetSellerQnAList_ReqData: function() {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1);
        },
        GetExchangeRequestList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1);
            this.SearchKeyword = "";
        },
        GetReturnList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1);
            this.SearchKeyword = "";
        },
        GetCancelApprovalList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.AddDay(1);         // 조회 종료 일자
        },
        ConfirmCancelApprovalList_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        DoReturnApproval_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        DoReturnHold_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        DoExchangeToReturn_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        DoExchangeSwitch_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.ExchangeCharge = "ChargeToBuyer"       // 누가 배송비 부담할지 (구매자:ChargeToBuyer, 판매자: ChargeToSeller
            this.SendDate = ItsHelper.GetYearMonthDay();// 배송일
            this.InvoiceNo = "";                        // 송장번호 (필수)
            this.MessageForBuyer = "";                  // 메세지
            this.ShippingMethodClassficationType = "Door2Door"; //배송타입
            this.DeliveryAgency = "";                   // 택배사 (필수)
            this.DeliveryAgencyName = "";               // 택배사명 (필수)
            this.ShippingEtcMethod = "Nothing";         // 기타배송방법
            this.ShippingEtcAgencyName = "";            // 기타배송방법이름
        },

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /**
         * 배송 정책 등록
         * @param {ItsMarket.Auction.RevisePolicy_ReqData} data 
         */
        RevisePolicy: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "RevisePolicy.aspx";

            var $data = new ItsMarket.Auction.RevisePolicy_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품등록
         * @param {ItsMarket.Auction.AddItem_ReqData} data 
         */
        AddItem: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "AddItem.aspx";

            var $data = new ItsMarket.Auction.AddItem_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.Name == '' || $data.Price == '' || $data.Picture1 == '' || $data.ItemHtml == '' || $data.Quantity == 0) {
                ItsMsg.Toast('상품 등록 불가 : 필수 입력값이 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품등록2
         * @param {ItsMarket.Auction.AddOfficialNotice_ReqData} data 
         */
        AddOfficialNotice: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "AddOfficialNotice.aspx";

            var $data = new ItsMarket.Auction.AddOfficialNotice_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품등록3
         * @param {ItsMarket.Auction.ReviseItemSelling_ReqData} data 
         */
        ReviseItemSelling: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ReviseItemSelling.aspx";

            var $data = new ItsMarket.Auction.ReviseItemSelling_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품등록4
         * @param {ItsMarket.Auction.ReviseItemStock_ReqData} data 
         */
        ReviseItemStock: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ReviseItemStock.aspx";

            var $data = new ItsMarket.Auction.ReviseItemStock_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품수정
         * @param {ItsMarket.Auction.ReviseItem_ReqData} data 
         */
        ReviseItem: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ReviseItem.aspx";

            var $data = new ItsMarket.Auction.ReviseItem_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.ItemID == '' || ($data.Type == "Name" && $data.Name == "") ||
                 ($data.Type == "Price" && ($data.Price == "" || $data.Price == 0))) {
                ItsMsg.Toast('상품 수정 불가 : 필수 입력값이 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품수정
         * @param {ItsMarket.Auction.ViewItem_ReqData} data 
         */
        ViewItem: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ViewItem.aspx";

            var $data = new ItsMarket.Auction.ViewItem_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매 상품 목록 조회
         * @param {ItsMarket.Auction.GetSellingItemList_ReqData} data
         */
        GetSellingItemList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetSellingItemList.aspx";

            var $data = new ItsMarket.Auction.GetSellingItemList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.Auction.GetPaidOrderList_ReqData} data
         */
        GetPaidOrderList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetPaidOrderList.aspx";

            var $data = new ItsMarket.Auction.GetPaidOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 주문 접수 처리
         * @param {ItsMarket.Auction.ConfirmReceivingOrder_ReqData} data
         */
        ConfirmReceivingOrder: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ConfirmReceivingOrder.aspx";

            var $data = new ItsMarket.Auction.ConfirmReceivingOrder_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('주문 접수 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 준비중 목록 조회
         * @param {ItsMarket.Auction.GetDeliveryPrepareList_ReqData} data
         */
        GetDeliveryPrepareList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetDeliveryPrepareList.aspx";

            var $data = new ItsMarket.Auction.GetDeliveryPrepareList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 처리
         * @param {ItsMarket.Auction.DoShippingGeneral_ReqData} data
         */
        DoShippingGeneral: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "DoShippingGeneral.aspx";

            var $data = new ItsMarket.Auction.DoShippingGeneral_ReqData();
            ItsHelper.CopyObj(data, $data);

            if ($data.DeliveryAgencyName == "롯데택배")
                $data.DeliveryAgencyName = "현대택배";
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 조회
         * @param {ItsMarket.Auction.GetShippingOrderList_ReqData} data
         */
        GetShippingOrderList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetShippingOrderList.aspx";

            var $data = new ItsMarket.Auction.GetShippingOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 답변 등록
         * @param {ItsMarket.Auction.AddQnAReply_ReqData} data
         */
        AddQnAReply: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "AddQnAReply.aspx";

            var $data = new ItsMarket.Auction.AddQnAReply_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.ItemID == undefined || $data.ItemID == '' || $data.ItemID == null ||
                $data.QuestionNo == undefined || $data.QuestionNo == '' || $data.QuestionNo == null ||
                $data.Title == undefined || $data.Title == '' || $data.Title == null ||
                $data.Content == undefined || $data.Content == '' || $data.Content == null) {
                ItsMsg.Toast('답변등록 불가 : 비어있는 값이 있는지 확인하세요', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 목록 조회
         * @param {ItsMarket.Auction.GetSellerQnAList_ReqData} data
         */
        GetSellerQnAList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetSellerQnAList.aspx";

            var $data = new ItsMarket.Auction.GetSellerQnAList_ReqData();
            ItsHelper.CopyObj(data, $data);            
            
            var sdate = new Date($data.StartDate);
            var edate = new Date($data.EndDate);

            var btms = edate.getTime() - sdate.getTime();
            var btDay = btms / (1000*60*60*24);

            if (btDay > 7)
                ItsMsg.Alert("조회기간을 1주일 안으로 설정하세요");
            else
                ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 신청 목록 조회
         * @param {ItsMarket.Auction.GetExchangeRequestList_ReqData} data
         */
        GetExchangeRequestList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetExchangeRequestList.aspx";

            var $data = new ItsMarket.Auction.GetExchangeRequestList_ReqData();
            ItsHelper.CopyObj(data, $data);
            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 신청 목록 조회
         * @param {ItsMarket.Auction.GetReturnList_ReqData} data
         */
        GetReturnList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetReturnList.aspx";

            var $data = new ItsMarket.Auction.GetReturnList_ReqData();
            ItsHelper.CopyObj(data, $data);
            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 신청 목록 조회
         * @param {ItsMarket.Auction.GetCancelApprovalList_ReqData} data
         */
        GetCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetCancelApprovalList.aspx";

            var $data = new ItsMarket.Auction.GetCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);

            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 취소 승인
         * @param {ItsMarket.Auction.ConfirmCancelApprovalList_ReqData} data
         */
        ConfirmCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "ConfirmCancelApprovalList.aspx";

            var $data = new ItsMarket.Auction.ConfirmCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('취소 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 승인
         * @param {ItsMarket.Auction.DoReturnApproval_ReqData} data
         */
        DoReturnApproval: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "DoReturnApproval.aspx";

            var $data = new ItsMarket.Auction.DoReturnApproval_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('반품 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 보류
         * @param {ItsMarket.Auction.DoReturnHold_ReqData} data
         */
        DoReturnHold: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "DoReturnHold.aspx";

            var $data = new ItsMarket.Auction.DoReturnHold_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('반품 보류 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 반품 처리
         * @param {ItsMarket.Auction.DoExchangeToReturn_ReqData} data
         */
        DoExchangeToReturn: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "DoExchangeToReturn.aspx";

            var $data = new ItsMarket.Auction.DoExchangeToReturn_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('교환 반품 처리 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 승인
         * @param {ItsMarket.Auction.DoExchangeSwitch_ReqData} data
         */
        DoExchangeSwitch: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "DoExchangeSwitch.aspx";

            var $data = new ItsMarket.Auction.DoExchangeSwitch_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('교환 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            if ($data.InvoiceNo == undefined || $data.InvoiceNo == '' || $data.InvoiceNo == null) {
                ItsMsg.Toast('교환 승인 불가 : 운송장 번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 정책 조회
         */
        GetPolicy: function (data, success, fail) {
            var url = ItsMarket.Auction.baseUrl + "GetPolicy.aspx";

            var $data = new ItsMarket.Auction.RevisePolicy_ReqData();

            ItsMarket.$callAjax(url, $data, success, fail);
        }
    },
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // 11번가의 파라미터는 순서가 중요 합니다. 임의 변경x
    ElevenSt: {
        baseUrl: "../../Service/Market/ElevenSt/",

        GetSellingItemList_ReqData: function () {
            this.category1 = "";                          // 대분류
            this.category2 = "";                          // 중분류
            this.category3 = "";                          // 소분류
            this.category4 = "";                          // 세부 분류
            this.prdNo = "";                              // 상품 번호
            this.prdNm = "";                              // 상품명
            this.selStatCd = "";                          // 판매상태
            this.selMthdCd = "";                          // 판매 형태
            this.schDateType = "1";                       // 조회 일자 타입
            this.schBgnDt = "20000101";                   // 검색 시작일
            this.schEndDt = "";                           // 검색 종료일
            this.limit = "500";                           // 목록 개수 (필수)
            this.start = "";                              // 목록에서 가져올 시작 순번
            this.end = "";                                // 목록에서 가져올 끝 순번
            this.sellerprdcd = "";                        // 판매자 상품코드
        },
        GetSellingItem_ReqData: function () {
            this.prdNo = "";                    // 상품번호 
            this.GridNum = "";
        },
        AddProduct_ReqData: function () {
            this.prdNo = "";                    // 상품번호 (수정할때만)
            this.category = "";                 // 카테고리
            this.brand = "상세페이지 참조";                    // 브랜드
            this.dlvCnAreaCd = "01";            // 배송가능지역코드
            this.prdNm = "";                    // 상품명
            this.prdImage01 = "";               // 대표이미지
            this.prdImage02 = "";               // 추가이미지
            this.prdImage03 = "";               // 추가이미지
            this.prdImage04 = "";               // 추가이미지
            this.htmlDetail = "";               // 상세설명
            this.orgnTypCd = "01";              // 원산지
            this.orgnTypDtlsCd = "";            // 해외국가코드
            this.orgnNmVal = "상세페이지 참조";
            this.selPrc = "";                   // 판매가
            this.prdSelQty = "9999";
            this.OptCount = "0";                // 옵션갯수
            this.colTitle = "규격";
            this.Option = [];                   // 옵션
            this.CompnentCount = 0;         
            this.Compnent = [];                 // 추가구성
            this.dlvSendCloseTmpltNo = "";   // 발송마감 정책번호
            this.dlvWyCd = "01"                   // 배송방법  01 : 택배  02 : 우편(소포/등기) 03 : 직접전달(화물배달)
            this.dlvCstInstBasiCd = "";         // 배송비종류 01-무료, 02-고정 03-조건부무료
            this.dlvCst1 = "";                  // 배송비
            this.dlvCnt1 = "";                  // 수량별 배송비 이상
            this.dlvCnt2 = "";                  // 수량별 배송비 이하
            this.dlvCst3 = "";                  // 수량별 배송비
            this.dlvCst4 = "";                  // 1개당 배송비
            this.PrdFrDlvBasiAmt = "";          // 조건부 무료상품 기준금액
            this.bndlDlvCnYn = "";               // 묶음배송 가능여부
            this.jejuDlvCst = "0";              // 제주 추가배송비
            this.islandDlvCst = "0";            // 도서산간 추가배송비
            this.rtngdDlvCst = "2500";          // 반품배송비
            this.exchDlvCst = "5000";           // 교환 왕복 배송비
            this.asDetail = "상세페이지 참조"             // AS안내
            this.rtngExchDetail = "상세페이지 참조";           // 반품, 교환안내
            this.cuponcheck = "N";
            this.dscAmtPercnt = "0";
            this.cupnDscMthdCd = "01";          // 01:원, 02:%
            this.GridNum = 0;                       // 옵션 구분을 위해 
            this.sellerPrdCd = "";              // 상품코드
            this.selLimitQty = 0;
            this.ProductOption = "";            // 저장된값 그대로 넣어줄 때 사용
        },

        ReviseProduct_ReqData: function () {
            this.prdNo = "";                    // 상품번호 (필수)
            this.category = "";                 // 카테고리
            this.brand = "상세페이지 참조";                    // 브랜드
            this.prdNm = "";                    // 상품명
            this.prdImage01 = "";               // 대표이미지
            this.prdImage02 = "";               // 추가이미지
            this.prdImage03 = "";               // 추가이미지
            this.prdImage04 = "";               // 추가이미지
            this.htmlDetail = "";               // 상세설명
            this.selPrc = "";                   // 판매가
            this.prdSelQty = "9999";
            this.OptCount = "0";                // 옵션갯수
            this.colTitle = "규격";
            this.Option = [];                   // 옵션
            this.dlvSendCloseTmpltNo = "";   // 발송마감 정책번호
            this.dlvCstInstBasiCd = "";         // 배송비종류 01-무료, 02-고정 03-조건부무료
            this.dlvCst1 = "";                  // 배송비
            this.PrdFrDlvBasiAmt = "";          // 조건부 무료상품 기준금액
            this.bndlDlvCnYn = "";               // 묶음배송 가능여부
            this.jejuDlvCst = "0";              // 제주 추가배송비
            this.islandDlvCst = "0";            // 도서산간 추가배송비
            this.rtngdDlvCst = "2500";          // 반품배송비
            this.exchDlvCst = "5000";           // 교환 왕복 배송비
            this.asDetail = "상세페이지 참조";   // AS안내
            this.rtngExchDetail = "상세페이지 참조";   // 반품, 교환안내
            this.cuponcheck = "N";
            this.dscAmtPercnt = "0";
            this.cupnDscMthdCd = "01";          // 01:원, 02:%
            this.GridNum;                       // 옵션 구분을 위해 
        },

        GetPaidOrderList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);          // 조회 시작일자
            this.endTime = ItsHelper.GetYearMonthDay();     // 조회 종료 일자
        },
        ConfirmReceivingOrder_ReqData: function () {
            this.OrderNo = "";                              // 주문 번호 (필수)
            this.OrderSeq = "";                             // 주문 순번 (필수)
            this.addPrdYn = "N";                            // 추가구성상품 여부 (필수)  현재 추가구성 사용하지 않는다고 가정했습니다.
            this.addPrdNo = "";                             // 추가구성상품 번호 (필수)  현재 추가구성 사용하지 않는다고 가정했습니다.
            this.dlvNo = "";                                // 배송 번호 (필수)
        },
        GetDeliveryPrepareList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);          // 조회 시작일자
            this.endTime = ItsHelper.GetYearMonthDay();     // 조회 종료 일자
        },
        DoShippingGeneral_ReqData: function () {
            this.sendDt = ItsHelper.GetDateFull();          // 배송일 (필수)
            this.dlvMthdCd = "01";                          // 배송방식 (필수)
            this.dlvEtprsCd = "";                           // 배송업체 (필수)
            this.invcNo = "";                               // 송장번호 (필수)
            this.dlvNo = "";                                // 배송번호 (필수)
        },
        GetShippingOrderList_ReqData: function () {
            this.sdate = ItsHelper.AddDay(-14)
            this.edate = ItsHelper.AddDay(1)
        },
        DoStopDisplay_ReqData: function () {
            this.prdNo = "";                                // 상품번호 (필수)
            this.GridNum = "";                              // 그리드 줄번호
        },
        DoRestartDisplay_ReqData: function () {
            this.prdNo = "";                                // 상품번호 (필수)
            this.GridNum = "";                              // 그리드 줄번호
        },
        DoChangePrice_ReqData: function () {
            this.prdNo = "";                                // 상품번호 (필수)
            this.selPrc = "";                               // 상품가격 (필수)
            this.GridNum = "";
        },
        GetSellerQnAList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);          // 검색 시작일
            this.endTime = ItsHelper.GetYearMonthDay();     // 검색 종료일
            this.answerStatus = "00";                       // 상태 00:전체, 01:답변, 02:미답변
        },
        AddQnAReply_ReqData: function () {
            this.brdInfoNo ="";                             // Qna글번호 (필수)
            this.prdNo = "";                                // 상품번호 (필수)
            this.answer = " ";                              // 답변 내용 (필수)
        },
        GetExchangeRequestList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);
            this.endTime = ItsHelper.GetYearMonthDay();
            this.status = "요청";
        },
        GetReturnList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);
            this.endTime = ItsHelper.GetYearMonthDay();
            this.Status = "요청";
        },
        GetCancelApprovalList_ReqData: function () {
            this.status = "요청";
            this.startTime = ItsHelper.AddDay(-6);        // 조회 시작일자
            this.endTime = ItsHelper.GetYearMonthDay();
        },
        ConfirmCancelApprovalList_ReqData: function () {
            this.ordPrdCnSeq = "";                        // 클레임 번호 (필수)
            this.ordNo = "";                              // 주문 번호 (필수)
            this.ordPrdSeq = "";                          // 주문 순번 (필수)
        },
        RefuseCancelApprovalList_ReqData: function () {
            this.ordNo = "";                             // 주문 번호 (필수)
            this.ordPrdSeq = "";                         // 주문 순번 (필수)
            this.ordPrdCnSeq = "";                       // 클레임 번호 (필수)
            this.dlvMthdCd = "";                         // 배송방식 (필수)
            this.sendDt = ItsHelper.GetYearMonthDay();   // 발송 일자 (필수)
            this.dlvEtprsCd = "";                        // 택배사 번호 (필수)
            this.invcNo = "";                            // 송장 번호 (필수)
        },
        DoReturnApproval_ReqData: function () {
            this.ordPrdCnSeq = "";                        // 클레임 번호 (필수)
            this.ordNo = "";                              // 주문 번호 (필수)
            this.ordPrdSeq = "";                          // 주문 순번 (필수)
        },
        DoReturnHold_ReqData: function () {
            this.ordNo = "";                              // 주문 번호 (필수)
            this.ordPrdSeq = "";                          // 주문 순번 (필수)
            this.clmReqSeq = "";                          // 클레임 번호 (필수)
            this.deferRefsRsnCd = "105";                  // 보류사유코드 (필수)
            this.ordCnDtlsRsn = "";                       // 사유 상세 (필수)
        },
        DoExchangeToReturn_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)                   // 11번가 교환 반품 전환 없음 -- 검토
        },
        DoExchangeSwitch_ReqData: function () {
            this.clmReqSeq = "";                          // 클레임 번호 (필수)
            this.ordNo = "";                              // 주문 번호 (필수)
            this.ordPrdSeq = "";                          // 주문 순번 (필수)
            this.dlvEtprsCd = "";                        // 택배사 번호 (필수)
            this.invcNo = "";                            // 송장 번호 (필수)
        },
        ReviseItemStock_ReqData: function () {
            this.prdNo = "";                            // 상품번호(필수)
            this.prdStckNo = "";                        // 재고번호(필수)
            this.stckQty = "";                          // 재고 (필수)
            this.GridNum = "";
        },
        RevisePriceCoupon_ReqData: function () {
            this.prdNo = "";                            // 상품번호(필수)
            this.selPrc = "";                           // 판매가(필수)
            this.cuponcheck = "";                       // 적용여부 (필수)
            this.dscAmtPercnt = "";                     // 수치
            this.cupnDscMthdCd = "";                    // 01 : 원, 02: %
            this.GridNum = "";
        },
        RevisePolicy_ReqData: function () {
            this.sendClfCd = "";                        // 01 순차, 02 당일
            this.sendCmplTerm = "";                     // 순차일 때 날
            this.wkdayPayCmplHm = "";                   // 당일일 때 시간
        },
        SetItemDescription_ReqData: function () {
            this.prdNo = "";                            // 상품번호
            this.prdDescContClob = "";                  // 상세설명
            this.GridNum = "";
        },

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /**
         * 상품 조회
         * @param {ItsMarket.ElevenSt.GetSellingItemList_ReqData} data
         */
        GetSellingItemList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetSellingItemList.aspx";

            var $data = new ItsMarket.ElevenSt.GetSellingItemList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 단일 상품 조회
         * @param {ItsMarket.ElevenSt.GetSellingItem_ReqData} data
         */
        GetSellingItem: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetSellingItem.aspx";

            var $data = new ItsMarket.ElevenSt.GetSellingItem_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 상품 등록
         * @param {ItsMarket.ElevenSt.AddProduct_ReqData} data
         */
        AddProduct: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "AddProduct.aspx";

            var $data = new ItsMarket.ElevenSt.AddProduct_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.asDetail == "")
                $data.asDetail = "상세페이지 참조";
            if ($data.rtngExchDetail == "")
                $data.rtngExchDetail = "상세페이지 참조";
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.ElevenSt.GetPaidOrderList_ReqData} data
         */
        GetPaidOrderList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetPaidOrderList.aspx";

            var $data = new ItsMarket.ElevenSt.GetPaidOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 주문 접수 처리
         * @param {ItsMarket.ElevenSt.ConfirmReceivingOrder_ReqData} data
         */
        ConfirmReceivingOrder: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "ConfirmReceivingOrder.aspx";

            var $data = new ItsMarket.ElevenSt.ConfirmReceivingOrder_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('주문 접수 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 준비중 목록 조회
         * @param {ItsMarket.ElevenSt.GetDeliveryPrepareList_ReqData} data
         */
        GetDeliveryPrepareList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetDeliveryPrepareList.aspx";

            var $data = new ItsMarket.ElevenSt.GetDeliveryPrepareList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 처리
         * @param {ItsMarket.ElevenSt.DoShippingGeneral_ReqData} data
         */
        DoShippingGeneral: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoShippingGeneral.aspx";

            var $data = new ItsMarket.ElevenSt.DoShippingGeneral_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 조회
         * @param {ItsMarket.ElevenSt.GetShippingOrderList_ReqData} data
         */
        GetShippingOrderList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetShippingOrderList.aspx";

            var $data = new ItsMarket.ElevenSt.GetShippingOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매중지
         * @param {ItsMarket.ElevenSt.DoStopDisplay_ReqData} data
         */
        DoStopDisplay: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoStopDisplay.aspx";

            var $data = new ItsMarket.ElevenSt.DoStopDisplay_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매중지해제
         * @param {ItsMarket.ElevenSt.DoRestartDisplay_ReqData} data
         */
        DoRestartDisplay: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoRestartDisplay.aspx";

            var $data = new ItsMarket.ElevenSt.DoRestartDisplay_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 가격변경 
         * @param {ItsMarket.ElevenSt.DoStopDisplay_ReqData} data
         */
        DoChangePrice: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoChangePrice.aspx";

            var $data = new ItsMarket.ElevenSt.DoChangePrice_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * QnA 조회
         * @param {ItsMarket.ElevenSt.GetSellerQnAList_ReqData} data
         */
        GetSellerQnAList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetSellerQnAList.aspx";

            var $data = new ItsMarket.ElevenSt.GetSellerQnAList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 답변 달기
         * @param {ItsMarket.ElevenSt.AddQnAReply_ReqData} data
         */
        AddQnAReply: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "AddQnAReply.aspx";

            var $data = new ItsMarket.ElevenSt.AddQnAReply_ReqData();
            ItsHelper.CopyObj(data, $data);
            
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 신청 목록 조회
         * @param {ItsMarket.ElevenSt.GetExchangeRequestList_ReqData} data
         */
        GetExchangeRequestList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetExchangeRequestList.aspx";

            var $data = new ItsMarket.ElevenSt.GetExchangeRequestList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 신청 목록 조회
         * @param {ItsMarket.ElevenSt.GetReturnList_ReqData} data
         */
        GetReturnList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetReturnList.aspx";

            var $data = new ItsMarket.ElevenSt.GetReturnList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 신청 목록 조회
         * @param {ItsMarket.ElevenSt.GetCancelApprovalList_ReqData} data
         */
        GetCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetCancelApprovalList.aspx";

            var $data = new ItsMarket.ElevenSt.GetCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 승인
         * @param {ItsMarket.ElevenSt.ConfirmCancelApprovalList_ReqData} data
         */
        ConfirmCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "ConfirmCancelApprovalList.aspx";

            var $data = new ItsMarket.ElevenSt.ConfirmCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 거부
         * @param {ItsMarket.ElevenSt.RefuseCancelApprovalList_ReqData} data
         */
        RefuseCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "RefuseCancelApprovalList.aspx";

            var $data = new ItsMarket.ElevenSt.RefuseCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 승인
         * @param {ItsMarket.ElevenSt.DoReturnApproval_ReqData} data
         */
        DoReturnApproval: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoReturnApproval.aspx";

            var $data = new ItsMarket.ElevenSt.DoReturnApproval_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 보류
         * @param {ItsMarket.ElevenSt.DoReturnHold_ReqData} data
         */
        DoReturnHold: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoReturnHold.aspx";

            var $data = new ItsMarket.ElevenSt.DoReturnHold_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 반품 처리
         * @param {ItsMarket.ElevenSt.DoExchangeToReturn_ReqData} data
         */
        DoExchangeToReturn: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoExchangeToReturn.aspx";

            var $data = new ItsMarket.ElevenSt.DoExchangeToReturn_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 승인
         * @param {ItsMarket.ElevenSt.DoExchangeSwitch_ReqData} data
         */
        DoExchangeSwitch: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "DoExchangeSwitch.aspx";

            var $data = new ItsMarket.ElevenSt.DoExchangeSwitch_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 재고 변경
         * @param {ItsMarket.ElevenSt.ReviseItemStock_ReqData} data
         */
        ReviseItemStock: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "ReviseItemStock.aspx";

            var $data = new ItsMarket.ElevenSt.ReviseItemStock_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 할인 변경
         * @param {ItsMarket.ElevenSt.RevisePriceCoupon_ReqData} data
         */

        RevisePriceCoupon: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "RevisePriceCoupon.aspx";

            var $data = new ItsMarket.ElevenSt.RevisePriceCoupon_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송정책 등록
         * @param {ItsMarket.ElevenSt.RevisePolicy_ReqData} data
         */

        RevisePolicy: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "RevisePolicy.aspx";

            var $data = new ItsMarket.ElevenSt.RevisePolicy_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송정책 조회
         */
        GetPolicyList: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "GetPolicyList.aspx";

            ItsMarket.$callAjax(url, "", success, fail);
        },

        /**
         * 상세설명 변경
         * @param {ItsMarket.ElevenSt.SetItemDescription_ReqData} data
         */
        SetItemDescription: function (data, success, fail) {
            var url = ItsMarket.ElevenSt.baseUrl + "SetItemDescription.aspx";

            var $data = new ItsMarket.ElevenSt.SetItemDescription_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        }

    },
    GMarket: {
        baseUrl: "../../Service/Market/GMarket/",

        RevisePolicy_ReqData: function () {
            this.transPolicyNo = "0";
            this.siteId = "2";
            this.sellerCustNo = "";                             // 아이디
            this.transPolicyName = "당일발송";                   // 발송정책
            this.transType = "A";
            this.readyDurationDay = "";                         // 기간
            this.transCloseTime = "[14:00]";                      // 마감시간
            this.defaultIs = false;  // 발송타입 - 정책과 동일한 타입
            
        },
        AddItem_ReqData: function () {
            this.AloginID = "";
            this.GloginID = "";
            this.ACategoryCode = "";
            this.GCategoryCode = "";
            this.GoodsName = "";
            this.GoodsPrice = "";
            this.GoodsCount = "";
            this.StartDate = "";
            this.EndDate = "";
            this.ImgUrl = "";
            this.ImgUrlsub1 = "";
            this.ImgUrlsub2 = "";
            this.Text = "";
            this.IacDeliveryCOMP = "0";
            this.GmktDeliveryCOMP = "0";
            this.DeliveryFeeType = "";                  // 묶음 배송비 타입
            this.BundleDeliveryTempNo = "";             // 묶음 배송번호
            this.EachDeliveryFeeType = "";              // 배송비타입
            this.FeeAmnt = "2500";                      // 배송비
            this.ReturnExchangeFee = "";
            this.Condition = "";                        // 조건부 무료배송 금액
            this.DeliveryFeeSubType = "4"               // 4-수량별차등, 2-개당배송비
            this.IacTransPolicyNo = "0";
            this.GmktTransPolicyNo = "0";
            this.NoticeItemValue = "상세페이지 참조";
            this.ShipmentPlaceNo = "";
            this.ReturnExchangeADDRNo = "";
            this.ObjOptClaseNm1 = "";
            this.Option = [];
            this.OptCount = 0;
            this.CompnentCount = 0;
            this.Compnent = [];                 // 추가구성
            this.DiscountFalse = "true";
            this.DiscountType = "";
            this.DiscountAmt = "";
            this.GridNum = 0;                       // 옵션 구분을 위해
            this.GoodsNo = "";
            this.SiteGoodsNo = "";
            this.CommandType = "";              // 1: 하나만등록  3:옥션,지마켓 둘다 등록  2:수정
            this.RegMarketType = "";            // 0: 둘다  1:옥션  2:지마켓 
            this.ItemCode = "";                 // 상품코드
            this.DeliveryDetail = [];
            this.DeliveryDetailCount = "";
            this.BuyableQuantity = 0;
            this.SiteGoodsCountNo = "";
            this.DiscountAgreement = true;
        },
        SetItemDescription_ReqData: function () {
            this.descNew = "";
            this.siteId = "";
            this.siteGoodsNo = "";
        },
        GetShipmentPlaces_ReqData: function () {
        },
        GetDeliveryFeeTemplates_ReqData: function () {
            this.shipmentPlaceNo = "";
        },
        GetDeliveryFeeTemplateDetails_ReqData: function () {
            this.deliveryFeeTemplateNo = "";
        },
        RegisterDeliveryFeeTemplateAdd_ReqData: function () {
            this.DeliveryFeeType = "";
            this.FeeAmnt = "";
            this.ShipmentPlaceNo = "";
            this.Condition = "";
        },
        GetSellingItemList_ReqData: function () {
            this.startTime = ItsHelper.AddDay(-6);
            this.StatusCode = "";
            this.SiteId = "0";
            this.Keyword = "";
            this.GoodsIds = "";
            this.GoodsName = "";
            this.CategoryCode = "";
            this.page = "";
            this.start = "";
            this.limit = "";
        },
        GetPaidOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
            this.siteGbn = "0";
        },
        ConfirmReceivingOrder_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        GetDeliveryPrepareList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.AddDay(1); // 조회 종료 일자
            this.siteGbn = "0";
        },
        DoShippingGeneral_ReqData: function () {
            this.deliveryInfo = "";                        // 주문 정보 (필수) [주문번호, 택배사번호, 택배사이름, 송장번호]
            this.compNo = "";
        },
        GetShippingOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
            this.siteGbn = "0";
        },
        AddQnAReply_ReqData: function () {
            this.Token = "";                             // 토큰 (필수)
            this.QuestionNo = "";                       // 질문번호 (필수)
            this.Title = "";                            // 제목 (필수)
            this.Content = "";                          // 내용 (필수)
        },
        GetSellerQnAList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
            this.Site = "A";
        },
        GetExchangeRequestList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
            this.SearchKeyword = "";
            this.siteGbn = "1";
        },
        GetReturnList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
            this.SearchKeyword = "";
            this.siteGbn = "1";
            this.Status = "요청";
        },
        GetCancelApprovalList_ReqData: function () {
            this.SearchType = "CC"
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.AddDay(1);         // 조회 종료 일자
            this.siteGbn = "1";
        },
        ConfirmCancelApprovalList_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.sellerCustNo = "";                     // 주문 번호 (필수)
            this.siteGbn = "1";
        },
        DoShippingGeneralCancel_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.InvoiceNo = "";                        // 송장번호 (필수)
            this.DeliveryAgency = "";                   // 택배사 (필수)
            this.siteGbn = "1";
        },
        DoReturnApproval_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.sellerCustNo = "";                     // 주문 번호 (필수)
        },
        DoReturnHold_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.sellerCustNo = "";                     // 주문 번호 (필수)
        },
        DoExchangeToReturn_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.sellerCustNo = "";                     // 주문 번호 (필수)
            this.siteGbn = "1";
        },
        DoExchangeSwitch_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
            this.sellerCustNo = "";                     // 주문 번호 (필수)
            this.SendDate = ItsHelper.GetYearMonthDay();// 배송일
            this.InvoiceNo = "";                        // 송장번호 (필수)
            this.DeliveryAgency = "";                   // 택배사 (필수)
            this.siteGbn = "1";
        },
        GetPolicy_ReqData: function () {                //발송 정책 조회
            this.siteId = "2";                          // 0번 옥션, G마켓 둘다, 1번 옥션, 2번 G마켓                  
            this.sellerCustNo = "";
            this.GID = "";                              // siteId가 0번이 아닌이상 불필요
            this.AID = "";                              // siteId가 0번이 아닌이상 불필요
        },
        ReviseItemSelling_ReqData: function () {        // 전체 필수
            this.Status = "OnSale";                     // OnSale 판매시작 OffSale 판매중지
            this.SiteId = "2";                          // 고정
            this.SiteGoodsNo = "";                      // 사이트 상품 번호
            this.SellerCustNo = "";                     // 주문 번호
            this.SellerId = "";                         // 사용자
            this.GoodsNo = "";                          // 상품 번호
            this.SellType = "";                         // 주문 속성
            this.SellPrice = "";                        // 판매 가격
            this.StockQty = "";                         // 수량
            this.DispEndDate = "";                      // 판매 중지일(형식 : 2019-01-30T14:59:59.000Z)
            this.ItemSiteType = "";                     // 상품 속성
            this.GridNum = "";                          // 그리드 줄번호
        },
        RevisePriceCoupon_ReqData: function () {
            this.SiteId = "2";
            this.SiteGoodsNo = "";
            this.SellerCustNo = "";
            this.GoodsNo = "";
            this.SellType = "";
            this.SellPrice = "";
            this.StockQty = "";
            this.DispEndDate = "";
            this.ItemSiteType = "";
            this.SellerId = "";                            // 할인은 아이디가 필수
            this.start = ItsHelper.GetYearMonthDay();      // 할인 적용 시작일(YYYY-MM-DD)
            this.isRate = "False";                         //True 정률, False 정액
            this.discountValue = "";                       //    할인률      할인액 
            this.isUse = "True";                           // True 사용, False 미사용
            this.GridNum = "";
        },
        ReviseItemStock_ReqData: function () {
            this.SiteId = "2";
            this.SiteGoodsNo = "";
            this.SellerCustNo = "";
            this.SellerId = "";
            this.GoodsNo = "";
            this.SellType = "";
            this.SellPrice = "";
            //this.StockQty = "";                          // 기존 수량은 필요없습니다.
            this.DispEndDate = "";
            this.ItemSiteType = "";
            this.stockQty = "";                            // 수정할 재고 수량
            this.GridNum = "";
        },
        SetPeriodExtend_ReqData: function () {
            this.SiteId = "2";
            this.SiteGoodsNo = "";
            this.SellerCustNo = "";
            this.GoodsNo = "";
            this.SellType = "";
            this.SellPrice = "";
            this.StockQty = "";
            this.DispEndDate = "";
            this.ItemSiteType = "";
            this.SellerId = "";                            // 아이디가 필수
            this.aStatus = "";                             // G마켓은 빈칸 고정
            this.period = "90";                            // 연장 일자
        },
        SetItem_ReqData: function () {
            this.PriceOnly = false;
            this.GoodsNameOnly = false;
            this.SellPrice = "";                           // 변경할 가격
            this.GoodsIds = "";                             // 상품 ID
            this.SiteCategoryCode = "";                     // 카테고리 코드
            this.GoodsName = "";                            // 상품명
            this.DeliveryFeeApplyType = "";                 // 묶음배송(2 묶음배송, 3 개별배송 )
            this.TransPolicyName = "";                      // 발송 정책
            this.ReadyDurationDay = "";                     // 순차발송 일
            this.TransCloseTime = "";                       // 당일발송 시간
            this.StockQty = "";                             // 재고
            this.GridNum = "";
        },
        GetSellingItem_ReqData: function () {
            this.SiteGoodsNo = "";                          // 사이트 상품 번호
            this.GoodsNo = "";                              // 상품 번호
            this.SiteId = "0";                              // G마켓(2), 옥션(1) 구분 번호
            this.GridNum = "";
        },

        SetDeliveryFeeAddService_ReqData: function () {
            this.IacDeliveryCOMP = "";
            this.GmktDeliveryCOMP = "";
            this.DeliveryFeeType = "";                  // 묶음 배송비 타입
            this.BundleDeliveryTempNo = "";             // 묶음 배송번호
            this.EachDeliveryFeeType = "";              // 배송비타입
            this.FeeAmnt = "2500";                      // 배송비
            this.ReturnExchangeFee = "";
            this.Condition = "";                        // 조건부 무료배송 금액
            this.DeliveryFeeSubType = "4";
            this.ShipmentPlaceNo = "";
            this.ReturnExchangeADDRNo = "";
            this.GridNum = 0;                       // 옵션 구분을 위해
            this.DeliveryDetail = [];
            this.DeliveryDetailCount = "";
            this.Item = [];
            this.Count = 0;
        },

        GetItemDescription_ReqData: function () {
            this.SiteGoodsNo = "";                          // 사이트 상품 번호
            this.SiteId = "0";                              // G마켓(2), 옥션(1) 구분 번호
            this.GridNum = "";                              // 상품 번호
        },

        /**
         * 발송 정책 등록
         * @param {ItsMarket.Auction.RevisePolicy_ReqData} data 
         */
        RevisePolicy: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "RevisePolicy.aspx";

            var $data = new ItsMarket.GMarket.RevisePolicy_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 상품등록
         * @param {ItsMarket.GMarket.AddItem_ReqData} data
         */
        AddItem: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "AddItem.aspx";

            var $data = new ItsMarket.GMarket.AddItem_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상세설명수정
         * @param {ItsMarket.GMarket.SetItemDescription_ReqData} data
         */
        SetItemDescription: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "SetItemDescription.aspx";

            var $data = new ItsMarket.GMarket.SetItemDescription_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 출하지조회
         * @param {ItsMarket.GMarket.GetShipmentPlaces_ReqData} data
         */
        GetShipmentPlaces: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetShipmentPlaces.aspx";

            var $data = new ItsMarket.GMarket.GetShipmentPlaces_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 묶음배송 정책조회
         * @param {ItsMarket.GMarket.GetDeliveryFeeTemplates_ReqData} data
         */
        GetDeliveryFeeTemplates: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetDeliveryFeeTemplates.aspx";

            var $data = new ItsMarket.GMarket.GetDeliveryFeeTemplates_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 묶음배송 정책 상세조회
         * @param {ItsMarket.GMarket.GetDeliveryFeeTemplateDetails_ReqData} data
         */
        GetDeliveryFeeTemplateDetails: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetDeliveryFeeTemplateDetails.aspx";

            var $data = new ItsMarket.GMarket.GetDeliveryFeeTemplateDetails_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 묶음배송 정책추가 
         * @param {ItsMarket.GMarket.RegisterDeliveryFeeTemplateAdd_ReqData} data
         */
        RegisterDeliveryFeeTemplateAdd: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "RegisterDeliveryFeeTemplateAdd.aspx";

            var $data = new ItsMarket.GMarket.RegisterDeliveryFeeTemplateAdd_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품조회
         * @param {ItsMarket.GMarket.GetSellingItemList} data
         */
        GetSellingItemList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetSellingItemList.aspx";

            var $data = new ItsMarket.GMarket.GetSellingItemList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.GMarket.GetPaidOrderList_ReqData} data
         */
        GetPaidOrderList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetPaidOrderList.aspx";

            var $data = new ItsMarket.GMarket.GetPaidOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 주문 접수 처리
         * @param {ItsMarket.GMarket.ConfirmReceivingOrder_ReqData} data
         */
        ConfirmReceivingOrder: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "ConfirmReceivingOrder.aspx";

            var $data = new ItsMarket.GMarket.ConfirmReceivingOrder_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('주문 접수 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 준비중 목록 조회
         * @param {ItsMarket.GMarket.GetDeliveryPrepareList_ReqData} data
         */
        GetDeliveryPrepareList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetDeliveryPrepareList.aspx";

            var $data = new ItsMarket.GMarket.GetDeliveryPrepareList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 처리
         * @param {ItsMarket.GMarket.DoShippingGeneral_ReqData} data
         */
        DoShippingGeneral: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoShippingGeneral.aspx";

            var $data = new ItsMarket.GMarket.DoShippingGeneral_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 조회
         * @param {ItsMarket.GMarket.GetShippingOrderList_ReqData} data
         */
        GetShippingOrderList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetShippingOrderList.aspx";

            var $data = new ItsMarket.GMarket.GetShippingOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 답변 등록
         * @param {ItsMarket.GMarket.AddQnAReply_ReqData} data
         */
        AddQnAReply: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "AddQnAReply.aspx";

            var $data = new ItsMarket.GMarket.AddQnAReply_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.Token == undefined || $data.Token == '' || $data.Token == null ||
                $data.QuestionNo == undefined || $data.QuestionNo == '' || $data.QuestionNo == null ||
                $data.Title == undefined || $data.Title == '' || $data.Title == null ||
                $data.Content == undefined || $data.Content == '' || $data.Content == null) {
                ItsMsg.Toast('답변등록 불가 : 비어있는 값이 있는지 확인하세요', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 목록 조회
         * @param {ItsMarket.GMarket.GetSellerQnAList_ReqData} data
         */
        GetSellerQnAList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetSellerQnAList.aspx";

            var $data = new ItsMarket.GMarket.GetSellerQnAList_ReqData();
            ItsHelper.CopyObj(data, $data);

            var sdate = new Date($data.StartDate);
            var edate = new Date($data.EndDate);

            var btms = edate.getTime() - sdate.getTime();
            var btDay = btms / (1000 * 60 * 60 * 24);

            if (btDay > 7)
                ItsMsg.Alert("조회기간을 1주일 안으로 설정하세요");
            else
                ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 신청 목록 조회
         * @param {ItsMarket.GMarket.GetExchangeRequestList_ReqData} data
         */
        GetExchangeRequestList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetExchangeRequestList.aspx";

            var $data = new ItsMarket.GMarket.GetExchangeRequestList_ReqData();
            ItsHelper.CopyObj(data, $data);
            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 신청 목록 조회
         * @param {ItsMarket.GMarket.GetReturnList_ReqData} data
         */
        GetReturnList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetReturnList.aspx";

            var $data = new ItsMarket.GMarket.GetReturnList_ReqData();
            ItsHelper.CopyObj(data, $data);
            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 신청 목록 조회
         * @param {ItsMarket.GMarket.GetCancelApprovalList_ReqData} data
         */
        GetCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetCancelApprovalList.aspx";

            var $data = new ItsMarket.GMarket.GetCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);

            $data.EndDate = ItsHelper.AddDay(1, $data.EndDate);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 거부
         * @param {ItsMarket.GMarket.DoShippingGeneralCancel_ReqData} data
         */
        DoShippingGeneralCancel: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoShippingGeneralCancel.aspx";

            var $data = new ItsMarket.GMarket.DoShippingGeneralCancel_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('발송 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            if ($data.InvoiceNo == undefined || $data.InvoiceNo == '' || $data.InvoiceNo == null) {
                ItsMsg.Toast('발송 불가 : 송장번호가 누락되었습니다.', 3000);
                return;
            }
            if ($data.DeliveryAgency == undefined || $data.DeliveryAgency == '' || $data.DeliveryAgency == null) {
                ItsMsg.Toast('발송 불가 : 택배사정보 오류.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 승인
         * @param {ItsMarket.GMarket.ConfirmCancelApprovalList_ReqData} data
         */
        ConfirmCancelApprovalList: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "ConfirmCancelApprovalList.aspx";

            var $data = new ItsMarket.GMarket.ConfirmCancelApprovalList_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('취소 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 승인
         * @param {ItsMarket.GMarket.DoReturnApproval_ReqData} data
         */
        DoReturnApproval: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoReturnApproval.aspx";

            var $data = new ItsMarket.GMarket.DoReturnApproval_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('반품 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 보류
         * @param {ItsMarket.GMarket.DoReturnHold_ReqData} data
         */
        DoReturnHold: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoReturnHold.aspx";

            var $data = new ItsMarket.GMarket.DoReturnHold_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('반품 보류 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 반품 처리
         * @param {ItsMarket.GMarket.DoExchangeToReturn_ReqData} data
         */
        DoExchangeToReturn: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoExchangeToReturn.aspx";

            var $data = new ItsMarket.GMarket.DoExchangeToReturn_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('교환 반품 처리 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 승인
         * @param {ItsMarket.GMarket.DoExchangeSwitch_ReqData} data
         */
        DoExchangeSwitch: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "DoExchangeSwitch.aspx";

            var $data = new ItsMarket.GMarket.DoExchangeSwitch_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('교환 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            if ($data.InvoiceNo == undefined || $data.InvoiceNo == '' || $data.InvoiceNo == null) {
                ItsMsg.Toast('교환 승인 불가 : 운송장 번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 정책 조회
         * @param {ItsMarket.GMarket.GetPolicy_ReqData} data 
         */
        GetPolicy: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetPolicy.aspx";

            var $data = new ItsMarket.GMarket.RevisePolicy_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매 시작 및 중기
         * @param {ItsMarket.GMarket.ReviseItemSelling_ReqData} data
         */
        ReviseItemSelling: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "ReviseItemSelling.aspx";

            var $data = new ItsMarket.GMarket.ReviseItemSelling_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 할인 설정
         * @param {ItsMarket.GMarket.RevisePriceCoupon_ReqData} data
         */
        RevisePriceCoupon: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "RevisePriceCoupon.aspx";

            var $data = new ItsMarket.GMarket.RevisePriceCoupon_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 재고 조정
         * @param {ItsMarket.GMarket.ReviseItemSelling_ReqData} data
         */
        ReviseItemStock: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "ReviseItemStock.aspx";

            var $data = new ItsMarket.GMarket.ReviseItemStock_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매 기간 연장
         * @param {ItsMarket.GMarket.SetPeriodExtend_ReqData} data
         */
        SetPeriodExtend: function(data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "SetPeriodExtend.aspx";

            var $data = new ItsMarket.GMarket.SetPeriodExtend_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매 가격 변경
         * @param {ItsMarket.GMarket.SetItem_ReqData} data
         */
        SetItem: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "SetItem.aspx";

            var $data = new ItsMarket.GMarket.SetItem_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 단건조회
         * @param {ItsMarket.GMarket.GetSellingItem_ReqData} data
         */

        GetSellingItem: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetSellingItem.aspx";

            var $data = new ItsMarket.GMarket.GetSellingItem_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 배송비 수정
         * @param {ItsMarket.GMarket.SetDeliveryFeeAddService_ReqData} data
         */

        SetDeliveryFeeAddService: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "SetDeliveryFeeAddService.aspx";

            var $data = new ItsMarket.GMarket.SetDeliveryFeeAddService_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },

        /**
         * 상세설명 가져오기 
         * @param {ItsMarket.GMarket.GetItemDescription_ReqData} data
         */
        GetItemDescription: function (data, success, fail) {
            var url = ItsMarket.GMarket.baseUrl + "GetItemDescription.aspx";

            var $data = new ItsMarket.GMarket.GetItemDescription_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        }
    },
    SmartStore: {
        baseUrl: "../../Service/Market/SmartStore/",

        ManageProduct_ReqData: function () {
            this.ProductId = "";                        // 상품번호 
            this.CategoryId = "";                       // 카테고리
            this.Name = "";                             // 상품명
            this.SellerManagementCode = "";             // ITEMCD
            this.OriginCode = "03";                     // 원산지
            this.Image = "";                            // 이미지
            this.DetailContent = "";                    // 상품상세
            this.ASTelNumber = "";                      // as 전화번호
            this.ASContent = "";                        // as 안내
            this.SalePrice = "";                        // 판매가
            this.StockQuantity = "";                    // 재고
            this.MaxQtyPerOrder = "";                   // 1회 최대구매수량
            this.DeliveryType = "1";                    // 1 택배, 등기  2 직접배송
            this.BundleGroupAvailable = "";             // 묶음배송
            this.FeeType = "";                          // 1 무료, 2 조건부무료, 3 유료, 4, 수량별부과 반복(X) 5, 수량별부과 직접설정
            this.BaseFee = "";                          // 배송비
            this.FreeAmount = "";                       // 조건무 무료 조건 금액
            this.SecondBaseQuantity = "";               // 2구간 최소 수량
            this.SecondExtraFee = "";                   // 2구간 추가 배송비
            this.ThirdBaseQuantity = "";                // 3구간 최소 수량
            this.ThirdExtraFee = "";                    // 3구간 추가 배송비
            this.RepeatQuantity = "1";                  // 개당 배송비 반복수량
            this.AreaType = "0";
            this.Area2ExtraFee = "";
            this.Area3ExtraFee = "";
            this.DeliveryCompany = "0";                 // 반품/교환 택배사  0이 기본택배사
            this.ReturnFee = "";                        // 반품배송비
            this.ExchangeFee = "";                      // 교환배송비
            this.DiscountAmount = "0";                  // 판매자 할인
            this.MileageAmount = "";                    // 구매시 적립
            this.PurchaseReviewPoint = "";              // 텍스트 리뷰 적립
            this.PremiumReviewPoint = "";               // 포토/동영상 리뷰 적립
            this.Option = [];                           // 옵션
            this.OptCount = 0;                          // 옵션 갯수
            this.OptionName = "규격";
            this.Compnent = [];                         // 추가상품
            this.CompnentCount = 0;                     // 추가상품 갯수
            this.GridNum = "";
        },
        ChangeProductSaleStatus_ReqData: function () {
            this.ProductId = "";                        // 상품ID
            this.StatusType = "";                       // 판매상태
            this.GridNum = "";
        },
        GetProduct_ReqData: function () {
            this.ProductId = "";                        // 상품ID
            this.GetOption = "false";
            this.GridNum = "";
        },
        GetProductList_ReqData: function () {
            this.ProductId = "";                        // 상품ID
            this.SellerManagementCode = "";             // 판매자 상품코드
            this.StatusType = "";                       // 판매상태
            this.Page = "1";                       // 판매자 상품코드
            this.PageSize = "100";                       // 판매자 상품코드
        },
        GetOption_ReqData: function () {
            this.ProductId = "";                        // 상품ID
        },
        ManageBundleGroup_ReqData: function () {
            this.JAJU = 0;
            this.OTHER = 0;
        },
        GetProductOrderInfoList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay() + ' 23:59:59'; // 조회 종료 일자
            this.STATUS = "PAYED";
        },
        PlaceProductOrder_ReqData: function () {
            this.OrderNo = "";     // 필수
        },
        ShipProductOrder_ReqData: function () {
            this.OrderNo = ""                     // 주문번호
            this.DDATE = ItsHelper.GetDateFull(); // 배송일자
            this.DELIVERYCOMP = "";               // 배송사
            this.INVOICENO = "";                  // 송장번호
        },
        GetCustomerInquiryList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay() + ' 23:59:59'; // 조회 종료 일자
        },
        AnswerCustomerInquiry_ReqData: function () {
            this.ActionType = "INSERT";     // INSERT 답변 등록 UPDATE 답변 수정
            this.InquiryID = ""             // 문의번호
            this.AnswerContent = ""         // 답변 내용
            this.AnswerContentID = ""       // 수정시 답변번호
            this.AnswerTempleteID = ""      // 답변 템플릿 번호
        },
        ApproveCancelApplication_ReqData: function () {
            this.ProductOrderID = ""             // 주문번호
        },
        ApproveCollectedExchange_ReqData: function () {
            this.ProductOrderID = ""             // 주문번호
        },
        ReDeliveryExchange_ReqData: function () {
            this.ProductOrderID = ""                // 주문번호
            this.ReDeliveryMethodCode = "DELIVERY"; // 배송방법
            this.ReDeliveryCompanyCode = "";        // 배송사
            this.ReDeliveryTrackingNumber = "";
            this.ClaimStatus = "";
            this.HoldbackStatus = "";
        },
        ApproveReturnApplication_ReqData: function () {
            this.ProductOrderID = ""             // 주문번호
            this.ClaimDeliveryFeePayMethod = "";
        },
        GetQuestionAnswerList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
        },
        ManageQuestionAnswer_ReqData: function () {
            this.QuestionAnswerId = "";     // 상품 Q&A ID
            this.Answer = ""                // 답변 내용
        },
        /**
         * 상품등록 
         * @param {ItsMarket.SmartStore.ManageProduct_ReqData} data
         */
        ManageProduct: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ManageProduct.aspx";

            var $data = new ItsMarket.SmartStore.ManageProduct_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 상태 변경
         * @param {ItsMarket.SmartStore.ChangeProductSaleStatus_ReqData} data
         */
        ChangeProductSaleStatus: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ChangeProductSaleStatus.aspx";

            var $data = new ItsMarket.SmartStore.ChangeProductSaleStatus_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 조회 
         * @param {ItsMarket.SmartStore.GetProduct_ReqData} data
         */
        GetProduct: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetProduct.aspx";

            var $data = new ItsMarket.SmartStore.GetProduct_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 목록 조회 
         * @param {ItsMarket.SmartStore.GetProductList_ReqData} data
         */
        GetProductList: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetProductList.aspx";

            var $data = new ItsMarket.SmartStore.GetProductList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 옵션 조회 
         * @param {ItsMarket.SmartStore.GetOption_ReqData} data
         */
        GetOption: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetOption.aspx";

            var $data = new ItsMarket.SmartStore.GetOption_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 묶음 배송비 등록 
         * @param {ItsMarket.SmartStore.ManageBundleGroup_ReqData} data
         */
        ManageBundleGroup: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ManageBundleGroup.aspx";

            var $data = new ItsMarket.SmartStore.GetProductList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.SmartStore.GetProductOrderInfoList_ReqData} data
         */
        GetProductOrderInfoList: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetProductOrderInfoList.aspx";

            var $data = new ItsMarket.SmartStore.GetProductOrderInfoList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발주처리
         * @param {ItsMarket.SmartStore.PlaceProductOrder_ReqData} data
         */
        PlaceProductOrder: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "PlaceProductOrder.aspx";

            var $data = new ItsMarket.SmartStore.PlaceProductOrder_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송처리
         * @param {ItsMarket.SmartStore.ShipProductOrder_ReqData} data
         */
        ShipProductOrder: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ShipProductOrder.aspx";

            var $data = new ItsMarket.SmartStore.ShipProductOrder_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA조회
         * @param {ItsMarket.SmartStore.GetCustomerInquiryList_ReqData} data
         */
        GetCustomerInquiryList: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetCustomerInquiryList.aspx";

            var $data = new ItsMarket.SmartStore.GetCustomerInquiryList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        }, 
        /**
         * QnA답변
         * @param {ItsMarket.SmartStore.AnswerCustomerInquiry_ReqData} data
         */
        AnswerCustomerInquiry: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "AnswerCustomerInquiry.aspx";

            var $data = new ItsMarket.SmartStore.AnswerCustomerInquiry_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소승인
         * @param {ItsMarket.SmartStore.ApproveCancelApplication_ReqData} data
         */
        ApproveCancelApplication: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ApproveCancelApplication.aspx";

            var $data = new ItsMarket.SmartStore.ApproveCancelApplication_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 수거완료
         * @param {ItsMarket.SmartStore.ApproveCollectedExchange_ReqData} data
         */
        ApproveCollectedExchange: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ApproveCollectedExchange.aspx";

            var $data = new ItsMarket.SmartStore.ApproveCollectedExchange_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 발송
         * @param {ItsMarket.SmartStore.ReDeliveryExchange_ReqData} data
         */
        ReDeliveryExchange: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ReDeliveryExchange.aspx";

            var $data = new ItsMarket.SmartStore.ReDeliveryExchange_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 승인 
         * @param {ItsMarket.SmartStore.ApproveReturnApplication_ReqData} data
         */
        ApproveReturnApplication: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ApproveReturnApplication.aspx";

            var $data = new ItsMarket.SmartStore.ApproveReturnApplication_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA조회
         * @param {ItsMarket.SmartStore.GetQuestionAnswerList_ReqData} data
         */
        GetQuestionAnswerList: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "GetQuestionAnswerList.aspx";

            var $data = new ItsMarket.SmartStore.GetQuestionAnswerList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA답변
         * @param {ItsMarket.SmartStore.ManageQuestionAnswer_ReqData} data
         */
        ManageQuestionAnswer: function (data, success, fail) {
            var url = ItsMarket.SmartStore.baseUrl + "ManageQuestionAnswer.aspx";

            var $data = new ItsMarket.SmartStore.ManageQuestionAnswer_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
    },
    InterPark: {
        baseUrl: "../../Service/Market/InterPark/",
        orderListForSingle_ReqData: function () {
            this.strDate = ItsHelper.AddDay(-6);        // 조회 시작일자
            this.endDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
        },
        orderListDelvForSingle_ReqData: function () {
            this.strDate = ItsHelper.AddDay(-6);        // 조회 시작일자
            this.endDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
        },
        DoShippingGeneral_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);
            this.EndDate = ItsHelper.GetYearMonthDay();
            this.OrderNo = "";
            this.compNo = "";
            this.InvoiceNo = "";
            this.returnParam = undefined;
        },
        GetShippingOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
        },
        InsertProductAPIData_ReqData: function () {
            this.omDispNo = "1";                            // 전시코드
            this.prdNm = "";                                // 상품명
            this.brand = "상세페이지 참조";                 // 제조업체, (브랜드)
            this.prdOriginTp = "상세페이지 참조";           // 원산지
            this.saleStatTp = "01";                         // 판매중
            this.saleUnitcost = "";                         // 판매가
            this.saleLmtQty = "";                           // 재고
            this.saleStrDts = ItsHelper.GetYearMonthDay();  // 판매시작일
            this.proddelvCostUseYn = "";                    // N일 때 묶음배송가능
            this.delvPlcNo = "";                            // 묶음배송번호
            this.delvCost = "";                             // 배송비
            this.delvCostApplyTp = "02";                    // 배송비 적용 방식 - 개당:01, 무조건:02, n개당:03
            this.freedelvStdCnt = "0";                       // 무료배송 기준수량
            this.jejuDelvCost = "";                         // 제주배송비
            this.etcDelvCost = "";                          // 도서산간배송비
            this.delvMthd = "01";                           // 배송방법 - 택배:01, 우편(소포/등기):02, 화물배달
            this.prdrtnCostUseYn = "N";                     // 상품 반품택배 사용
            this.rtndelvCost = "";                          // 반품택배비
            this.rtndelvNo = "";                            // 반품배송지 번호
            this.prdBasisExplanEd = "";                     // 상세설명
            this.zoomImg = "";                              // 대표이미지
            this.detailImg = "";
            this.perordRstrQty = "";                        // 구매수량제한
            this.originPrdNo = "";                          // 판매자 상품코드
            this.asInfo = "상세페이지 참조";                // AS 정보
            this.optPrirTp = "";
            this.Option = "";
            this.OptionName = "규격";
            this.addQtyUseYn = "";
            this.addQtyUseYn = "";
            this.addOption = "";
            this.entrDcUseYn = "";
            this.entrDcTp = "";
            this.entrDcNum = "";
            this.GridNum = "";
        },
        insertDelvCostPlcAPIData_ReqData: function () {
            this.distCostTp = "";       //배송비 종류(00:무료, 98:판매자 조건부 무료, 99:판매자 정액)
            this.distCost = "";         //배송비(배송비 종류가 무료일 경우 0)
            this.maxbuyAmt = "";        //무료배송 최소금액
        },
        GetProductInquiryForAPI_ReqData: function () {
            this.rows = "50";
            this.page = "1";
            this.stdClsNo = "";
            this.searchWd = "";
            this.excelStatTp = "";
            this.excelStat = "";
            this.saleStatTp = "01";         
        },
        GetPrdSaleQtyForAPI_ReqData: function () {
            this.prdNo = "";
            this.RowNo = "";
        },
        UpdateProductAPIData_ReqData: function () {
            this.prdNo = "";                // 상품번호 - 필수
            this.prdNm = "";                // 상품명 - 필수
            this.saleUnitcost = "";         // 가격 - 필수
            this.saleStatTp = "";           // 판매상태
            this.saleLmtQty = "";           // 재고
            this.prdBasisExplanEd = "";     // 상세설명
            this.zoomImg = "";
            this.detailImg = "";
            this.perordRstrQty = "";
            this.Option = "";
            this.addQtyUseYn = "";
            this.entrDcUseYn = "";          // 판매자 할인
            this.entrDcTp = "";             // 판매자 할인
            this.entrDcNum = "";            // 판매자 할인
            this.proddelvCostUseYn = "";
            this.delvPlcNo = "";
            this.delvCost = "";
            this.delvCostApplyTp = "";
            this.freedelvStdCnt = "";
            this.rtndelvCost = "";
            this.GridNum = "";
        },
        getProductDtl_ReqData: function () {
            this.prdNo = "";                // 상품번호 - 필수
            this.GridNum = "";
        },
        GetProductInfo_ReqData: function () {
            this.prdNo = "";                // 상품번호 - 필수
            this.GridNum = "";
        },
        GetQnaInquiryForAPI_ReqData: function () {
            this.strDt = ItsHelper.AddDay(-6);          // 조회시작일자
            this.endDt = ItsHelper.GetYearMonthDay();   // 조회종료일자
        },
        InsertQnaAPIData_ReqData: function () {
            this.qnaNo = "";                            // QnA번호
            this.contents = "";                         // 답변
        },
        UpdateQnaAPIData_ReqData: function () {
            this.answerQnaNo = "";                      // 답변번호
            this.contents = "";                         // 답변
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.InterPark.orderListForSingle_ReqData} data
         */
        orderListForSingle: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "orderListForSingle.aspx";

            var $data = new ItsMarket.InterPark.orderListForSingle_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 준비중 목록 조회
         * @param {ItsMarket.InterPark.orderListDelvForSingle_ReqData} data
         */
        orderListDelvForSingle: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "orderListDelvForSingle.aspx";

            var $data = new ItsMarket.InterPark.orderListDelvForSingle_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 처리
         * @param {ItsMarket.InterPark.DoShippingGeneral_ReqData} data
         */
        DoShippingGeneral: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "DoShippingGeneral.aspx";

            var $data = new ItsMarket.InterPark.DoShippingGeneral_ReqData();
            ItsHelper.CopyObj(data, $data);

            $data.returnParam['OrderNo'] = $data.OrderNo;
            $data.returnParam['compNo'] = $data.compNo;
            $data.returnParam['InvoiceNo'] = $data.InvoiceNo;
            $data.returnParam['StartDate'] = $data.StartDate;
            $data.returnParam['EndDate'] = $data.EndDate;

            ItsMarket.$callAjax(url, $data.returnParam, success, fail);
        },
        /**
         * 배송 조회
         * @param {ItsMarket.InterPark.GetShippingOrderList_ReqData} data
         */
        GetShippingOrderList: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "GetShippingOrderList.aspx";

            var $data = new ItsMarket.InterPark.GetShippingOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품등록
         * @param {ItsMarket.InterPark.InsertProductAPIData_ReqData} data
         */
        InsertProductAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "InsertProductAPIData.aspx";

            var $data = new ItsMarket.InterPark.InsertProductAPIData_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품배송지 조회
         */
        getEntrDelvAAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "getEntrDelvAAPIData.aspx";

            ItsMarket.$callAjax(url, "", success, fail);
        },
        /**
         * 배송비정책 조회
         */
        getDelvCostPlcAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "getDelvCostPlcAPIData.aspx";

            ItsMarket.$callAjax(url, "", success, fail);
        },
        /**
         * 배송비정책 등록
         * @param {ItsMarket.InterPark.insertDelvCostPlcAPIData_ReqData} data
         */
        insertDelvCostPlcAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "insertDelvCostPlcAPIData.aspx";

            var $data = new ItsMarket.InterPark.insertDelvCostPlcAPIData_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품목록조회
         * @param {ItsMarket.InterPark.GetProductInquiryForAPI_ReqData} data
         */
        GetProductInquiryForAPI: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "GetProductInquiryForAPI.aspx";

            var $data = new ItsMarket.InterPark.GetProductInquiryForAPI_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품재고조회
         * @param {ItsMarket.InterPark.GetPrdSaleQtyForAPI_ReqData} data
         */
        GetPrdSaleQtyForAPI: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "GetPrdSaleQtyForAPI.aspx";

            var $data = new ItsMarket.InterPark.GetPrdSaleQtyForAPI_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품수정
         * @param {ItsMarket.InterPark.UpdateProductAPIData_ReqData} data
         */
        UpdateProductAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "UpdateProductAPIData.aspx";

            var $data = new ItsMarket.InterPark.UpdateProductAPIData_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 상세 가져오기
         * @param {ItsMarket.InterPark.getProductDtl_ReqData} data
         */
        getProductDtl: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "getProductDtl.aspx";

            var $data = new ItsMarket.InterPark.getProductDtl_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 정보 가져오기
         * @param {ItsMarket.InterPark.GetProductInfo_ReqData} data
         */
        GetProductInfo: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "GetProductInfo.aspx";

            var $data = new ItsMarket.InterPark.GetProductInfo_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 조회
         * @param {ItsMarket.InterPark.GetQnaInquiryForAPI_ReqData} data
         */
        GetQnaInquiryForAPI: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "GetQnaInquiryForAPI.aspx";

            var $data = new ItsMarket.InterPark.GetQnaInquiryForAPI_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 답변 등록
         * @param {ItsMarket.InterPark.InsertQnaAPIData_ReqData} data
         */
        InsertQnaAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "InsertQnaAPIData.aspx";

            var $data = new ItsMarket.InterPark.InsertQnaAPIData_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 답변 수정
         * @param {ItsMarket.InterPark.UpdateQnaAPIData_ReqData} data
         */
        UpdateQnaAPIData: function (data, success, fail) {
            var url = ItsMarket.InterPark.baseUrl + "UpdateQnaAPIData.aspx";

            var $data = new ItsMarket.InterPark.UpdateQnaAPIData_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
    },
    CouPang: {
        baseUrl: "../../Service/Market/CouPang/",
        ManageProduct_ReqData: function () {
            this.displayCategoryCode = "";              // 카테고리
            this.ProductName = "";                      // 상품명
            this.saleStartedAt = ItsHelper.GetYearMonthDay() + "T00:00:00"; // 판매시작일
            this.saleEndedAt = "2099-01-01T23:59:59";                       // 판매종료일
            this.brand = "";                            // 브랜드
            this.deliveryMethod = "SEQUENCIAL";         // 배송방법
            this.deliveryCompanyCode = "";              // 택배사코드
            this.deliveryChargeType = "";               // 배송비 종류 FREE, NOT_FREE, CONDITIONAL_FREE
            this.deliveryCharge = "";                   // 배송비 
            this.deliveryChargeOnReturn = "";           // 초도 반품배송비 
            this.freeShipOverAmount = "";               // 무료 배송금액
            this.unionDeliveryType = "";                // 묶음배송 
            this.returnCenterCode = "";                 // 반품센터코드 
            this.returnChargeName = "";                 // 반품
            this.companyContactNumber = "";             // 반품연락처
            this.returnZipCode = "";                    // 반품 우편번호
            this.returnAddress = "";                    // 반품 주소
            this.returnAddressDetail = "";              // 반품 주소
            this.returnCharge = "";                     // 반품 주소
            this.afterServiceInformation = "";          // AS안내
            this.afterServiceContactNumber = "";        // AS 안내 전화
            this.outboundShippingPlaceCode = "";        // 출고지
            this.vendorUserId = "";                     // 사용자ID
            this.itemName = "";                         // 규격
            this.originalPrice = "";                    // 기준가
            this.salePrice = "";                        // 판매가
            this.outboundShippingTimeDay = "1";         // 출고예정일
            this.maximumBuyCount = "";                  // 재고
            this.externalVendorSku = "";                 // 판매자상품코드
            this.vendorPath = "";                       // 대표이미지
            this.vendorPath1 = "";                       // 추가이미지
            this.vendorPath2 = "";                       // 추가이미지
            this.attributeTypeName = "수량";
            this.attributeValueName = "1개";
            this.content = "";                          // 상세설명
            //this.Option = [];
            //this.OptCount = 0;
            this.sellerProductId = "";              // 상품수정 상품ID
            this.sellerProductItemId = "";          // 상품수정 상품 ItemID
            this.vendorItemId = "";
            this.GridNum = "";           
        },
        GetPaidOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.GetYearMonthDay(); // 조회 종료 일자
            this.status = "ACCEPT";
        },
        ConfirmReceivingOrder_ReqData: function () {
            this.OrderNo = "";                          // 주문 번호 (필수)
        },
        GetDeliveryPrepareList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-30);     // 조회 시작일자
            this.EndDate = ItsHelper.AddDay(1);         // 조회 종료 일자
            this.status = "INSTRUCT";
        },
        DoShippingGeneral_ReqData: function () {
            this.shipmentBoxId = "";                    // 묶음배송번호
            this.orderId = "";                          // 주문번호
            this.vendorItemId = "";                     // 옵션번호(상품번호)
            this.deliveryCompanyCode = "";              // 택배사코드
            this.invoiceNumber = "";                    // 운송장번호
            this.SUMYN = "";                            // 단독주문인지, 묶음배송주문인지
        },
        GetShippingOrderList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1)
            this.status = "DELIVERING";
        },
        GetShipmentPlaces_ReqData: function () {
            this.PlaceCode = "";
        },
        GetSellingItemList_ReqData: function () {
            this.nextToken = 1;                         // 현재 페이지
            this.maxPerPage = 10;                       // 페이지당 개수
            this.sellerProductId = "";                  // 상품 ID
            this.sellerProductName = "";                // 상품명
            this.status = "";                           // 상품 요청 상태
        },
        GetCategoryMetas_ReqData: function () {
            this.displayCategoryCode = "";
        },
        GetSellerQnAList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
        },
        AddQnAReply_ReqData: function () {
            this.inquiryId = "";
            this.content = "";
            this.replyBy = "";
        },
        GetSellingItem_ReqData: function () {
            this.sellerProductId = "";                  // 상품 ID
            this.GridNum = "";
        },
        GetItemStatus_ReqData: function () {
            this.sellerProductId = "";                  // 상품 ID
        },
        GetExchangeRequestList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6)
            this.EndDate = ItsHelper.AddDay(1);
            this.STATUS = "";
        },
        GetReturnList_ReqData: function () {
            this.StartDate = ItsHelper.AddDay(-6);
            this.EndDate = ItsHelper.AddDay(1);
            this.STATUS = "요청";
        },
        DoExchangeSwitch_ReqData: function () {
            this.StartDate = "";
            this.EndDate = "";
            this.orderId = "";
            this.exchangeId = "";
            this.DELIVERYCOMP = "";
            this.INVOICENO = "";
        },
        DoShippingCancleOrder_ReqData: function () {
            this.receiptId = "";
            this.DELIVERYCOMP = "";
            this.INVOICENO = "";
        },
        DoReturnApproval_ReqData: function () {
            this.receiptId = "";
            this.cancelCount = "";
        },
        SetItemPrice_ReqData: function () {
            this.vendorItemId = "";
            this.price = "";
            this.originalprice = "";
            this.GridNum = "";
        },
        ReviseItemStock_ReqData: function () {
            this.vendorItemId = "";
            this.quantity = "";
            this.GridNum = "";
        },
        ReviseItemSelling_ReqData: function () {
            this.vendorItemId = "";
            this.sales = "";
            this.GridNum = "";
        },
        /**
         * 상품등록, 수정
         * @param {ItsMarket.CouPang.GetPaidOrderList_ReqData} data
         */
        ManageProduct: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "ManageProduct.aspx";

            var $data = new ItsMarket.CouPang.ManageProduct_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 결제 완료 목록 조회
         * @param {ItsMarket.CouPang.GetPaidOrderList_ReqData} data
         */
        GetPaidOrderList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetProductOrderInfoList.aspx";

            var $data = new ItsMarket.CouPang.GetPaidOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 주문 접수 처리
         * @param {ItsMarket.CouPang.ConfirmReceivingOrder_ReqData} data
         */
        ConfirmReceivingOrder: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "ConfirmReceivingOrder.aspx";

            var $data = new ItsMarket.CouPang.ConfirmReceivingOrder_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.OrderNo == undefined || $data.OrderNo == '' || $data.OrderNo == null) {
                ItsMsg.Toast('주문 접수 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 준비중 목록 조회
         * @param {ItsMarket.CouPang.GetDeliveryPrepareList_ReqData} data
         */
        GetDeliveryPrepareList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetProductOrderInfoList.aspx";

            var $data = new ItsMarket.CouPang.GetDeliveryPrepareList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송 처리
         * @param {ItsMarket.CouPang.DoShippingGeneral_ReqData} data
         */
        DoShippingGeneral: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "DoShippingGeneral.aspx";

            var $data = new ItsMarket.CouPang.DoShippingGeneral_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 배송 조회
         * @param {ItsMarket.CouPang.GetShippingOrderList_ReqData} data
         */
        GetShippingOrderList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetProductOrderInfoList.aspx";

            var $data = new ItsMarket.CouPang.GetShippingOrderList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 발송지 조회
         * @param {ItsMarket.CouPang.GetShipmentPlaces_ReqData} data
         */
        GetShipmentPlaces: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetShipmentPlaces.aspx";

            var $data = new ItsMarket.CouPang.GetShipmentPlaces_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 조회 (페이지)
         * @param {ItsMarket.CouPang.GetSellingItemList_ReqData} data
         */
        GetSellingItemList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetSellingItemList.aspx";

            var $data = new ItsMarket.CouPang.GetSellingItemList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 카테고리 메타정보 조회(옵션명)
         * @param {ItsMarket.CouPang.GetCategoryMetas_ReqData} data
         */
        GetCategoryMetas: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetCategoryMetas.aspx";

            var $data = new ItsMarket.CouPang.GetCategoryMetas_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * QnA 조회
         * @param {ItsMarket.CouPang.GetSellerQnAList_ReqData} data
         */
        GetSellerQnAList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetSellerQnAList.aspx";

            var $data = new ItsMarket.CouPang.GetSellerQnAList_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 답변 작성
         * @param {ItsMarket.CouPang.AddQnAReply_ReqData} data
         */
        AddQnAReply: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "AddQnAReply.aspx";

            var $data = new ItsMarket.CouPang.AddQnAReply_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 조회 (단건)
         * @param {ItsMarket.CouPang.GetSellingItem_ReqData} data
         */
        GetSellingItem: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetSellingItem.aspx";

            var $data = new ItsMarket.CouPang.GetSellingItem_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 상품 상태 조회
         * @param {ItsMarket.CouPang.GetItemStatus_ReqData} data
         */
        GetItemStatus: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetItemStatus.aspx";

            var $data = new ItsMarket.CouPang.GetItemStatus_ReqData();
            ItsHelper.CopyObj(data, $data);

            ItsMarket.$callAjax(url, $data, success, fail);
        },
       /**
         * 교환 신청 목록 조회
         * @param {ItsMarket.CouPang.GetExchangeRequestList_ReqData} data
         */
        GetExchangeRequestList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetExchangeRequestList.aspx";

            var $data = new ItsMarket.CouPang.GetExchangeRequestList_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 신청 목록 조회
         * @param {ItsMarket.CouPang.GetReturnList_ReqData} data
         */
        GetReturnList: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "GetReturnList.aspx";

            var $data = new ItsMarket.CouPang.GetReturnList_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 교환 승인
         * @param {ItsMarket.CouPang.DoExchangeSwitch_ReqData} data
         */
        DoExchangeSwitch: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "DoExchangeSwitch.aspx";

            var $data = new ItsMarket.CouPang.DoExchangeSwitch_ReqData();
            ItsHelper.CopyObj(data, $data);
            if ($data.orderId == undefined || $data.orderId == '' || $data.orderId == null) {
                ItsMsg.Toast('교환 승인 불가 : 주문번호가 누락되었습니다.', 3000);
                return;
            }
            if ($data.INVOICENO == undefined || $data.INVOICENO == '' || $data.INVOICENO == null) {
                ItsMsg.Toast('교환 승인 불가 : 운송장 번호가 누락되었습니다.', 3000);
                return;
            }
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 반품 승인
         * @param {ItsMarket.CouPang.DoReturnApproval_ReqData} data
         */
        DoReturnApproval: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "DoReturnApproval.aspx";

            var $data = new ItsMarket.CouPang.DoReturnApproval_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 취소 거부(발송처리)
         * @param {ItsMarket.CouPang.DoShippingCancleOrder_ReqData} data
         */
        DoShippingCancleOrder: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "DoShippingCancleOrder.aspx";

            var $data = new ItsMarket.CouPang.DoShippingCancleOrder_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 가격변경
         * @param {ItsMarket.CouPang.SetItemPrice_ReqData} data
         */
        SetItemPrice: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "SetItemPrice.aspx";

            var $data = new ItsMarket.CouPang.SetItemPrice_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 재고변경
         * @param {ItsMarket.CouPang.ReviseItemStock_ReqData} data
         */
        ReviseItemStock: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "ReviseItemStock.aspx";

            var $data = new ItsMarket.CouPang.ReviseItemStock_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
        /**
         * 판매상태 변경
         * @param {ItsMarket.CouPang.ReviseItemSelling_ReqData} data
         */
        ReviseItemSelling: function (data, success, fail) {
            var url = ItsMarket.CouPang.baseUrl + "ReviseItemSelling.aspx";

            var $data = new ItsMarket.CouPang.ReviseItemSelling_ReqData();
            ItsHelper.CopyObj(data, $data);
            ItsMarket.$callAjax(url, $data, success, fail);
        },
    }
};

ItsMarket.$callAjax = function (url, reqdata, success, fail) {
    $.ajax({
        url: url,
        type: 'post',
        data: reqdata,
        async:true,
        success: function (data) {
            if (data.substring(0, 5) == 'ERROR') {
                ItsMsg.Alert(data);
                return;
            }
            var $data = JSON.parse(data);
            if ($data.result == "true" || $data.result == true) { //성공
                if (success != undefined) {
                    success($data);
                }
            } else { //실패
                if (fail != undefined) {
                    fail($data);
                } else {
                    ItsMsg.Alert($data.returnMsg);
                    console.log('--------------------------------------');
                    console.log(url);
                    console.log(reqdata);
                    console.log($data.returnMsg);
                    console.log('--------------------------------------');
                }
                try {
                    parent.wait_end();
                } catch (e) { }
            }
        },
        error: function (xhr, status, error) {
            ItsMsg.Alert(error);
            console.log(error);
            try {
                parent.wait_end();
            } catch (e) { }
        }
    });
}
