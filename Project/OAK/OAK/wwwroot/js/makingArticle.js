function makeIcon(style, path, title) {
    var icon = document.createElement('img');
    icon.className = style;
    icon.src = path;
    icon.title = title;
    return icon;
}

function buttomAddText(number) {
    var buttom = makeIcon("edit_article_bottons", "~/icons/text.png", "Добавить поле ввода текста");
    buttom.id = number;
    buttom.onclick = function () { return addFieldText(buttom) };
    return buttom;
}

function buttomAddSubtitle(number) {
    var buttom = makeIcon("edit_article_bottons", "~/icons/title.png", "Добавить поле ввода подзаголовока");
    buttom.id = num;
    buttom.onclick = function () { return addFieldSubtitle(buttom) };
    return buttom;
}

function buttomAddImage(number) {
    var buttom = makeIcon("edit_article_bottons", "~/icons/image.png", "Добавить поле загрузки изображения");
    buttom.id = number;
    buttom.onclick = function () { return addFieldImage(buttom) };
    return buttom;
}



function fieldText(number) {
    var field = document.createElement('textarea');
    field.name = "t" + number;
    field.className = "edit_article_textarea";
    return field;
}

function fieldSubtitle(number) {
    var field = document.createElement('input');
    field.type = "text";
    field.name = "s" + number;
    field.className = "edit_article_subtitle_field";
    return field;
}

function fieldImage(number) {

    var container = document.createElement('div');
    container.className = "edit_article_img_cont";

    var preview = document.createElement('img');
    preview.className = "edit_article_img_prev";
    preview.src = "";
    preview.onclick = function () { input.click(); }

    var input = document.createElement('input');
    input.type = "file";
    input.multiple = "image/*";
    input.accept = "image/*";
    input.name = "f" + number;
    input.className = "edit_article_img_down";
    input.style = "opacity: 0;";
    input.addEventListener("change",
        function () {
            var reader = new FileReader();
            reader.readAsDataURL(input.files[0]);
            reader.onload = function (e) {
                preview.src = e.target.result;
            }
        }
    );

    var drop = makeIcon("edit_article_drop_img", "~/icons/+.png", "Сброс изображения");
    drop.onclick = function () {
        preview.src = "";
        input.value = "";
    }

    var download = makeIcon("edit_article_img_down_icon", "~/icons/image.png", "Загрузить изображение");
    download.onclick = function () {
        inputImg.click();
    }

    container.appendChild(drop);
    container.appendChild(preview);
    container.appendChild(download);
    container.appendChild(input);
}



//Добавление текста/////////////
function addFieldText(c) {

    var number = 1 + Number(c.id);

    var icon = makeIcon("edit_article_bottons edit_article_icon", "~/icons/text.png", "Текст");

    var field = fieldText(number);

    var buttoms = document.createElement('div');
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddSubtitle(number));

    var container = document.createElement('div');
    container.className = "edit_artcle_text";
    container.appendChild(icon);
    container.appendChild(field);
    container.appendChild(buttoms);

    var form = c.parentNode.parentNode.parentNode;
    form.appendChild(container);


    c.parentNode.parentNode.removeChild(c.parentNode);
}

//Добавление подзаголовка/////////////
function addFieldSubtitle(c) {

    var number = 1 + Number(c.id);

    var icon = makeIcon("edit_article_bottons edit_article_icon", "~/icons/title.png", "Подзаголовок");

    var field = fieldSubtitle(number);

    var buttoms = document.createElement('div');
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddText(number));

    var container = document.createElement('div');
    container.className = "edit_artcle_subtitle";
    container.appendChild(icon);
    container.appendChild(field);
    container.appendChild(buttoms);

    var form = c.parentNode.parentNode.parentNode;
    form.appendChild(container);


    c.parentNode.parentNode.removeChild(c.parentNode);
}

//Добавление изображения/////////////
function addFieldImage(c) {

    var number = 1 + Number(c.id);

    var icon = makeIcon("edit_article_bottons edit_article_icon", "~/icons/image.png", "Изображение");

    var field = fieldImage(number);

    var buttoms = document.createElement('div');
    buttoms.appendChild(buttomAddImage(number));
    buttoms.appendChild(buttomAddText(number));
    buttoms.appendChild(buttomAddSubtitle(number));

    var container = document.createElement('div');
    container.className = "edit_article_img";
    container.appendChild(icon);
    container.appendChild(field);
    container.appendChild(buttoms);

    var form = c.parentNode.parentNode.parentNode;
    form.appendChild(container);


    c.parentNode.parentNode.removeChild(c.parentNode);
}