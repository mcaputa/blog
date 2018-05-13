(function ($) {
    $(document).ready(function () {

        //$('.slider-container-properties').slick({
        //    accessibility: true,
        //    adaptiveHeight: true,
        //    variableWidth: true,
        //    infinite: true,
        //    slidesToShow: 3,
        //    slidesToScroll: 3
        //});

        // fade in .navbar
        $(function () {
            $(window).scroll(function () {
                var isMobile = window.matchMedia("(max-width: 767.98px)");

                if (!isMobile.matches) {
                    if ($(this).scrollTop() > 180) {
                        $('.info-bar-properties').slideUp();
                        $('.navabar-brand-properties').slideUp();

                    }
                    else {
                        $('.info-bar-properties').slideDown();
                        $('.navabar-brand-properties').slideDown();
                    }
                }
            });
        });

    });
}(jQuery));