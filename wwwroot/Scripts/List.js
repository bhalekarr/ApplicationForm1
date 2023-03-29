$(document).ready(function () {
    table();
});

var table = $('#empTable').DataTable({
    "iDisplayLength": 100,
    "bFilter": true,
    "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        if (aData[5] == 'Female') {
            $('td', nRow).css('background-color', 'forestgreen');
        }
    }
});