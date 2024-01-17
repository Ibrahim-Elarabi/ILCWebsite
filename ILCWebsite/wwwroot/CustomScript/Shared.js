
const fileInput = document.getElementById("Image");
const imagePreview = document.getElementById("imagePreview");
if (fileInput) {
    fileInput.addEventListener("change", function () {
        const file = fileInput.files[0];
        if (file) {
            const reader = new FileReader();

            reader.onload = function (e) {
                imagePreview.src = e.target.result;
            };

            reader.readAsDataURL(file);
        } else {
            imagePreview.src = ""; // Clear the preview if no file is selected
        }
    });
} else {
    // Handle the case where the element with ID "Image" doesn't exist
    console.error("Element with ID 'Image' not found.");
}
 

document.addEventListener("DOMContentLoaded", (event) => {

    console.log("DOM fully loaded and parsed");
});
var myForm = document.getElementById('formAdmin');
// You can also add a submit event listener to the form itself
if (myForm) {
    myForm.addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent the default form submission
        let formData = new FormData(document.getElementById('formAdmin'));
        let obj = Object.fromEntries(formData.entries());
        SubmitPostForm(obj);
    });
}

function SubmitPostForm(obj) {  
    $("#divLoader").show();
    let el = document.getElementById('URL');
    let url = null;
    if (el) {
        url = el.value;
    }
    axios.post(url, obj, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    })
        .then(res => {
            $("#divLoader").hide();
            if (res && res.data && res.data.success) {
                if (res.data.success) {
                    /*   window.location.reload();*/
                    debugger;
                    swal.fire({
                        icon: "success",
                        title: "Success",
                        text: res.data.message,
                    }).then(function () {
                        window.location.reload();
                    });
                }
                else {
                    swal.fire({
                        icon: "warning",
                        title: "Failed",
                        text: res.data.message
                    });
                }
            }
        })
        .catch(err => {
            swal.fire({
                icon: "error",
                title: "Failed",
                text: "Error has been happend",
            });
        })
}


