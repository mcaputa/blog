import 'bootstrap';
import '../sass/main.scss'

(function ($) {
    $(document).ready(function () {

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