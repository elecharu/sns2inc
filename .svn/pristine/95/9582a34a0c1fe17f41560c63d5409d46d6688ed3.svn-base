document.addEventListener('DOMContentLoaded', function () {
    if (opener.document.getElementById('print_area') != null) {
        document.body.innerHTML = opener.document.getElementById('print_area').outerHTML;
        $('.not_print').hide();
        window.print();
    } else {
        document.title = '미리보기';
        document.body.innerHTML = opener.document.getElementById('view_area').outerHTML;
        $('.not_print').hide();
        $('#title').parent('dd').text(opener.document.getElementById('title').value);
        $('#ref_emp').parent('dd').text(opener.document.getElementById('ref_emp').value);
        document.getElementById('breaktp').outerHTML = $('#breaktp option:selected').text();
        document.getElementById('sdate').outerHTML = opener.document.getElementById('sdate').value;
        document.getElementById('edate').outerHTML = opener.document.getElementById('edate').value;
        if (opener.$('.vc').css('display') != "none") {
            var tp = opener.document.getElementById('breaktp').value;
            if (tp == 1) $('.vccnt')[0].outerHTML = '(' + opener.document.getElementById('usedt').value + '일)';
            else if (tp == 2) {
                $('.vccnt')[0].outerHTML = '(' + opener.document.getElementById('usedt').value + '일)';
                $('.hfshow')[0].outerHTML = opener.$('#ra1').prop('checked') ? '(오전)' : '(오후)';
            }
            else if (tp == 4) $('.vccnt')[0].outerHTML = '(' + opener.document.getElementById('usetime').value + '시간)';
        } else {
            $('.vc').hide();
        }
        //$('#editor').parent('div').html(opener.document.getElementById('editor').value);
        $('.paper_box2 > div, .paper_box2 > .file_dl').remove();
        $('.paper').append('<div>' + opener.document.getElementById('editor').value + '</div>');
    }
});