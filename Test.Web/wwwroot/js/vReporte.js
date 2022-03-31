$(document).ready(function () {
    var fileExportOptions = {
        exportOptions: {
            columns: [1, 2, 3, 4],
            format: {
                body: function (data, row, column, node) {
                    return data;
                }
            }
        }
    }

    $('#datatables').DataTable({
        pageLength: 20,
        dom: 'Bfrtip',
        buttons: [
            $.extend(true, {}, fileExportOptions, { extend: 'excelHtml5' }),
        ],
        order: [[2, "asc"]],
        responsive: true,
        scrollX: true
    });
});