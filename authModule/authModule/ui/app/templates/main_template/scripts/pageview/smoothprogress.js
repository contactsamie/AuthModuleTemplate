/*!
*Auto Csroll Smooth Progress Bar
*Modified by Rox Niam
*Author ThemeRox
*email: info@themerox.com

Main Author
 * bootstrap-progressbar v0.6.0 by @minddust
 * Copyright (c) 2012-2013 Stephan Gross
 *
 * https://www.minddust.com/bootstrap-progressbar
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

jQuery( document ).ready(function( $ ) {

    $.fn.visible = function(partial,hidden,direction){

        var $t              = $(this).eq(0),
            t               = $t.get(0),
            $w              = $(window),
            viewTop         = $w.scrollTop(),
            viewBottom      = viewTop + $w.height(),
            viewLeft        = $w.scrollLeft(),
            viewRight       = viewLeft + $w.width(),
            _top            = $t.offset().top,
            _bottom         = _top + $t.height(),
            _left           = $t.offset().left,
            _right          = _left + $t.width(),
            compareTop      = partial === true ? _bottom : _top,
            compareBottom   = partial === true ? _top : _bottom,
            compareLeft     = partial === true ? _right : _left,
            compareRight    = partial === true ? _left : _right,
            clientSize      = hidden === true ? t.offsetWidth * t.offsetHeight : true,
            direction       = (direction) ? direction : 'both';

        if(direction === 'both')
            return !!clientSize && ((compareBottom <= viewBottom) && (compareTop >= viewTop)) && ((compareRight <= viewRight) && (compareLeft >= viewLeft));
        else if(direction === 'vertical')
            return !!clientSize && ((compareBottom <= viewBottom) && (compareTop >= viewTop));
        else if(direction === 'horizontal')
            return !!clientSize && ((compareRight <= viewRight) && (compareLeft >= viewLeft));
    };

});
jQuery(document).ready(function($) {
   $(window).scroll(function() {
      if($('.h-default-themed .bar:last').visible(true)) {

        $('.bar').progressbar();

      }
    });
});





