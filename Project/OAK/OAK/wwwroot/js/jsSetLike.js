function SetLike(data, id) {
    if (data == "like") { LikeYes(id); }
    else if (data == "no like") { LikeNo(id); }
    else if (data == "none") { LikeNone(id); }
}
function LikeYes(id) {
    $(id + " > img").attr("src", "/icons/like yes.png");
    $(id + " > p").css("color", "#FF0000");
}
function LikeNo(id) {
    $(id + " > img").attr("src", "/icons/like no.png");
    $(id + " > p").css("color", "#747A8D");
}
function LikeNone(id) {
    $(id).css("cursor", "default");
    $(id + " > img").attr("src", "/icons/like none.png");
    $(id + " > p").css("color", "#666666");
}