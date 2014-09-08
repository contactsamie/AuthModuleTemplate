jQuery( document ).ready(function( $ ) {

    // Menu Even for Responsive menu on greater than 979 screen
    var addActiveClass = false;

    $("#rox-main-menu li.dropdown > a, #rox-main-menu li.dropdown-submenu > a").on("click", function(e) {

        if($(window).width() > 979) return;

        e.preventDefault();

        addActiveClass = $(this).parent().hasClass("submenu-active");

        $("#rox-main-menu").find(".submenu-active").removeClass("submenu-active");

        if(!addActiveClass) {
            $(this).parents("li").addClass("submenu-active");

        }

        return;

    });

    // Submenu Visible space measurement
    $("#rox-main-menu li.dropdown-submenu").hover(function() {

        if($(window).width() < 767) return;

        var subMenu = $(this).find("ul.dropdown-menu");

        if(!subMenu.get(0)) return;

        var screenWidth = $(window).width(),
            subMenuOffset = subMenu.offset(),
            subMenuWidth = subMenu.width(),
            subMenuParentWidth = subMenu.parents("ul.dropdown-menu").width(),
            subMenuPosRight = subMenu.offset().left + subMenu.width();

        if(subMenuPosRight > screenWidth) {
            subMenu.css("margin-left", "-" + (subMenuParentWidth + subMenuWidth + 0) + "px");
        } else {
            subMenu.css("margin-left", 0);
        }

    });

    // Mega Menu Component loading error fixing
    $(document).on("click", ".mega-menu .dropdown-menu", function(e) {
        e.stopPropagation()
    });



    //Appending Mobile menu to div id mobilemenu
    $('.mega-menu').mobileMenu({
        defaultText: 'Navigate to...',
        className: 'select-menu',
        subMenuDash:'&gt;',
        appendTo: '#mobilemenu'
    });

    //Dynamic Leveling the menu for better performance
    $('ul').each(function() {
        var depth = $(this).parents('ul').length;
        $(this).addClass('level-' + depth);
    });

});



//Enable only when you need to add extra class to mobile menu
$(document).ready(function() {
    var $window = $(window);

    // Function to handle changes to style classes based on window width
    function checkWidth() {
        if ($window.width() <= 1200) {
            $('#rox-search').removeClass('search-visible').addClass('search-hidden');
            $('.logo').removeClass('logo-big').addClass('logo-small');
            $('.mega-menu').removeClass('rox-menu').addClass('small-sub-menu');

        };

        if ( $window.width() <=970 || $window.width() > 1201) {
            $('#rox-search').removeClass('search-hidden').addClass('search-visible');
            $('.logo').removeClass('logo-small').addClass('logo-big');
            $('.mega-menu').removeClass('small-sub-menu').addClass('rox-menu');
        }

//        responsive menu container width fixing
        if($window.width() <=975){
            $('.rox-header').removeClass('normal-menu').addClass('res-menu');
        }else{
            $('.rox-header').removeClass('res-menu').addClass('normal-menu');
        }

        if($window.width() <= 775){
            $('.header-top').removeClass('visible').addClass('hidden');
        }else{
            $('.header-top').removeClass('hidden').addClass('visible');
        }

        if($window.width() <=625){
            $('.rox-header').removeClass('res-menu').addClass('mobile-menu-active');

        }else {
                $('.rox-header').removeClass('mobile-menu-active');
        }


    }

    // Execute on load
    checkWidth();

    // Bind event listener
    $(window).resize(checkWidth);
});

