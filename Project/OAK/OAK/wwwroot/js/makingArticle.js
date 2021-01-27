function makeIcon(style, path, title) {
    var icon = document.createElement('img');
    icon.className = style;
    icon.src = path;
    icon.title = title;
    return icon;
}

function buttomAddText(number) {
    var buttom = makeIcon("edit_article_bottons", "/icons/text.png", "Добавить поле ввода текста");
    buttom.id = number;
    buttom.onclick = function () { return addFieldText(buttom.id) };
    return buttom;
}

function buttomAddSubtitle(number) {
    var buttom = makeIcon("edit_article_bottons", "/icons/title.png", "Добавить поле ввода подзаголовока");
    buttom.id = number;
    buttom.onclick = function () { return addFieldSubtitle(buttom.id) };
    return buttom;
}

function buttomAddImage(number) {
    var buttom = makeIcon("edit_article_bottons", "/icons/image.png", "Добавить поле загрузки изображения");
    buttom.id = number;
    buttom.onclick = function () { return addFieldImage(buttom.id) };
    return buttom;
}


//t - textarea
function fieldText(number) {
    var field = document.createElement('textarea');
    field.id = "text" + number;
    field.name = "text" + number;
    field.className = "edit_article_textarea";
    return field;
}

//s - input
function fieldSubtitle(number) {
    var field = document.createElement('input');
    field.type = "text";
    field.id = "sub" + number;
    field.name = "sub" + number;
    field.className = "edit_article_subtitle_field";
    return field;
}

//f - input; p - preview
function fieldImage(number) {

    var container = document.createElement('div');
    container.className = "edit_article_img_cont";

    var preview = document.createElement('img');
    preview.className = "edit_article_img_prev";
    preview.id = "preview" + number;
    preview.src = "";
    preview.onclick = function () { field.click(); }

    var field = document.createElement('input');
    field.type = "file";
    field.multiple = "image/*";
    field.accept = "image/*";
    field.id = "img" + number;
    field.name = "img" + number;
    field.className = "edit_article_img_down";
    field.style = "opacity: 0;";
    field.addEventListener("change",
        function () {
            var reader = new FileReader();
            reader.readAsDataURL(field.files[0]);
            reader.onload = function (e) {
                preview.src = e.target.result;
            }
        }
    );

    var drop = makeIcon("edit_article_drop_img", "/icons/plus.png", "Сброс изображения");
    drop.onclick = function () {
        preview.src = "";
        field.value = "";
    }

    var download = makeIcon("edit_article_img_down_icon", "/icons/image.png", "Загрузить изображение");
    download.onclick = function () { field.click(); }

    container.appendChild(drop);
    container.appendChild(preview);
    container.appendChild(download);
    container.appendChild(field);

    return container;
}



function makeContainer(style, number, icon, field, buttoms) {
    var container = document.createElement('div');
    container.className = style;
    container.id = "c" + number;
    container.appendChild(icon);
    container.appendChild(field);
    container.appendChild(buttoms);

    var fields = document.getElementById("fields");
    fields.appendChild(container);
}

function makeContainerText(number) {

    var icon = makeIcon("edit_article_bottons edit_article_icon", "/icons/text.png", "Текст");

    var field = fieldText(number);

    var buttoms = document.createElement('div');
    buttoms.id = "b" + number;
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddSubtitle(number));

    makeContainer("edit_artcle_text", number, icon, field, buttoms);
}

function makeContainerSubtitle(number) {

    var icon = makeIcon("edit_article_bottons edit_article_icon", "/icons/title.png", "Подзаголовок");

    var field = fieldSubtitle(number);

    var buttoms = document.createElement('div');
    buttoms.id = "b" + number;
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddText(number));

    makeContainer("edit_artcle_subtitle", number, icon, field, buttoms);
}

function makeContainerImage(number) {

    var icon = makeIcon("edit_article_bottons edit_article_icon", "/icons/image.png", "Изображение");

    var field = fieldImage(number);

    var buttoms = document.createElement('div');
    buttoms.id = "b" + number;
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddText(number));
    buttoms.appendChild(buttomAddSubtitle(number));

    makeContainer("edit_article_img", number, icon, field, buttoms);
}



function remove(number) {
    var container = document.getElementById("c" + number);
    var buttoms = document.getElementById("b" + number);
    container.removeChild(buttoms);
}



function addFieldText(id) {

    makeContainerText(1 + Number(id));
    remove(id);
}

function addFieldSubtitle(id) {

    makeContainerSubtitle(1 + Number(id));
    remove(id);
}

function addFieldImage(id) {

    makeContainerImage(1 + Number(id));
    remove(id);
}



function setField(id, value) {
    var field = document.getElementById(id);
    field.value = value;
}

function setImage(id, src) {
    var image = document.getElementById(id);
    image.src = src;
}