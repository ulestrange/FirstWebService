
// Below gets the post on start up.
//$(document).ready(function () {
//    $.ajax({
//        url: "https://jsonplaceholder.typicode.com/Posts/6"
//    }).then(function (data) {
//        $('#postid').html(data.id);
//        $('#postcontent').html(data.body);
//    });
//});



// this function will make a get request
// based on the postid from the input element
// when it receives the JSON it is parsed automatically
// and then it is put into the relavent HTML tags.
// if there is a http error code that is handled


$("#btngetposts").click(function () {
    var postid = inputpostid.value;
    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/Posts/' + postid,
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (data) {
            $('#postid').html(data.id);
            $('#posttitle').html(data.title);
            $('#postcontent').html(data.body);
        }
    });
})