$(document)
    .ready(function () {
        var connection = $.connection.biteupdateshub;

        connection.client.updateClients = function (bites) {
            $("#targetSpan").text(bites.length);

            toastr.info('Are you the 6 fingered man?');

        }
        $.connection.hub.start();
    });

