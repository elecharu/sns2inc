/********************************************
 * >>>>> ItsImage: 팝업 컨트롤 >>>>>
 * 2018-08-14: 문재원: 최초 작성
 *******************************************/
var ItsImage = {
    list: [],
    _Reset: function ($image) {
        $image.click(function () {
            var id = $(this).attr('id');
            var src = $(this).attr('src');
            var key = $(this).data('key');
            ItsImage.Event(id).onClick(src, key);
        });
        $image.on('mouseover', function () {
            var id = $(this).attr('id');
            var src = $(this).attr('src');
            var key = $(this).data('key');
            ItsImage.Event(id).onMouseOver(src, key);
        });
        $image.on('mouseout', function () {
            var id = $(this).attr('id');
            var src = $(this).attr('src');
            var key = $(this).data('key');
            ItsImage.Event(id).onMouseOut(src, key);
        });
    },
    Reset: function() {
        $('.ItsImage').each(function () {
            ItsImage._Reset($(this));
        });
    },
    SetImage: function(id, src, key) {
        $('#' + id).eq(0).attr('src', src);
        $('#' + id).eq(0).data('key', key);
    },
    Clear: function(id) {
        $('#' + id).eq(0).attr('src', '../../UploadFiles/404IMAGE.jpg');
        $('#' + id).eq(0).data('key', '');
    },
    /** 
    @returns {ItsPop.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsImage.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onImageChange = function (url, key) { };
        this.onClick = function (url, key) { };
        this.onMouseOver = function (url, key) { };
        this.onMouseOut = function (url, key) { };
    },
    SetInitObj: function ($image) {
        $image.eq(0).attr('src', '../../UploadFiles/404IMAGE.jpg');
        $image.eq(0).data('key', '');
    }
};