function News(flag) {
    if (flag) {
        $("#news > img").attr("src", "/icons/oak sort yes.png")
        $("#news > span").css("color", "#FF0000")
    } else {
        $("#news > img").attr("src", "/icons/oak sort.png")
        $("#news > span").css("color", "#747A8D")
    }
}

function Popular(flag) {
    if (flag) {
        $("#popular > img").attr("src", "/icons/like yes.png")
        $("#popular > span").css("color", "#FF0000")
    } else {
        $("#popular > img").attr("src", "/icons/like no.png")
        $("#popular > span").css("color", "#747A8D")
    }
}

function Watched(flag) {
    if (flag) {
        $("#watched > img").attr("src", "/icons/views yes.png")
        $("#watched > span").css("color", "#FF0000")
    } else {
        $("#watched > img").attr("src", "/icons/views.png")
        $("#watched > span").css("color", "#747A8D")
    }
}