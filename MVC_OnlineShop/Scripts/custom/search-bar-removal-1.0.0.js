$(document).ready(function () {
    $('.navbar-toggler').click(function () {
        if ($('.searchBar-top-location').css("display") == "none") {
            $('.searchBar-top-location').css("display", "");
        } else {
            $('.searchBar-top-location').css("display", "none");
        }

    });
});