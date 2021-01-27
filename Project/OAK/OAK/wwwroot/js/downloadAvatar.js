var preview = document.getElementById("preview");
preview.onclick = function () {
    input.click();
}

var input = document.getElementById("input");
input.addEventListener("change", function () {
    var reader = new FileReader();
    reader.readAsDataURL(input.files[0]);
    reader.onload = function (e) {
        preview.src = e.target.result;
    }
});
