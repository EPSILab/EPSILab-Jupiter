// Tableau qui regroupe les news (au format HTML) qui ne sont plus visibles sur la page Default
// News comprises dans le carousel
var NewsInvisibles = new Array();


$(document).ready(function () {
    $('#temporaryNews').coinslider({
        hoverPause: true,
        width: 1000,
        height: 315,
        delay: 8000,
        opacity: 0.9
    });

    $("#NewsInternCarousel").carouFredSel({
        circular: true,
        infinite: false,
        width: '100%',
        height: '100%',
        auto: {
            pauseOnHover: true
        },
        prev: {
            button: "#news_prev",
            key: "left"
        },
        next: {
            button: "#news_next",
            key: "right"
        },
        pagination: "#news_pag",
        swipe: true,
        auto: 10000
    });

    gestionNews(innerWidth, ".lienNews");
    $("#NewsInternCarousel").trigger("updateSizes");
});


$(window).resize(function () {
    gestionNews(innerWidth, ".lienNews");
    $("#NewsInternCarousel").trigger("updateSizes");
});


function gestionNews(width, classNews) {
    var nombreNews = $(classNews).length;
    
    if (width <= 400) {

        // On supprime le nombre d'éléments pour arriver à 5
        while (nombreNews > 5) {
            supprimerUneNews(nombreNews);
            nombreNews--;
        }

        setNombreNewsVisible(1);

    }
    else if (width > 400 && width <= 600) {

        // On ajoute le nombre d'éléments pour arriver à 16
        while (nombreNews < 16) {
            ajouterUneNews();
            nombreNews++;
        }

        // On supprime le nombre d'éléments pour arriver à 16
        while (nombreNews > 16) {
            supprimerUneNews(nombreNews);
            nombreNews--;
        }

        setNombreNewsVisible(2);

    } else {

        // On rajoute le nombre d'éléments pour arriver à 20
        while (nombreNews < 20) {
            ajouterUneNews();
            nombreNews++;
        }

        if (width > 1100)
            setNombreNewsVisible(5);
        else
            setNombreNewsVisible(3);
    }
}

function ajouterUneNews() {
    var news = NewsInvisibles.pop();
    $("#NewsInternCarousel").trigger("insertItem", news);
}

function supprimerUneNews(numero) {
    var news = $("#NumNews" + numero);
    NewsInvisibles.push(news);
    $("#NewsInternCarousel").trigger("removeItem", news);
}

function setNombreNewsVisible(nombre) {
    $("#NewsInternCarousel").trigger("configuration", ["items.visible", nombre]);
}