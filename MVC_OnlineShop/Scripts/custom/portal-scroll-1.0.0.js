var BlockNumber = 2;  //Infinate Scroll starts from second block
var NoMoreData = false;
var inProgress = false;

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height() && !NoMoreData && !inProgress) {
        inProgress = true;
        $("#loadingDiv").show();

        var url = $('#portalUrl').val();

        $.post(url, { "BlockNumber": BlockNumber }, function (data) {
                BlockNumber = BlockNumber + 1;
                NoMoreData = data.NoMoreData;
                $("#productListDiv").append(data.HTMLString);
                $("#loadingDiv").hide();
                inProgress = false;
            });
    }
});