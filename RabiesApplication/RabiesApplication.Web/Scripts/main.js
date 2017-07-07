//$(document).ready(function () {
//    ////Reference to the connection (without the generated proxy)
//    //var connection = $.hubConnection();   // same as this var conn = $.connection.hub;

//    //var hub = connection.createHubProxy("BiteUpdatesHub");


//    //hub.on("updateClients", function (bites) {
//    //    var dropdown = $("#ddUpdates");
//    //    $("#targetLink").text("Sagar");
//    //    $("#targetSpan").text("1");

//    //    for (var i = 0; i < bites.length; i++) {
//    //        console.log(bites[i]);
//    //    }
//    //});
//    //connection.start();


//    ////$("#targetLink").text("Sagar");
//    //$("#targetSpan").text("1");

//});


$(document)
        .ready(function () {
            //    //Reference the auto-generated proxy of the hub.
            var connection =  $.connection.BiteUpdatesHub;
            connection.hub.on("updateClients",
                function (bites) {
                    var dropdown = $("#ddUpdates");
                    $("#targetLink").text("Sagar");
                    $("#targetSpan").text("2");

                    for (var i = 0; i < bites.length; i++) {
                        console.log(bites[i]);
                    }
                });

            //connection.start();
        });