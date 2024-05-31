
var emailPattern = /^[a-zA-Z0-9.!#$%&*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
//var egyPhonePattern = /^01[0-1-2-5]\d{8}$/;
var countryCodePattern = /^\+[1-9]{1,3}$/; ///^01\d{9}$/;
var phonePattern = /^[0-9]{11}$/; ///^01\d{9}$/;
var cardPattern = /^\d{4}$/;    
var numberPattern = /^(?!0+$)\d+$/;
var passportPattern = /^[A-Z][0-9]{8}$/;
var foreignPattern = /^\d{6,}$/;

function doRequiredCheck(id, elementName) {
    var el = document.getElementById(id);
    var box = document.getElementById(id + "_message");
    if (el.value === "" || el.value === "-1" ) {
        box ? box.innerHTML = elementName + " Is Required":0;
        return false;
    } else {
       box? box.innerHTML = "":0;
        return true;
    }
}
function doCheckLength(id, len, elementName) {
    var el = document.getElementById(id);
    var box = document.getElementById(id + "_message");
    if (el.value.length > len) {
        box.innerHTML = elementName + " too long , max length is (" + len + ") characters";
        return false;
    } else {
        box ? box.innerHTML = "" : 0;
        return true;
    }
}

function doCheckMax(id, max) {
    var el = document.getElementById(id);
    var box = document.getElementById(id + "_message");
    if (el.value > max) {
        box.innerHTML = "Max Transfer " + id + " is " + max;
        return false;
    } else {
        box ? box.innerHTML = "" : 0;
        return true;
    }
}
function doCheckPattern(id, pattern, elementName) {  
    var el = document.getElementById(id).value;
    var box = document.getElementById(id + "_message"); 
        if (!el.match(pattern)) {
            box.innerHTML = elementName + " Is Not Valid."; 
            return false;
        } else {
            return true;
        } 
}
//function doCheckPattern(country_code_class, id, pattern) {
//    debugger
//    var el =  document.getElementById(id).value;
//    var box = document.getElementById(id + "_message");
//    let countrycode = "";
//    if (country_code_class != "" && $('.' + country_code_class + ' option:selected').val() != undefined) {
//        countrycode = '+' + $('.' + country_code_class + ' option:selected').val().replace('+', '');
//        if (!countrycode.match(countryCodePattern)) {
//            box.innerHTML = id + " Is Not Valid.";
//            return false;
//        }

//        if (countrycode == "+2") {
//            if (!el.match(pattern)) {
//                box.innerHTML = id + " Is Not Valid.";
//                return false;
//            } else {
//                box ? box.innerHTML = "" : 0;
//                return true;
//            }
//        } else {
//            if (!el.match(foreignPattern)) {
//                box.innerHTML = id + " Is Not Valid.";
//                return false;
//            } else {
//                box ? box.innerHTML = "" : 0;
//                return true;
//            }
//        }
//    } else {
//        if (!el.match(pattern)) {
//            box.innerHTML = id + " Is Not Valid.";
//            box ? box.innerHTML = "" : 0;
//             return false;
//        } else {
//           return true;
//        }
//    }
//}

function doCheckBirthDate(id) {
    var el = document.getElementById(id).value;
    var box = document.getElementById(id + "_message");
    var maxDate = new Date(document.getElementById(id).max);

    if (new Date(el) > maxDate) {
        box.innerHTML = id + " Is Not Valid. " + id + " must not exceed " + maxDate.toLocaleDateString();
        return false;
    } else {
        box ? box.innerHTML = "" : 0;
        return true;
    }
}


function doCheckCommingDate(id) {
    var el = document.getElementById(id).value;
    var box = document.getElementById(id + "_message");
    var minDate = new Date(document.getElementById(id).min);

    if (new Date(el) < minDate) {
        box.innerHTML = id + " Is Not Valid. " + id + " must not befor " + minDate.toLocaleDateString();
        return false;
    } else {
        box ? box.innerHTML = "" : 0;
        return true;
    }
}


function confirmPasswords(passwordId,confirmPasswordId) { 
    var password = document.getElementById(passwordId).value;
    var confirmPassword = document.getElementById(confirmPasswordId).value;  
    var confirmPasswordMessage = document.getElementById(confirmPasswordId + "_message");

    if (password !== confirmPassword) { 
        confirmPasswordMessage.innerHTML = "Passwords do not match.";
        return false;
    } else { 
        confirmPasswordMessage.innerHTML = "";
        return true;
    }
}
function checkNationalId(id) {
    var el = document.getElementById(id);
    var box = document.getElementById(id + "_message");
    if (el.value != '' && el.value != undefined) {
        if (el.value.length != 14 || !isNumber(el.value)) {
            box.innerHTML='NationalId Must contain 14 Number.';
            return false;
        } else {
            box.innerHTML='';
            return true;
        }
    }
    else {
        return true;
    }
}
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}





//$(function () {
//    var dtToday = new Date(); 
//    var month = dtToday.getMonth() + 1;
//    var day = dtToday.getDate();
//    var year = dtToday.getFullYear();
//    if (month < 10)
//        month = '0' + month.toString();
//    if (day < 10)
//        day = '0' + day.toString(); 
//    var date = year + '-' + month + '-' + day;  
//    $('#appointmentDate').attr('min', date);
//    $('#BirthDate').attr('max', date);
//    $('#DateOfBirth').attr('max', date);
//});

function setMinDate(id) { 
    var dtToday = new Date();
    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString(); 
    var el = document.getElementById(id); 
    var date = year + '-' + month + '-' + day;
    el.setAttribute('min', date);
}
function setMaxDate(id) {  
    var dtToday = new Date();
    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString(); 
    var el = document.getElementById(id); 
    var date = year + '-' + month + '-' + day;
    el.setAttribute('max', date);
}

function setMinMonth(id) {
    var dtToday = new Date();
    var month = dtToday.getMonth() + 1;
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    var el = document.getElementById(id);
    var date = year + '-' + month;
    el.setAttribute('min', date);
}



 