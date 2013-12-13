$(window).resize(function () {
    setFooter();
});


function setFooter() {
    if (document.getElementById) {
        var windowHeight = innerHeight;
        
        if (windowHeight > 0) {
            var contentHeight = $('body').height();
            var footerElement = $('footer');
            
            if (windowHeight - (contentHeight) >= 0) {
                footerElement.css('position', 'relative');
                footerElement.css('top', (windowHeight - (contentHeight + 10)) + 'px');
            }
            else {
                footerElement.css('position', 'static');
            }
        }
    }
}