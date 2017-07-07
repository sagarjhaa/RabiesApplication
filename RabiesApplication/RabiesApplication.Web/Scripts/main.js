"use strict";

$(document)
    .ready(function() {
        updateCount();
    });

function updateCount() {
    var connection = $.connection.biteupdateshub;

    connection.client.updateClients = function (bites) {

        toastr["success"]("New  <a href='/bites/Details?biteId=" + 1 + "'>" + "Bite added</a>");
        $("#targetSpan").html(bites.length);

        

        for (var i = 0; i < bites.length; i++) {
            var link = "<li><a href='/bites/Details?biteId=" + bites[i].Id + "'>" + bites[i].City.CityName +"</a></li>";
            $("#linkDropDown").append(link);
        }
    }

    $.connection.hub.start().done(function() {
        connection.server.notifyUpdates();
    });
}
