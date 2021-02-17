/*!
  * Portal Scroll v1.0.0
  * Copyright 2021 The Author (https://github.com/ezenity)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
  */

var BlockNumber = 2;  //Infinate Scroll starts from second block
var NoMoreData = false;
var inProgress = false;

(function ($) {
    $.fn.hasScrollBar = function () {
        var e = this.get(0);
        return {
            vertical: e.scrollHeight > e.clientHeight,
            horizontal: e.scrollWidth > e.clientWidth
        };
    }
})(jQuery);

// dimension - Either 'y' or 'x'
// computedStyles - (Optional) Pass in the domNodes computed styles if you already have it (since I hear its somewhat expensive)
function hasScrollBars(domNode, dimension, computedStyles) {
    dimension = dimension.toUpperCase()
    if (dimension === 'Y') {
        var length = 'Height'
    } else {
        var length = 'Width'
    }

    var scrollLength = 'scroll' + length
    var clientLength = 'client' + length
    var overflowDimension = 'overflow' + dimension

    var hasVScroll = domNode[scrollLength] > domNode[clientLength]


    // Check the overflow and overflowY properties for "auto" and "visible" values
    var cStyle = computedStyles || getComputedStyle(domNode)
    return hasVScroll && (cStyle[overflowDimension] == "visible" || cStyle[overflowDimension] == "auto" ) || cStyle[overflowDimension] == "scroll"
}

$(window).scroll(function () {
    if (
        $(window).scrollTop() == $(document).height() - $(window).height() && !NoMoreData && !inProgress
        //$(window).scrollTop() == 0
    // || this.get(0).scrollHeight > this.get(0).clientHeight // Not working as intended
    // $(document).height() < $(window).height()
    // !element.hasScrollBar().horizontal
    ) {

    //if ( hasScrollBars( $(document), 'y', null ) ) {
    //if (!element.hasScrollBar().horizontal) {
    //if ($(window).scrollTop() + $(document).height() >= $(window).height() && !NoMoreData && !inProgress) { // loads all products
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