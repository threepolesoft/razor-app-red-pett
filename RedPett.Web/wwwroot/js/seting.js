// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});// INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
}); $(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
}); $(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
}); $(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
}); $(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
}); $(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});       // INCLUDE JQUERY & JQUERY UI 1.12.1
$(function () {
    $("#datepicker").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});
$(function () {
    $("#datepicker1").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });

});
$(function () {
    $("#datepickereff").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });

});

$(function () {
    $("#datepicker2").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });

}); $('.prfo-sky').click(function () {
    $('#target').show(100);
    $('.prfo-sky').hide(0);
    $('.prfo-bks').show(0);
});
$('.prfo-bks').click(function () {
    $('#target').hide(200);
    $('.prfo-sky').show(0);
    $('.prfo-bks').hide(0);
});
$('.toggle').click(function () {
    $('#target').toggle('slow');
});

$(document).on("change", ".uploadProfileInput", function () {
    var triggerInput = this;
    var currentImg = $(this).closest(".pic-holder").find(".pic").attr("src");
    var holder = $(this).closest(".pic-holder");
    var wrapper = $(this).closest(".profile-pic-wrapper");
    $(wrapper).find('[role="alert"]').remove();
    triggerInput.blur();
    var files = !!this.files ? this.files : [];
    if (!files.length || !window.FileReader) {
        return;
    }
    if (/^image/.test(files[0].type)) {
        // only image file
        var reader = new FileReader(); // instance of the FileReader
        reader.readAsDataURL(files[0]); // read the local file       
        let file = this.files[0];
        reader.onloadend = function () {
            $(holder).addClass("uploadInProgress");
            $(holder).find(".pic").attr("src", this.result);
            $(holder).append(
                '<div class="upload-loader"><div class="spinner-border text-primary" role="status"><span class="sr-only">Loading...</span></div></div>'
            );

            var srcValue = $(holder).find(".pic").attr("src");

            // AJAX POST request to send the srcValue to the backend


            // Dummy timeout; call API or AJAX below          
            setTimeout(() => {
                $(holder).removeClass("uploadInProgress");
                $(holder).find(".upload-loader").remove();
                // If upload successful
                if (Math.random() < 0.9) {
                    $(wrapper).append(
                        '<div class="snackbar show" role="alert"><i class="fa fa-check-circle text-success"></i> Profile image updated successfully</div>'
                    );
                    // Clear input after upload
                    $(triggerInput).val("");
                    let userName = localStorage.getItem('UserName');
                    let fetchedUrl = window.location.origin;
                    let url;
                    if (fetchedUrl == "https://localhost:7265") {
                        url = "https://localhost:7194/api/TraineesInfo"
                    }
                    else {
                        url = "https://v3-web-app-for-api.azurewebsites.net/api/TraineesInfo"
                    }
                    $.ajax({
                        url: url,
                        headers: { "UserName": userName },
                        type: 'POST',
                        data: JSON.stringify({ ProfilePicture: this.result.split(',')[1] }),
                        contentType: 'application/json',
                        success: function (response) {
                            // Handle the server response if needed
                            console.log("Image src sent to controller successfully.");
                        },
                        error: function (error) {
                            // Handle any errors that occurred during the AJAX request
                            console.log("Error sending image src to controller:");
                        }
                    });

                    setTimeout(() => {
                        $(wrapper).find('[role="alert"]').remove();
                    }, 3000);
                } else {
                    $(holder).find(".pic").attr("src", currentImg);
                    $(wrapper).append(
                        '<div class="snackbar show" role="alert"><i class="fa fa-times-circle text-danger"></i> There is an error while uploading! Please try again later.</div>'
                    );

                    // Clear input after upload
                    $(triggerInput).val("");
                    setTimeout(() => {
                        $(wrapper).find('[role="alert"]').remove();
                    }, 3000);
                }
            }, 1500);
        };
    } else {
        $(wrapper).append(
            '<div class="alert alert-danger d-inline-block p-2 small" role="alert">Please choose the valid image.</div>'
        );
        setTimeout(() => {
            $(wrapper).find('role="alert"').remove();
        }, 3000);
    }
});

// -----Country Code Selection
$("#mobile_code").intlTelInput({
    initialCountry: "fr",
    separateDialCode: true,
    // utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/11.0.4/js/utils.js"
});
$("#mobile_code1").intlTelInput({
    initialCountry: "fr",
    separateDialCode: true,
    // utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/11.0.4/js/utils.js"
});

$("#home").intlTelInput({
    initialCountry: "fr",
    separateDialCode: true,
    //utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/11.0.4/js/utils.js"
});
$(".conrty").intlTelInput({
    utilsScript: "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/8.4.6/js/utils.js"
});

$(function () {
    $("#datepicker99").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
});


