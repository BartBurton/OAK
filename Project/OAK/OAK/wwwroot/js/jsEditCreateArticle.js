function makeIcon(style, path, title) {
    var icon = document.createElement('img');
    icon.className = style;
    icon.src = path;
    icon.title = title;
    return icon;
}


function buttomAddText(number) {
    var buttom = makeIcon("edit_article_buttoms", "/icons/text.png", "Добавить поле ввода текста");
    buttom.id = number;
    buttom.onclick = function () { return addFieldText(buttom.id) };
    return buttom;
}

function buttomAddSubtitle(number) {
    var buttom = makeIcon("edit_article_buttoms", "/icons/title.png", "Добавить поле ввода подзаголовока");
    buttom.id = number;
    buttom.onclick = function () { return addFieldSubtitle(buttom.id) };
    return buttom;
}

function buttomAddImage(number) {
    var buttom = makeIcon("edit_article_buttoms", "/icons/image.png", "Добавить поле загрузки изображения");
    buttom.id = number;
    buttom.onclick = function () { return addFieldImage(buttom.id) };
    return buttom;
}

function makeButtoms(number) {
    var buttoms = document.createElement('div');
    buttoms.className = "edit_article_buttoms_cont";
    buttoms.id = "b" + number;

    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddText(number));
    buttoms.appendChild(buttomAddSubtitle(number));
    return buttoms;
}

function removeButtoms(number) {
    var buttoms = document.getElementById("b" + number);
    buttoms.parentElement.removeChild(buttoms);
}


function makeContainer(style, number, icon, field) {
    var container = document.createElement('div');
    container.className = style;
    container.id = "c" + number;

    var drop = makeIcon("edit_article_drop", "/icons/plus.png", "Сброс поля");
    drop.onclick = function () {
        container.parentNode.removeChild(container);
    }

    container.appendChild(drop);
    container.appendChild(icon);
    container.appendChild(field);
    return container;
}


function addField(container, number) {
    var buttoms = makeButtoms(number);
    removeButtoms(Number(number) - 1);

    var fields = document.getElementById("fields");
    fields.appendChild(container);
    fields.appendChild(buttoms);
}


//t - textarea
function fieldText(number) {
    var field = document.createElement('textarea');
    field.id = "text" + number;
    field.name = "text" + number;
    field.className = "edit_article_textarea";
    return field;
}

function addFieldText(id) {
    var number = Number(id) + 1;

    var icon = makeIcon("edit_article_icon", "/icons/text.png", "Текст");
    var field = fieldText(number);
    var container = makeContainer("edit_artcle_text", number, icon, field);

    addField(container, number);
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

function addFieldSubtitle(id) {
    var number = Number(id) + 1;

    var icon = makeIcon("edit_article_icon", "/icons/title.png", "Подзаголовок");
    var field = fieldSubtitle(number);
    var container = makeContainer("edit_artcle_subtitle", number, icon, field);

    addField(container, number);
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

    var download = makeIcon("edit_article_img_down_icon", "/icons/image.png", "Загрузить изображение");
    download.onclick = function () { field.click(); }

    container.appendChild(preview);
    container.appendChild(download);
    container.appendChild(field);

    return container;
}

function addFieldImage(id) {
    var number = Number(id) + 1;

    var icon = makeIcon("edit_article_icon", "/icons/image.png", "Изображение");
    var field = fieldImage(number);
    var container = makeContainer("edit_article_img", number, icon, field);

    addField(container, number);
}



function toSetDrop(dropId, deletedId) {
    var drop = document.getElementById(dropId);
    var deleted = document.getElementById(deletedId);

    drop.onclick = function () {
        deleted.parentNode.removeChild(deleted);
    }
}

function toSetInput(inputId, previewId, downloadId) {

    var input = document.getElementById(inputId);
    var preview = document.getElementById(previewId);
    var download = document.getElementById(downloadId);

    preview.onclick = function () {
        input.click();
    }
    download.onclick = function () {
        input.click();
    }

    input.addEventListener("change",
        function () {
            var reader = new FileReader();
            reader.readAsDataURL(input.files[0]);
            reader.onload = function (e) {
                preview.src = e.target.result;
            }
        }
    );
}