
const fileInput = document.getElementById("Image");
const imagePreview = document.getElementById("imagePreview");
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

document.addEventListener("DOMContentLoaded", (event) => {

    console.log("DOM fully loaded and parsed");
});
var myForm = document.getElementById('form');
// You can also add a submit event listener to the form itself
myForm.addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default form submission
    let formData = new FormData(document.querySelector('form'));
    let obj = Object.fromEntries(formData.entries());
    SubmitPostForm(obj);
});
function SubmitPostForm(obj) {
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
            if (res && res.status == 200 & res.errors == null) {
                alert('Saved Successfully');
                window.location.reload();
            } else {
                alert('Error Occured');
            }
    })
        .catch(err => {
            alert("Error ");
    })
}