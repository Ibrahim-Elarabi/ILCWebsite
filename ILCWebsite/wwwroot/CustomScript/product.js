var data = [];

function generateId() {
    return '_' + Math.random().toString(36).substr(2, 9);
}

function addData() {

    const titleEnInput = document.getElementById('specTitleEn');
    const titleArInput = document.getElementById('specTitleAr');
    const DescEnInput = document.getElementById('specDescEn');
    const DescArInput = document.getElementById('specDescAr');

    const titleEnval = titleEnInput.value;
    const titleArval = titleArInput.value;
    const DescEnVal = DescEnInput.value;
    const DescArVal = DescArInput.value;
    //const newKey = keyInput.value;
    //const newValue = valueInput.value;

    if (titleEnval.trim() !== "" && titleArval.trim() !== "" && DescEnVal.trim() !== "" && DescArVal.trim() !== "") {
        data.push({ uniqueId: generateId(), TitleEn: titleEnval, TitleAr: titleArval, DescriptionEn: DescEnVal, DescriptionAr: DescArVal });
        displayData();
        //keyInput.value = "";
        //valueInput.value = "";
        titleEnInput.value = "";
        titleArInput.value = "";
        DescEnInput.value = "";
        DescArInput.value = "";
    }
}

function deleteData(id) {
    data = data.filter(item => item.uniqueId !== id);
    displayData();
}

function displayData() {
    const tableBody = document.getElementById('table-body');
    tableBody.innerHTML = "";

    data.forEach(item => {
        const row = document.createElement('tr');
        row.innerHTML = `
                                        <td>${item.TitleEn}</td>
                                        <td>${item.TitleAr}</td>
                                        <td><button class="btn btn-danger btn-sm" onclick="deleteData('${item.uniqueId}')">Delete</button></td>
                                    `;
        tableBody.appendChild(row);
    });
}
// Initial display
displayData();

function clearForm() {
    document.getElementById("formProduct").reset();
    var imagePreview = document.getElementById("imagePreview");
    imagePreview.src = "";
}


//Display Other Images
jQuery(document).ready(function () {
    ImgUpload();
});

function ImgUpload() {
    var imgWrap = "";
    var imgArray = [];
    $('.upload__inputfile').each(function () {
        $(this).on('change', function (e) {
            imgWrap = $(this).closest('.upload__box').find('.upload__img-wrap');
            var maxLength = $(this).attr('data-max_length');

            var files = e.target.files;
            var filesArr = Array.prototype.slice.call(files);
            var iterator = 0;
            filesArr.forEach(function (f, index) {

                if (!f.type.match('image.*')) {
                    return;
                }

                if (imgArray.length > maxLength) {
                    return false
                } else {
                    var len = 0;
                    for (var i = 0; i < imgArray.length; i++) {
                        if (imgArray[i] !== undefined) {
                            len++;
                        }
                    }
                    if (len > maxLength) {
                        return false;
                    } else {
                        imgArray.push(f);

                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var html = "<div class='upload__img-box'><div style='background-image: url(" + e.target.result + ")' data-number='" + $(".upload__img-close").length + "' data-file='" + f.name + "' class='img-bg'><div class='upload__img-close'></div></div></div>";
                            imgWrap.append(html);
                            iterator++;
                        }
                        reader.readAsDataURL(f);
                    }
                }
            });
        });
    });
    $('body').on('click', ".upload__img-close", function (e) {
        var file = $(this).parent().data("file");
        for (var i = 0; i < imgArray.length; i++) {
            if (imgArray[i].name === file) {
                imgArray.splice(i, 1);
                break;
            }
        }
        $(this).parent().parent().remove();
    });
}

const prodForm = document.getElementById('formProduct');
// You can also add a submit event listener to the form itself
prodForm.addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default form submission
    let formData = new FormData(document.getElementById('formProduct'));
    let images = [];
    const files = document.getElementById('otherImagesId').files;

    for (let i = 0; i < files.length; i++) {
        formData.append('Images', files[i]);
    }
    data.forEach((spc, index) => {
        Object.keys(spc).forEach(key => {
            formData.append(`Specifications[${index}].${key}`, spc[key]);
        });
    });
    SubmitPostForm(formData);
});
