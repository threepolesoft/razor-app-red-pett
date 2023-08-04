$('.tab-link').click( function() {
	
	var tabID = $(this).attr('data-tab');
	
	$(this).addClass('active').siblings().removeClass('active');
	
	$('#tab-'+tabID).addClass('active').siblings().removeClass('active');
});

$(document).ready(function(){
  $('.accordion-list > li > .ui-brd').hide();
    
  $('.accordion-list > li').click(function() {
      $(this).removeClass("deafult_active");
    if ($(this).hasClass("active")) {
      $(this).removeClass("active").find(".ui-brd").slideUp();
    } else {
      $(".accordion-list > li.active .ui-brd").slideUp();
      $(".accordion-list > li.active").removeClass("active");
      $(this).addClass("active").find(".ui-brd").slideDown();
    }
    return false;
  });

$(".deafult_active").trigger( "click" );  
$('.deafult_active').click(function() {
  $(".accordion-list > li.active .ui-brd").slideUp();
  $(".accordion-list > li.active").removeClass("active");
  $(this).addClass("active").find(".ui-brd").slideDown();
    //return false;
});

  
});

$('a[href^="#"]').on('click',function (e) {
 
	
  var target = this.hash,
      $target = $(target);
 
  $('html, body').stop().animate({
    'scrollTop': $target.offset().top-10
  }, 900, 'swing', function () {
    window.location.hash = target;
  });
});
 


$(document).ready(function(){
      $('.work-slide').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows:false ,
        dots: false,
        speed: 300,
        infinite: true,
		 fade: false,		   
        autoplaySpeed: 3000,
        autoplay: true,
        responsive: [
      {
        breakpoint: 991,
        settings: {
       slidesToShow: 1,
        }
      },
      {
        breakpoint: 767,
        settings: {
          slidesToShow: 1,
        }
      }
    ]
      });
	});
