jQuery(document).ready(function($){
	$('.custom-accordian .item-heading').hover(function(){
		
		var openclass = 'open col-sm-12 col-md-6 col-lg-6';
		var closeclass = 'col-sm-6 col-md-3 col-lg-3';
		
		var bodycloseclass = 'col-sm-12 col-md-12 col-lg-12';
		var bodyopenclass = 'col-sm-6 col-md-6 col-lg-6';		
	
		$('.item-heading, .item-collapse').addClass(bodycloseclass).removeClass(bodyopenclass );
		$('.item').addClass(closeclass).removeClass(openclass );
		
		$(this).closest('.item').addClass(openclass).removeClass(closeclass);
		$(this).closest('.item').find('.item-heading, .item-collapse').addClass(bodyopenclass).removeClass(bodycloseclass);	
		
		if(( $(window).width() < 900 ) && ( $(window).width() > 700)){
			$(this).closest('li').insertAfter('.custom-accordian li:last');	
			return false;
		}
		return false;
	})
})