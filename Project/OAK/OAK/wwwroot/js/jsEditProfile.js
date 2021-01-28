var preview = document.getElementById("preview");
preview.onclick = function () {
    field.click();
}

var field = document.getElementById("input");
field.addEventListener("change", function () {
    var reader = new FileReader();
    reader.readAsDataURL(field.files[0]);
    reader.onload = function (e) {
        preview.src = e.target.result;
    }
});
