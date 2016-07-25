$(document).on("ready", function () {
    GetAll();
})
 
//Get all personas
function GetAll() {
    var item = "";
    $('#tblList tbody').html('');
    $.getJSON('/api/persona', function (data) {
        $.each(data, function (key, value) {
            console.log(value);
            item += "<tr> <td>" + value.nombre + "</td><td> " + value.ApPaterno + "</td><td>  " + value.Twitter + "</td> </tr>";
        });
        $('#tblList tbody').append(item);
    });
};
function GetPersonaById(idPersona) {

    var url = '/api/persona/' + idPersona;
    $.getJSON(url)
        .done(function (data) {
            $('#txtName').val(data.nombre);
            $('#txtLastName').val(data.ApPaterno);
            $('#txtTwitter').val(data.Twitter);
        })
        .fail(function (erro) {
            alert("error "+erro)
            //ClearForm();
        });
};
$('#btnSearch').on('click', function () {
    GetPersonaById($('#txtIdSearch').val());
})

// Delete persona
function DeletePersonaById(idPersona) {
    var url = '/api/persona/' + idPersona;
    $.ajax({
        url: url,
        type: 'DELETE',
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
               // ClearForm();
                alert('Persona with id: ' + idPersona + ' was deleted');
            },
            404: function () {
                alert('Persona with id: ' + idPersona + ' was not found');
            }
        }
    });
}
$('#btnDelete').on('click', function () {
    DeletePersonaById($('#txtIdSearch').val());
})
function UpdatePersona(idPersona, persona) {
    var url = '/api/persona/' + idPersona;
    $.ajax({
        url: url,
        type: 'PUT',
        data: persona,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Persona with id: ' + idPersona + ' was updated');
            },
            404: function () {
                ClearForm();
                alert('Persona with id: ' + idPersona + ' was not found');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}
$('#btnUpdate').on('click', function () {
    var persona = new Object();
    persona.id = $('#txtIdSearch').val();
    persona.nombre = $('#txtName').val();
    persona.appaterno = $('#txtLastName').val();
    persona.twitter = $('#txtTwitter').val();
    UpdatePersona(persona.id, JSON.stringify(persona));
})

function CreatePersona(persona) {
    var url = '/api/persona/';
    $.ajax({
        url: url,
        type: 'POST',
        data: persona,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Persona with id: ' + idPersona + ' was updated');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

$('#btnCreate').on('click', function () {
    var persona = new Object();
    persona.nombre = $('#txtName').val();
    persona.appaterno = $('#txtLastName').val();
    persona.twitter = $('#txtTwitter').val();
    CreatePersona(JSON.stringify(persona));
})