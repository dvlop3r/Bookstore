// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*function elasticSearch(link) {
    const http = new XMLHttpRequest();
    http.onload = function () {
        $(".message").html(http.responseText);
    }
    http.open("Get", link.href + "?id=" + link.id);
    http.setRequestHeader("AjaxRequest", "XMLHttpRequest");
    http.send();
    return false;
}*/

function elasticSearch(filter) {
    var title = $(".filter").find("#title-filter").val();
    var author = $(".filter").find("#author-filter").val();
    var description = $(".filter").find("#description-filter").val();

    var url = filter.href + "?title=" + title + "&author=" + author + "&description=" + description;

    $.get(url, function (data) {
        $("#indexTable").html(data);
    });
    return false;
}