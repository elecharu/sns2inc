/// <reference path="../Script/reference.js" />
/********************************************
 * >>>>> ItsFaxPop: 팩스 팝업 컨트롤 >>>>>
 * 2018-12-04: 왕현준
 * 2018-12-21: 왕현준 전반적 수정(SendFax,SetData,ClearData 추가)
 * 2019-01-21: 왕현준 SendFax 수정(수신자 이름 입력 가능하도록)
 *******************************************/
var ItsFaxPop = {
    Init: function () {
        ItsFind.Event('COMMON_FAXPOP_TR_NAME').onChanged = function () {
            ItsText.SetValue('COMMON_FAXPOP_TR_PHONE', ItsFind.GetRef02Value('COMMON_FAXPOP_TR_NAME'));
        };
        //LG_SERVICE를 통한 FAX발송
        ItsButton.Event('COMMON_FAXPOP_btn_SEND').onClick = function () {
            if (ItsText.GetValue('COMMON_FAXPOP_filename') != '') {
                var maria = new ItsMaria('SEJONG_SERVICE', 'SEND_FAX');
                maria.AddPanel('COMMON_FAXPOP');
                maria.AddParam('TR_SENDFAXNUM', ItsText.GetValue('COMMON_FAXPOP_TR_SENDFAXNUM').replace(/-/gi, ''));
                maria.AddParam('TR_PHONE', ItsText.GetValue('COMMON_FAXPOP_TR_PHONE').replace(/-/gi, ''));
                maria.AddParam('TR_NAME', ItsFind.GetNameValue('COMMON_FAXPOP_TR_NAME'));
                maria.CallProcCenter();
                if (maria.isError) {
                    maria.ShowErrMsg();
                    return;
                }
            }
            else {
                ItsMsg.Alert('파일 주소가 없습니다.');
                return;
            }
        };
        ItsButton.Event('COMMON_FAXPOP_btn_CANCLE').onClick = function () {
            ItsFaxPop.ClearData();
            ItsPop.Close('COMMON_FAXPOP');
        };
    },
    // 파일을 CopyFile()후 PopUp창 오픈
    Open: function (filepath) {
        $filename = ItsHelper.CopyFile(filepath);
        ItsText.SetValue('COMMON_FAXPOP_filename', $filename);
        ItsPop.Open('COMMON_FAXPOP');
    },
    //SetData를 이용해 값을 넣고 팝업창을 출력하지 않은 상태로 작동
    SendFax: function (filepath, TR_NAME) {

        if (filepath != '' || filepath != undefined) {
            $filename = ItsHelper.CopyFile(filepath);
            ItsText.SetValue('COMMON_FAXPOP_filename', $filename);
        }
        
        if (ItsText.GetValue('COMMON_FAXPOP_filename') == '') {
            return;
        }
        else {
            var maria = new ItsMaria('SEJONG_SERVICE', 'SEND_FAX');
            maria.AddPanel('COMMON_FAXPOP');
            maria.AddParam('TR_SENDFAXNUM', ItsText.GetValue('COMMON_FAXPOP_TR_SENDFAXNUM').replace(/-/gi, ''));
            maria.AddParam('TR_PHONE', ItsText.GetValue('COMMON_FAXPOP_TR_PHONE').replace(/-/gi, ''));
            if (TR_NAME != '' || TR_NAME != undefined) {
                maria.AddParam('TR_NAME', TR_NAME);
            }
            else {
                maria.AddParam('TR_NAME', ItsFind.GetNameValue('COMMON_FAXPOP_TR_NAME'));
            }
            maria.CallProcCenter();
            if (maria.isError) {
                maria.ShowErrMsg();
                return;
            }
            ItsFaxPop.ClearData();
        }
    },
    SetData: function (SendFaxNum, Title, SendName, Custcd, CustFaxNum,filename) {
        ItsText.SetValue('COMMON_FAXPOP_TR_SENDFAXNUM', SendFaxNum);
        ItsText.SetValue('COMMON_FAXPOP_TR_TITLE', Title);
        ItsText.SetValue('COMMON_FAXPOP_TR_SENDNAME', SendName);
        ItsFind.SetValue('COMMON_FAXPOP_TR_NAME', Custcd);
        ItsText.SetValue('COMMON_FAXPOP_filename', filename);
        if (CustFaxNum != undefined && CustFaxNum != '') {
            ItsText.SetValue('COMMON_FAXPOP_TR_PHONE', CustFaxNum);
        }
        else {
            ItsText.SetValue('COMMON_FAXPOP_TR_PHONE', ItsFind.GetRef02Value('COMMON_FAXPOP_TR_NAME'));
        }
    },
    ClearData: function () {
        ItsText.SetValue('COMMON_FAXPOP_TR_SENDFAXNUM', '');
        ItsText.SetValue('COMMON_FAXPOP_TR_TITLE', '');
        ItsText.SetValue('COMMON_FAXPOP_TR_SENDNAME', '');
        ItsFind.SetValue('COMMON_FAXPOP_TR_NAME', '');
        ItsText.SetValue('COMMON_FAXPOP_filename', '');
        ItsText.SetValue('COMMON_FAXPOP_TR_PHONE', '');
    }
};

