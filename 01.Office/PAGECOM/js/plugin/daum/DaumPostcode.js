function DaumPostcode() {
    new daum.Postcode({
        oncomplete: function(data) {
            var fullAddr = '';
            var extraAddr = '';

            if (data.userSelectedType === 'R') {    // 도로명 주소 선택
                fullAddr = data.roadAddress;
            } else {
                fullAddr = data.jibunAddress;
            }

            if (data.userSelectedType === 'R') {
                if (data.bname !== '') {    // 법정동명
                    extraAddr += data.bname;
                }

                if (data.buildingName !== '') { // 건물명
                    extraAddr += (extraAddr !== ''? ', ' + data.buildingName: data.buildingName);
                }

                // 조합형 주소 유무에 따라 양쪽에 괄호를 추가하여 최종 주소를 만든다.
                fullAddr += (extraAddr !== ''? ' ('+ extraAddr +')': '');
            }

            // document.getElementById('ZONE_CODE').value = data.zonecode;
            document.getElementById('address').value = fullAddr;

            // document.getElementById('DETAIL_ADDR').focus();
        },
        onclose: function(state) {
            if (state === 'FORCE_CLOSE') {
                // document.getElementById('ZONE_CODE').focus();
            } else if (state === 'COMPLETE_CLOSE') {
                // After oncomplete ended.
            }
        }
    }).open();
}
