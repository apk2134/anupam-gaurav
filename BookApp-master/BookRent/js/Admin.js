function getBookScreen() {
    var id = 999;
    debugger;
    $.ajax({
        type: 'Get',
        url: "../Books/GetBookScreen",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });

}

function getcoustomersubscription() {
    
    debugger;
    $.ajax({
        type: 'Get',
        url: "../CoustomerSubscriptions/Index",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });

}
function getcoustomerorder()
{
    debugger;
    $.ajax({
        type: 'Get',
        url: "../CoustomerOrders/Index",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });
}

function getuserpage() {
    
    debugger;
    $.ajax({
        type: 'Get',
        url: "../CoustomerDetails/Index",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });

}

function getUpdateDeleteBookScreen() {
    $.ajax({
        type: 'Get',
        url: "../Books/UpdateBook",
        success: function (data) {
            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    })
}

function getBookMenu()
{
    debugger;
    $.ajax({
        type: 'Get',
        url: "../Books/GetBookMenu",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });

}
function uploadBookImage()
{
    var id = 888;
    debugger;
    $.ajax({
        type: 'Get',
        url: "../Books/UploadBookImage",
        success: function (data) {
            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error');}
    });
}



function AddAuthor() {
    var id = 998;
    debugger;
    $.ajax({
        type: 'Get',
        url: "../Books/AddAuthor",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });
}
function AddCategory() {
    var id = 996;
    debugger;
    $.ajax({
        type: 'Get',
        url: "../Books/AddCategory",
        success: function (data) {

            $("#AdminConfig").html(data);
        },
        failure: function () { alert('failure'); },
        error: function (data) { alert('error'); }
    });
}