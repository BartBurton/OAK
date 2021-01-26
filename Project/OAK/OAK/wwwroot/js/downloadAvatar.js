var prev = document.getElementById("profileAva");
prev.onclick = function()
{
    inpAva.click();
}

var inpAva = document.getElementById("profileAvaInp");
inpAva.addEventListener("change", loadImgFile);
function loadImgFile(){
    var reader = new FileReader();
    reader.readAsDataURL(inpAva.files[0]);
    reader.onload = function(e){
        prev.src = e.target.result;
    }
}
