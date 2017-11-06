//data-toggle="modal" data-target="#exampleModal"

$("[type = 'button']").on("click", function () {
    debugger;
    var self = this;

    $.ajax({
        url: "/Bites/GetPath?documentId=" + self.id,
        success: function (data) {
//            $("#docFrame").src = 'http://www.axmag.com/download/pdfurl-guide.pdf';
            $("#exampleModal").modal('show');
            //console.log(data);
        }
    });

});
