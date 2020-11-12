console.log("home.js initialized.")

var apihost = $('#apihost').val()
//Submit disabled by default
$("#submit").attr("disabled", true);

//Event onchange mandatory fields
$("#serial").change(function () { validateChange() });
$("#ip").change(function () { validateChange() });

function validateChange() {

    if ($("#serial").val().trim() != "" && $("#ip").val().trim() != "") {
        $('#submit').attr("disabled", false);
        console.log("submit button enabled.")
    }
    else {
        $("#submit").attr("disabled", true);
        console.log("submit button disabled.");
    }
}

//Event onclick submit button
$("#submit").click(function () {
    console.log("Check data input before call api.");

    if ($("#serial").val().trim() != "" && $("#ip").val().trim() != "") {

        console.log("Data input valid. data: " + data);
        
        var data = JSON.stringify({ Serial: $("#serial").val().trim(), Brand: $("#brand").val().trim(), Model: $("#model").val().trim(), Ip: $("#ip").val().trim(), Port: $("#port").val().trim() });

        //Call api method to insert the new counter.
        $.ajax({
            url: apihost + "/Insert/Gateway",
            type: 'POST',
            async: true,
            cache: false,
            crossDomain: true,
            contentType: 'application/json; charset=utf-8',
            data: data,
            timeout: 100000,
            success: function (response) {
                alert(response);
            },
            error: function (response) {

                alert(response);
            }
        });

        $("#serial").val("");
        $("#brand").val("");
        $("#model").val("");
        $("#ip").val("");
        $("#port").val("");
        $('#submit').attr("disabled", true);
    }
    else {
        console.log("Data input invalid.");
    }
});