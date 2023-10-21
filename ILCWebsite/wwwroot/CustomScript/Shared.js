const fileInput = document.getElementById("ImagePath");
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