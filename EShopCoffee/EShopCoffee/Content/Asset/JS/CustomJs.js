$(window).scroll(function () {
    var sticky = $("#Nav-Bar");
    scroll = $(window).scrollTop();
    if (scroll >= 100) {
        sticky.css("position", "sticky")
        sticky.css("top", "0")
        sticky.css("z-index", "100")
    } else {
        sticky.css("position", "relative")
        sticky.removeProperty("top")
    }
});

function reveal() {
    var reveals = document.querySelectorAll(".reveal");

    for (var i = 0; i < reveals.length; i++) {
        var windowHeight = window.innerHeight;
        var elementTop = reveals[i].getBoundingClientRect().top;
        var elementVisible = 150;

        if (elementTop < windowHeight - elementVisible) {
            reveals[i].classList.add("active");
        } else {
            reveals[i].classList.remove("active");
        }
    }
}

window.addEventListener("scroll", reveal);

$('.btn-number').click(function (e) {
    e.preventDefault();

    fieldName = $(this).attr('data-field');
    type = $(this).attr('data-type');
    var input = $("input[name='" + fieldName + "']");
    var currentVal = parseInt(input.val());
    if (!isNaN(currentVal)) {
        if (type == 'minus') {

            if (currentVal > input.attr('min')) {
                input.val(currentVal - 1).change();
            }
            if (parseInt(input.val()) == input.attr('min')) {
                $(this).attr('disabled', true);
            }

        } else if (type == 'plus') {

            if (currentVal < input.attr('max')) {
                input.val(currentVal + 1).change();
            }
            if (parseInt(input.val()) == input.attr('max')) {
                $(this).attr('disabled', true);
            }

        }
    } else {
        input.val(0);
    }
});
$('.input-number').focusin(function () {
    $(this).data('oldValue', $(this).val());
});
$('.input-number').change(function () {

    minValue = parseInt($(this).attr('min'));
    maxValue = parseInt($(this).attr('max'));
    valueCurrent = parseInt($(this).val());

    name = $(this).attr('name');
    if (valueCurrent >= minValue) {
        $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the minimum value was reached');
        $(this).val($(this).data('oldValue'));
    }
    if (valueCurrent <= maxValue) {
        $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the maximum value was reached');
        $(this).val($(this).data('oldValue'));
    }


});
$(".input-number").keydown(function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
        // Allow: Ctrl+A
        (e.keyCode == 65 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});
$("#faver_list").click(function (e) {
    var flag_faver = $("#faver_list").attr("heart");
    switch (flag_faver) {
        case "heart-o":
            $("#faver-icon").removeClass("fa-heart-o");
            $("#faver-icon").addClass("fa-heart");
            $("#faver-icon").css("color", "red");
            $("#faver_list").attr("heart", "heart");
            break;
        case "heart":
            $("#faver-icon").removeClass("fa-heart");
            $("#faver-icon").addClass("fa-heart-o");
            $("#faver_list").attr("heart", "heart-o");
            break;
    }
});

function openNav() {
    $("#mySidebar").addClass("w-25");
    $("#main").addClass("w-73");
    $("#main").removeClass("ml-5");
    $("#main").removeClass("w-95");
    $("#mySidebar").removeClass("d-none");
    $("#main").removeClass("text-center");
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
    $("#main").addClass("w-95");
    $("#main").addClass("ml-5");
    $("#mySidebar").removeClass("w-25");
    $("#mySidebar").addClass("d-none");
    $("#main").removeClass("w-73");

}

//$('#multi22').mdbRange({
//    single: {
//        active: true,
//        multi: {
//            active: true,
//            rangeLength: 2,
//            counting: true,
//            countingTarget: ['#ex3', '#ex4']
//        }
//    }
//});
function formatSliderValues(value) {
    if (value == null) return 'Any';
    /* This code formats a number in a human value, by adding separators (forces 2 decimal). 
       Ex."12345.67" to "12,345.67"  */
    var formattedNumber = value.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    return '$' + formattedNumber;
}

var values = [0, 100, 200, 500, 1000, 1500, null];

//$("#slider-range").slider({
//    range: true,
//    max: values.length - 1,
//    values: [values[0], values.length - 1],
//    slide: function (event, ui) {
//        var min = values[ui.values[0]];
//        var max = values[ui.values[1]];
//        $("[name=min]").val(min);
//        $("[name=max]").val(max);
//        $("#min").text(formatSliderValues(min));
//        $("#max").text(formatSliderValues(max));
//    }
//});

/* show initial values */

//var min = values[$("#slider-range").slider("values", 0)];
//var max = values[$("#slider-range").slider("values", 1)];
//$("[name=min]").val(min);
//$("[name=max]").val(max);
//$("#min").text(formatSliderValues(min));
//$("#max").text(formatSliderValues(max));
//const setLabel = (lbl, val) => {
//    const label = $(`#slider-${lbl}-label`);
//    label.text(val);
//    const slider = $(`#slider-div .${lbl}-slider-handle`);
//    const rect = slider[0].getBoundingClientRect();
//    label.offset({
//        top: rect.top - 30,
//        left: rect.left
//    });
//}

//const setLabels = (values) => {
//    setLabel("min", values[0]);
//    setLabel("max", values[1]);
//}


//$('#ex2').slider().on('slide', function (ev) {
//    setLabels(ev.value);
//});
//setLabels($('#ex2').attr("data-value").split(","));