$(document).ready(function () {
    $("#nameEditor").change(tryToSendDataOnServer);
    $("#emailEditor").change(tryToSendDataOnServer);
    $("#skypeEditor").change(tryToSendDataOnServer);
    $("#noteEditor").change(tryToSendDataOnServer);
    $("#avatarLoader").change(tryToSendDataOnServer);
});

function tryToSendDataOnServer() {

    var form = $(".createEditForm"),
        idHolder = $("#idHolder"),
        nameEditor = $("#nameEditor"),
        emailEditor = $("#emailEditor"),
        skypeEditor = $("#skypeEditor"),
        noteEditor = $("#noteEditor"),
        avatarLoader = $("#avatarLoader"),
        avatar = $("#avatar");


    var formData = new FormData();
    formData.append('Id', idHolder[0].value);
    formData.append('Name', nameEditor[0].value);
    formData.append('Email', emailEditor[0].value);
    formData.append('SkypeLogin', skypeEditor[0].value);
    formData.append('Note', noteEditor[0].value);
    if (avatar.length) {
        var fileName = avatar.attr("src").substring(16);
        formData.append('FilePath', fileName);
    }
    formData.append('file', avatarLoader[0].files[0]);

    if (avatarLoader[0].files.length > 0) {
        formData.append('file', avatarLoader[0].files[0]);
    }

    var route = GetRoute(idHolder[0].value);
    if (!form.valid()) {
        return false;
    }
    $.ajax({
        url: route,
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        dataType: "json",
        success: saveHandler
    });
}

function GetRoute(value) {
    var route = null;
    if (value === "0") {
        route = "/User/Create/";
    }
    else {
        route = "/User/Edit/" + value;
    }
    return route;
}

function saveHandler(data) {
    if (data.HasSaved) {
        alert(data.Message);
        var idHolder = $("#idHolder");
        idHolder[0].value = data.Id;
        return false;
    }
}