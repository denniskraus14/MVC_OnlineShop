/*!
  * SearchBar Removal v1.0.0
  * Copyright 2021 The Author (https://github.com/ezenity)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/main/LICENSE)
  */
$(document).ready(function () {
    $('.navbar-toggler').click(function () {
        if ($('.searchBar-top-location').css("display") == "none") {
            $('.searchBar-top-location').css("display", "");
        } else {
            $('.searchBar-top-location').css("display", "none");
        }

    });
});