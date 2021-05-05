function SetLike(data) {
    if (data == "like") { LikeYes(); }
    else if (data == "no like") { LikeNo(); }
    else if (data == "none") { LikeNone(); }
}
function LikeYes() {
    $("#like > img").attr("src", "/icons/like yes.png");
    $("#like > p").css("color", "#FF0000");
}
function LikeNo() {
    $("#like > img").attr("src", "/icons/like no.png");
    $("#like > p").css("color", "#747A8D");
}
function LikeNone() {
    $("#like").css("cursor", "default");
    $("#like > img").attr("src", "/icons/like none.png");
    $("#like > p").css("color", "#666666");
}