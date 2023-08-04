// Dynamically add-on fields

$(function() {
    // Remove button click
    $(document).on(
        'click',
        '[data-role="appendRow"] > .form-inline [data-role="remove"]',
        function(e) {
            e.preventDefault();
            $(this).closest('.form-row').remove();
        }
    );
    // Add button click
    $(document).on(
        'click',
        '[data-role="appendRow"] > .form-row [data-role="add"]',
        function(e) {
            e.preventDefault();
            var container = $(this).closest('[data-role="appendRow"]');
            new_field_group = container.children().filter('.form-row:first-child').clone();
          new_field_group.find('label').html('Upload Document'); new_field_group.find('input').each(function(){
                $(this).val('');
            });
            container.append(new_field_group);
        }
    );
});


//DuyVT file upload
//$(document).on('change', '.file-upload', function(){
//  var i = $(this).prev('label').clone();
//  var file = this.files[0].name;
//  $(this).prev('label').text(file);
//});

// Dynamically add-on fields

$(function() {
    // Remove button click
    $(document).on(
        'click',
        '[data-role="appendRow1"] > .form-inline [data-role="remove"]',
        function(e) {
            e.preventDefault();
            $(this).closest('.form-row').remove();
        }
    );
    // Add button click
    $(document).on(
        'click',
        '[data-role="appendRow1"] > .form-row [data-role="add"]',
        function(e) {
            e.preventDefault();
            var container = $(this).closest('[data-role="appendRow1"]');
            new_field_group = container.children().filter('.form-row:first-child').clone();     
            var guid = (new Date()).getTime().toString();
            $(new_field_group).find('input[type=file]')[0].id = 'file' + guid;
            $(new_field_group).find('.js-labelFile').attr('for', 'file' + guid);
            $(new_field_group).find('.js-fileName').text('Choose a file');
            container.append(new_field_group);
            addFileInputEvent();
        }
    );
});


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
	$( "#datepicker1" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker2" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker3" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker4" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker5" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker6" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker7" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker8" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker9" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker11" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepicker12" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
	});
	$( "#datepickerdate" ).datepicker({
		dateFormat: "dd-mm-yy"
		,	duration: "fast"
    });
    currentTab = 0;
    showTab(currentTab); // Display the current tab
    addFileInputEvent();
}	

function getIpVal(id) {
    return $(id).val();
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
        
        function nextPrev(n) {
          // This function will figure out which tab to display
          var x = document.getElementsByClassName("step");
          // Exit the function if any field in the current tab is invalid:
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

function getAllFiles() {
    var arr = [];
    $('.js-fileName').each(function (i, sp) {
        var name = $(sp).text();
        if (name != '') {
            var row = $(sp).parent().parent().parent();
            var tit = $(row).find('input[type=text]').val();
            var sls = $(row).find('select');
            var suspected = $(sls[0]).val();
            var type = $(sls[1]).val();
            var txt = $(row).find('textarea').val();
            arr.push(tit + '|' + suspected + '|' + type + '|' + name + '|' + txt);
        }
    });
    return arr;
}

$('body').on('click', '.stepIndicator', function() {
    var step_type = $(this).data("step_type");
    $(this).addClass('active');
    
    if(step_type == "2"){
        $(".step1").hide();
        $(".step2").show();
        $(".step3").hide();
        $(".step4").hide();
       
    } else if(step_type == "3"){
        $(".step1").hide();
        $(".step2").hide();
        $(".step3").show();
        $(".step4").hide();
        
    } else if(step_type == "4"){
        $(".step1").hide();
        $(".step2").hide();
        $(".step3").hide();
        $(".step4").show();
        
    } 
});