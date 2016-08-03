$(document).ready(function () {
    $("a.delete").bind("click", OnUserDeleteClick);
});

function OnUserDeleteClick(eventData) {
    var userId = eventData.target.id;
    var userName = $("#" + userId + "userName");
    var message = "Do you want to delete " + userName[0].innerText + "?";

    var confirmResult = confirm(message);
    if (confirmResult) {
        $.post("/User/Delete", { id: userId })
        .done(handleUserDelete);
    }
    return false;
}

function handleUserDelete(data, status, xhr) {
    if (data.HasDeleted) {
        alert(data.Message);
        var userName = $("#" + data.Id + "userName");
        userName.parent().parent().remove();
        //window.location.pathname = "/User/Index";
    }
}