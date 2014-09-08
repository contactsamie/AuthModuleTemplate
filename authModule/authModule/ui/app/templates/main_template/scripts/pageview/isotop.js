
/*
 * Isotop 
 * */

		jQuery(document).ready(function($){
		    // Load the first 3 list items from another HTML file
		    //$('#myList').load('externalList.html li:lt(3)');
		    //$('#portfolio div.element:lt(9)').show();
		    $('#loadMore').click(function () {
		        //$('#portfolio div.element:lt(21)').show();
		       /* $.ajax({
					  url: "portfolio-more.html",
					  context: document.body
					}).done(function(msg) {
					 div_content = $(msg).find("#portfolio");
					 alert(div_content );
				});*/

					$( "#portfolio" ).load( "portfolio-more.html #portfolio" );
		    });
		    
		});




 jQuery(document).ready(function($){
      
      var $container = $('#portfolio');

      $container.isotope({
        itemSelector : '.element'
      });
      var $optionSets = $('#options .option-set'),
          $optionLinks = $optionSets.find('a');

      $optionLinks.click(function(){
        var $this = $(this);
        // don't proceed if already selected
        if ( $this.hasClass('selected') ) {
          return false;
        }
        var $optionSet = $this.parents('.option-set');
        $optionSet.find('.selected').removeClass('selected');
        $this.addClass('selected');
  
        // make option object dynamically, i.e. { filter: '.my-filter-class' }
        var options = {},
            key = $optionSet.attr('data-option-key'),
            value = $this.attr('data-option-value');
        // parse 'false' as false boolean
        value = value === 'false' ? false : value;
        options[ key ] = value;
        if ( key === 'layoutMode' && typeof changeLayoutMode === 'function' ) {
          // changes in layout modes need extra logic
          changeLayoutMode( $this, options )
        } else {
          // otherwise, apply new options
          $container.isotope( options );
        }
        
        return false;
      });

      
    });






