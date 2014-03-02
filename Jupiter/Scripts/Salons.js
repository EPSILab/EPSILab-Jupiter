$(document).ready(function () {
    $(document).ready(function () {
        genererCarousel();
        setWidthConferences();
    });

    $(window).resize(function () {
        $("#SalonsInternCarousel").trigger("updateSizes");

        if (innerWidth < 400) {
            if (widthActual >= 400) {
                genererCarousel();
            }
        }
        else if (innerWidth < 600) {
            if (widthActual < 400 || widthActual >= 600) {
                genererCarousel();
            }
        }
        else if (innerWidth < 1100) {
            if (widthActual < 600 || widthActual >= 1100) {
                genererCarousel();
            }
        } else {
            if (widthActual < 1100) {
                genererCarousel();
            }
        }

        setWidthConferences();
    });

    function setWidthConferences() {
        if (innerWidth < 400) {
            $(".salon").css("width", (innerWidth - 60) + "px");
        }
        else if (innerWidth < 600) {
            $(".salon").css("width", (innerWidth - 80) + "px");
        }
        else if (innerWidth < 1100) {
            $(".salon").css("width", (innerWidth - 220) + "px");
        } else {
            $(".salon").css("width", "1000px");
        }
    }

    function genererCarousel() {
        var LastNamebreTotalItems = $("#ShowsInternCarousel").children().length;
        var LastNamebreItemsPerPage = NbItemsPerPage(LastNamebreTotalItems);

        $("#ShowsInternCarousel").carouFredSel({
            direction: "up",
            circular: true,
            infinite: false,
            width: "variable",
            height: "variable",
            items: {
                visible: LastNamebreItemsPerPage
            },
            auto: false,
            prev: {
                key: "up"
            },
            next: {
                key: "down"
            },
            pagination: ".paginationShows",
            swipe: true
        });

        widthActual = innerWidth;
    }

    function NbPages() {
        if (innerWidth < 400) {
            return Math.floor(200 / 32);
        }
        else if (innerWidth < 600) {
            return Math.floor(300 / 36);
        }
        else if (innerWidth < 1100) {
            return Math.floor(500 / 38);
        } else {
            return Math.floor(1000 / 40);
        }
    }

    function NbItemsPerPage(LastNamebreTotalItems) {
        if (innerWidth < 400) {
            return Math.max(Math.ceil(LastNamebreTotalItems / NbPages()), 6);
        }
        else if (innerWidth < 600) {
            return Math.max(Math.ceil(LastNamebreTotalItems / NbPages()), 8);
        }
        else if (innerWidth < 1100) {
            return Math.max(Math.ceil(LastNamebreTotalItems / NbPages()), 10);
        } else {
            return Math.max(Math.ceil(LastNamebreTotalItems / NbPages()), 12);
        }
    }
});