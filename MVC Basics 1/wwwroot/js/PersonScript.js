function getAllPeople() {
    $.get("/PersonAjax/GetPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}
function getPersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    $.post("/PersonAjax/FindPersonById", { personID: personIDValue }, function (data) {
        $("#PersonList").html(data);
    });
}
function deletePersonByID() {
    var personIDValue = document.getElementById("PersonIdInput").value;
    $.post("/PersonAjax/DeletePersonById", { personID: personIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Successfully Deleted person.";
            getAllPeople();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could not delete person.";
        });
}