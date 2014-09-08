/*
* Apply Browser Selector from plugin
* Apply Page scroll From Plugin
* */
jQuery( document ).ready(function( $ ) {
// Select Browser with browserselector
    $.browserSelector();

    // If browser is chrome then add smooth scroll
    if($("html").hasClass("chrome")) {
        $.smoothScroll();
    }

    //Moving recursive function

    function moving(){
        $(".design-main-image").animate( {"top": "+=20px"}, 1500, "linear", function() {
            $(".design-main-image").animate( {"top": "-=20px"}, 1500, "linear", function() {
                moving();
            });
        });
    }
    moving();


//  Sticky menu
     var nav = $('.rox-header');
     var scrolled = false;

     $(window).scroll(function () {

         if (500 < $(window).scrollTop() && !scrolled) {
             nav.addClass('sticky animated fadeInDown').animate({ 'margin-top': '0px' });

             scrolled = true;
         }

         if (500 > $(window).scrollTop() && scrolled) {
             nav.removeClass('sticky animated fadeInDown').css('margin-top', '0px');

             scrolled = false;
         }
     });

});

jQuery(document).ready(function($) {
    $( "#footer-two" ).append( "<a href=\'#\' class=\'back-to-top\'><i class=\'fa fa-angle-up\'></i></a>" );
    var offset = 220;
    var duration = 500;
    $(window).scroll(function() {
        if ($(this).scrollTop() > offset) {
            $('.back-to-top').fadeIn(duration);
        } else {
            $('.back-to-top').fadeOut(duration);
        }
    });

    $('.back-to-top').click(function(event) {
        event.preventDefault();
        $('html, body').animate({scrollTop: 0}, 1000);
        return false;
    })
});
