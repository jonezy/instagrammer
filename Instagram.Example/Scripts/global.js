$(document).ready(function() {
    $(".user_feed a[rel^='prettyPhoto']").prettyPhoto({
        animationSpeed: 'fast',
        theme: 'light_square',
        allow_resize: false,
        show_title: false
    });

    $(".recent_media a[rel^='prettyPhoto']").prettyPhoto({
        animationSpeed: 'fast',
        theme: 'light_square',
        allow_resize: false,
        show_title: false
    });
});

function FlashMessage(message, cssClas) {
    $('#flash').html(message);
    $('#flash').removeClass();
    $('#flash').addClass(cssClas);
    $('#flash').slideDown('med');
    $('#flash').click(function(){$('#flash').toggle('highlight')});
    
    window.setTimeout(function() {
        $("#flash").fadeOut("slow"); 
    }, 3000);
}