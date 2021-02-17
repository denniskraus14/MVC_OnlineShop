/*!
  * Page Scroll v1.0.0
  * Copyright 2021 The Author (https://github.com/ezenity)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
  */

var BlockNumber = 2;  //Infinate Scroll starts from second block
var NoMoreData = false;
var inProgress = false;

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height() && !NoMoreData && !inProgress) {
        inProgress = true;
        $("#loadingDiv").show();

        var url = $('#pageUrl').val(); // Grabs the action method which will render the json information
        var pageType = $('#pageType').val(); // Get the product type you are looking at and make sure to only render this product types

        $.post(url, { "BlockNumber": BlockNumber, "productType": pageType }, function (data) {
            BlockNumber = BlockNumber + 1;
            NoMoreData = data.NoMoreData;
            $("#productListDiv").append(data.HTMLString);
            $("#loadingDiv").hide();
            inProgress = false;
        });
    }
});