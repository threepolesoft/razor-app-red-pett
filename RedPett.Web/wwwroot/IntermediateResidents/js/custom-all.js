// Dynamically add-on fields

$(function () {
    // Remove button click
    $(document).on('click', '[data-role="appendRow"] > .form-inline [data-role="remove"]', function (e) {
        e.preventDefault();
        var container = $(this).closest('[data-role="appendRow"]');
        if (container.children('.form-row').length > 1) { // Check if there is more than one row
            $(this).closest('.form-row').remove();
        }
    });

    // Add button click
    $(document).on('click', '[data-role="appendRow"] > .form-row [data-role="add"]', function (e) {
        e.preventDefault();
        var container = $(this).closest('[data-role="appendRow"]');
        var lastFieldGroup = container.children().last();
        var new_field_group = lastFieldGroup.clone();
        //new_field_group.find('label').html('Upload Document');
        new_field_group.find('select').val(''); // Clear the value of the select element
        container.append(new_field_group);
    });

    // Disable selecting the same value for all select elements
    $(document).on('change', '[data-role="appendRow"] select', function () {
        var value = $(this).val();
        $('[data-role="appendRow"] select').not(this).find('option[value="' + value + '"]').prop('disabled', false);
        $(this).siblings('select').find('option[value="' + value + '"]').prop('disabled', true);
    });
});


//DuyVT file upload
//$(document).on('change', '.file-upload', function(){
//  var i = $(this).prev('label').clone();
//  var file = this.files[0].name;
//  $(this).prev('label').text(file);
//});

// Dynamically add-on fields

$(function () {
    // Remove button click
    $(document).on(
        'click',
        '[data-role="appendRow1"] > .form-inline [data-role="remove"]',
        function (e) {
            e.preventDefault();
            $(this).closest('.form-row').remove();
        }
    );

    // Add button click
    $(document).on(
        'click',
        '[data-role="appendRow1"] > .form-row [data-role="add"]',
        function (e) {
            e.preventDefault();
            debugger
            var container = $(this).closest('[data-role="appendRow1"]');
            var new_field_group = container.children().filter('.form-row:first-child').clone();
            var guid = (new Date()).getTime().toString();
            var fileInput = new_field_group.find('input[type="file"]');
            if (fileInput.length > 0) {
                fileInput[0].id = 'file' + guid;
            }
            $(new_field_group).find('.js-labelFile').attr('for', 'file' + guid);
            $(new_field_group).find('.js-fileName').text('Choose a file');
            // Clear the text input fields, checkboxes, and radio buttons in the cloned row
            new_field_group.find('input[type="text"]').val('');
            new_field_group.find('input[type="checkbox"]').prop('checked', false);
            new_field_group.find('input[type="radio"]').prop('checked', false);
            new_field_group.find('select').prop('selectedIndex', 0);

            // Clear the file input in the cloned row
            clearFileInput(new_field_group.find('input[type="file"]'));

            container.append(new_field_group);

            // Show Label 1 and hide Label 2 for the new row
            new_field_group.find('.js-labelFile').addClass('d-none');
            new_field_group.find('.js-labelFile-upload').removeClass('d-none');
            addFileInputEvent();
        }
    );
});

// Custom function to clear the file input
function clearFileInput(input) {
    // Create a new file input element
    var newInput = $('<input type="file" class="' + input.attr('class') + '" id="' + input.attr('id') + '" name="' + input.attr('name') + '">');

    // Replace the existing file input with the new one
    input.replaceWith(newInput);

    // Get the corresponding labels for the file input
    var uploadLabel = $('label[for="' + input.attr('id') + '"]');
    var downloadLabel = $('label[data-target="' + input.attr('id') + '"]');

    // Show/hide labels based on file input value
    if (input.val() === '') {
        uploadLabel.removeClass('d-none');
        downloadLabel.addClass('d-none');
    } else {
        uploadLabel.addClass('d-none');
        downloadLabel.removeClass('d-none');
    }
}


//DuyVT file upload
//$(document).on('change', '.file-upload', function(){
//  var i = $(this).prev('label').clone();
//  var file = this.files[0].name;
//  $(this).prev('label').text(file);
//});

var currentTab = 0; // Current tab is set to be the first tab (0)
function initDatePicker() {
    $("#datepicker").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker1").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker2").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker3").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker4").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker5").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker6").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker7").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker8").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker9").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker11").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepicker12").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    $("#datepickerdate").datepicker({
        dateFormat: "dd-mm-yy"
        , duration: "fast"
    });
    currentTab = 0;
    showTab(currentTab); // Display the current tab
    addFileInputEvent();
}

function getIpVal(id) {
    return $(id).val();
}
function getIpValText(id) {
    return $(id).text();

}

function getRadioVal(type) {
    return $('input[name="' + type + '"]:checked').val();
}

function getListVal(clas) {
    var arr = [];
    $.each($(clas + ' select'), function (i, sl) {
        arr.push($(sl).val());
    });
    return arr;
}

function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("step");
    x[n].style.display = "block";
    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == 0) {
        document.getElementById("prevBtn1").style.display = "none";
    } else {
        document.getElementById("prevBtn1").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").style.display = "none";
        document.getElementById("nextBtn1").style.display = "none";
    }


    else {
        document.getElementById("nextBtn").innerHTML = "Next";
        document.getElementById("nextBtn1").innerHTML = "Next";
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}
function myFunction() {
    var pttspan = document.getElementById("pttspan");
    pttspan.innerText = "";
}
function problemDescriptionFunction() {
    var problemDescriptionspan = document.getElementById("problemDescriptionspan");
    problemDescriptionspan.innerText = "";
}
function myFunction1() {
    var ptspan = document.getElementById("ptspan");
    ptspan.innerText = "";
}
function myFunction2() {
    var daspan = document.getElementById("daspan");
    daspan.innerText = "";
}

function valuechange() {
    var fetpspan = document.getElementById("fetpspan");
    fetpspan.innerText = "";
}
<<<<<<< HEAD

function pagePre(){

    var sl=$(".pre_page").attr("data");

    var n_sl=Number(sl)+1;


     document.getElementById("nextBtn").style.display = "block";
     document.getElementById("nextBtn1").style.display = "block";

    if(sl==1){

         document.getElementById("nextBtn").style.display = "block";
         document.getElementById("nextBtn1").style.display = "block";
        document.getElementById("prevBtn").style.display = "none";
        document.getElementById("prevBtn1").style.display = "none";
    }


    $(".next_page").attr("data", n_sl);
    $(".pre_page").attr("data", sl-1);

    indicator(sl);

}

function pageNext() {

   
=======
function nextPrev(n) {
>>>>>>> parent of db6858d (Navigation and General Comments issue fix)
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("step");
    var fetpspan = document.getElementById("fetpspan");
    var ptspan = document.getElementById("ptspan");
    var daspan = document.getElementById("daspan");
    var pttspan = document.getElementById("pttspan");

    var textboxValue = document.getElementById("pTitle").value;
    var pAssigned = document.getElementById("pAssigned").value;
    var fetp = document.getElementById("sRoleId").value;
    var pType = document.getElementById("pj").value;
    if (textboxValue === "" && pAssigned === "" && fetp === "" && pType === "") {
        fetpspan.innerText = "FETP is required*";
        ptspan.innerText = "Project Type is required*";
        daspan.innerText = "Date Assigned is required*";
        pttspan.innerText = "Project Title is required*";
        return false;
    }
    if (textboxValue === "" && pAssigned === "" && fetp === "") {
        fetpspan.innerText = "FETP is required*";
        daspan.innerText = "Date Assigned is required*";
        pttspan.innerText = "Project Title is required*";
        return false;
    }
    if (textboxValue === "" && pAssigned === "" && pType === "") {
        ptspan.innerText = "Project Type is required*";
        daspan.innerText = "Date Assigned is required*";
        pttspan.innerText = "Project Title is required*";
        return false;
    }
    if (textboxValue === "" && fetp === "" && pType === "") {
        fetpspan.innerText = "FETP is required*";
        ptspan.innerText = "Project Type is required*";
        pttspan.innerText = "Project Title is required*";
        return false;
    }
    if (pAssigned === "" && fetp === "" && pType === "") {
        fetpspan.innerText = "FETP is required*";
        ptspan.innerText = "Project Type is required*";
        daspan.innerText = "Date Assigned is required*";
        return false;
    }
    if (textboxValue === "") {
        pttspan.innerText = "Project Title is required*";
        return false;
    }
    if (pAssigned === "") {
        daspan.innerText = "Date Assigned is required*";
        return false;
    }
    if (fetp === "") {
        fetpspan.innerText = "FETP is required*";
        return false;
    }
    if (pType === "") {
        ptspan.innerText = "Project Type is required*";
        return false;
    }
    fetpspan.innerText = "";
    ptspan.innerText = "";
    daspan.innerText = "";
    pttspan.innerText = "";
    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("signUpForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("step");
    y = x[currentTab].getElementsByTagName(" ");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false
            valid = false;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("stepIndicator")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("stepIndicator");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}

function addFileInputEvent() {
    $('.input-file').each(function () {
        var $input = $(this),
            $label = $input.next('.js-labelFile'),
            labelVal = $label.html();
        var txt = $input.parent().find('textarea');
        $input.on('change', function (element) {
            var file = element.target.files[0];
            var fileName = file.name;
            //if (element.target.value) fileName = element.target.value.split('\\').pop();
            fileName ? $label.addClass('has-file').find('.js-fileName').html(fileName) : $label.removeClass('has-file').html(labelVal);
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                console.log(reader.result);
                $(txt).val(file.type + '|' + file.size + '|' + reader.result);
            };
            reader.onerror = function (error) {
                console.log('Error: ', error);
            };
        });
    });
}

function getAllFiles(Role) {
    var arr = [];
    debugger
    $('.js-fileName').each(function (i, sp) {
        var name = $(sp).text();
        if (name != '') {
            var row = $(sp).parent().parent().parent();
            var tit = $(row).find('#tit').val();

            var cit = $(row).find('#cit').val();
            var sub = $(row).find('#sub').val();
            var pSubmissionDate = $(row).find('#pSubmissionDate').val();
            var sls = $(row).find('select');
            if (Role == "Resident") {
                var residName = $(row).find('#residName').val();
                var suspected = $(sls[0]).val();
                var type = $(sls[1]).val();
            } else if (Role == "Non-Resident") {
                var residName = $(sls[0]).val();
                var suspected = $(sls[1]).val();
                var type = $(sls[2]).val();
            }

            var txt = $(row).find('textarea').val();
            var reqValue = $(row).find('#req:checked').val();
            var acc = $(row).find('#acc:checked').val();
            arr.push(tit + '|' + suspected + '|' + type + '|' + name + '|' + txt + '|' + residName + '|' + cit + '|' + sub + '|' + pSubmissionDate + '|' + reqValue + '|' + acc + '|' + currentresid);
        }
    });
    return arr;
}
function getAllComments() {
    var arr = [];
    $('.gcomments').each(function (i, sp) {
        var row = $(sp).parent();
        var text = $(row).find('#cText').val();
        arr.push(text);
    });
    return arr;
}

$('body').on('click', '.stepIndicator', function () {
    var step_type = $(this).data("step_type");
    $(this).addClass('active');

    if (step_type == "2") {
        $(".step1").hide();
        $(".step2").show();
        $(".step3").hide();
        $(".step4").hide();

    } else if (step_type == "3") {
        $(".step1").hide();
        $(".step2").hide();
        $(".step3").show();
        $(".step4").hide();

    } else if (step_type == "4") {
        $(".step1").hide();
        $(".step2").hide();
        $(".step3").hide();
        $(".step4").show();

    }
});