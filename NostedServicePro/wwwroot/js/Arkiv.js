//JavaScript - skript for håndtering av sortering

$(document).ready(function () {
    $("th.sortable").on("click", function () {
        var sortOrder = $(this).data("sort-order");
        sortOrder = sortOrder === "asc" ? "desc" : "asc";
        var sortBy = $(this).data("sort-by");
        window.location.href = "?sortOrder=" + sortOrder + "&sortField=" + sortBy;
    });

    // Fjern indikatorpiler fra alle kolonner
    $("th.sortable").each(function () {
        $(this).find(".sort-indicator").remove();
    });

    // Legg til indikatorpil basert på gjeldende sortering
    var sortOrder = "@ViewData["
    IdSortParm
    "]";
    var sortBy = "OrdreID"; // Sett standard kolonne for sortering
    var arrow = sortOrder === "asc" ? "<i class='fas fa-caret-up'></i>" : sortOrder === "desc" ? "<i class='fas fa-caret-down'></i>" : "";
    $("th.sortable[data-sort-by='" + sortBy + "']").append("<span class='sort-indicator'>" + arrow + "</span>");
});