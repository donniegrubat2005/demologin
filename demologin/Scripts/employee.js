
function employeeData() {

    $(document).ready(function () {
        $("#employeeTable").DataTable({
            "iDisplayLength": 2,
            "columnDefs": [
                { "orderable": false, "targets": 5 }
            ],
            "fnDrawCallback": function () {
                if (Math.ceil((this.fnSettings().fnRecordsDisplay()) / this.fnSettings()._iDisplayLength) > 1) {

                    $('.dataTables_paginate').css("display", "block");
                    $('.dataTables_length').css("display", "block");
                    $('.dataTables_info').css("display", "block");

                } else {
                    $('.dataTables_paginate').css("display", "none");
                    $('.dataTables_length').css("display", "none");
                    $('.dataTables_info').css("display", "none");
                }
            }

        });


    });
}

$(function () {
    employeeData();

});

function Delete(id) {
    alertify.confirm("Delete", "Are you sure do you want to delete this record?", function () {
        window.location.href = '@Url.Action("Delete","Home")/' + id;

    }, null);
}


