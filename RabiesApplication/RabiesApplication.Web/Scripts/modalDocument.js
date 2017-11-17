//data-toggle="modal" data-target="#exampleModal"

$("#btnschedular")
    .click(function () {
        $("#datepicker").datepicker();
        $("#schedular").modal("toggle");
    });


$("#datepicker")
    .change(function() {
        $("#num").val(null);
        $("#calculatedDate").html(null);
    });

$("#num")
    .change(function () {
        //$("#calculatedDate").html($(this).val() + ' ' + $("#numtype").val());
        calculateDate();
    });

$("#numtype")
    .change(function () {
        //$("#calculatedDate").html($("#num").val() + ' ' + $(this).val());
        calculateDate();
    });



function calculateDate() {
    $("#datepicker").val(null);
    // 12-20-2017
    var biteDate = $("#Bite_BiteDate").val();
    //Need to manupulate date to 2017-12-20
    var manupulated = biteDate.substr(6, 9) + "-" + biteDate.substr(0, 5);


    biteDate = moment(manupulated);

    var num = $("#num").val();
    var numType = $("#numtype").val();
    var computed = biteDate.add(num, numType);
    //console.log(computed.format());
    $("#calculatedDate").html(computed.format("ddd MM-DD-YYYY"));

}

//num
//numtype
//calculatedDate


$("#reminderSave")
    .click(function() {

        var investigation = {
            BiteId: $("#hdnBiteId").val(),
            QuarantineLetterSent: $("#comments").val(),
            LetterSentDate: moment.now(),
            FollowUpDays : 0,
            ReminderDate: $("#calculatedDate").html()
        };

        console.log(investigation);

        $.ajax({
            url: '/Bites/SaveReminder',
            method: "post",
            data: investigation
        })


    });