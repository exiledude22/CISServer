// If this was a library it would be called 'The incredible mess'
// Prototype hack-style jquery script used to test the feel of the user interface.
$(document).ready(function () {
    var refresh_interval = 1000;
    $(".hotspot").click(function () {
        console.log("hotspot clicked");
        $(this).css("margin-left", "1000px");
        var element = this;
        setTimeout(function () {
            $(element).remove();
        }, 400);
    });

    $("#show-more-button").click(function () {
        $(this).addClass("hidden");
        $.each($(".pending-services"), function () {
            $(this).removeClass("hidden");
        });
    });

    $(".service-container").click(function () {
        var hotspot_id = $(this).attr("hotspot-id");
        var service_id = $(this).attr("service-id");
        var service_container = $(this);
        var parent_offset = service_container.offset();
        service_container.css("top", parent_offset.top);
        service_container.css("left", parent_offset.left);

        $.each($(".hotspot"), function () {
            if ($(this).attr("hotspot-id") == hotspot_id) {
                $.each($(".static-service-container", $(this)), function () {
                    if ($(this).attr("service-id") == service_id) {
                        var offset = $(this).offset();
                        service_container.css("position", "absolute");
                        service_container.addClass("anim");
                        service_container.css("top", offset.top);
                        service_container.css("left", offset.left);
                        setTimeout(function () {
                            service_container.css("opacity", "0");
                            setTimeout(function () {
                                $(service_container).remove();
                                // TODO: merge
                            }, 300);
                        }, 600);
                        return false;
                    }
                });
                return false;
            }
        });
    });
});