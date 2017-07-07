$(document)
    .ready(function () {
        var connection = $.connection.biteupdateshub;

        connection.client.updateClients = function (bite) {
            //$("#targetSpan").text(bites.length);

            //toastr.info('New Bite added <a href="/Details?biteId=2300378d-f936-4484-8d5b-d03452df64a9"> </a>');
            toastr["success"]("New  <a href='/bites/Details?biteId="+bite.Id+"'>" + "Bite added</a>");
        }
        $.connection.hub.start();
    });

