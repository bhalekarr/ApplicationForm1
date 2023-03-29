$(document).ready(function () {
    $('#CountryId').attr('disabled', true);
    $('#StateId').attr('disabled', true);

    loadCountries();
    //loadStates();

    $('#CountryId').change(function () {
        var countryId = $(this).val();
        if (countryId > 0) {
            loadStates(countryId);
        }
        else {
            alert("Select Country");
            $('#StateId').empty();
            $('#StateId').attr('disabled', true);
            $('#StateId').append('<option>Select State</option>');
        }
    });    
});

function loadCountries() {
    $('#CountryId').empty();
    $.ajax({
        url: '/Home/GetCountry',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#CountryId').attr('disabled', false);
                $('#CountryId').append('<option>Select Country</option>');
                $('#StateId').append('<option>Select State</option>');
                $.each(response, function (i, data) {
                    $('#CountryId').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
                //alert(data.id);
            }
            else {
                $('#CountryId').attr('disabled', true);
                $('#StateId').attr('disabled', true);
                $('#CountryId').append('<option>Countries are not available</option>');
                $('#StateId').append('<option>States are not available</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

function loadStates(countryId) {
    $('#StateId').empty();
    $.ajax({
        url: '/Home/GetState?CountryId=' + countryId,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#StateId').attr('disabled', false);
                $('#StateId').append('<option>Select State</option>');
                $.each(response, function (i, data) {
                    $('#StateId').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
            else {
                $('#StateId').attr('disabled', true);
                $('#StateId').append('<option>States are not available</option>');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}

    