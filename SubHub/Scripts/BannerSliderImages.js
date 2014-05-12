
var unslider = $('.banner-slider-images').unslider();

$('.unslider-arrow').click(function () {
    var fn = this.className.split(' ')[1];
    unslider.data('unslider')[fn]();

    $('.banner-slider-images').unslider({
        dots: true
    })
});
