/*

$(document).ready(function () {
    // Attach a click event handler to the "Yes" button
    $('#yesButton').on('click', function () {
        // Redirect to the desired URL
        window.location.href = redirectUrl;
        Session.Clear();
    });
});
*/

$(document).ready(function () {
    $('#yesButton').on('click', function () {
        // Make an AJAX request
        $.ajax({
            url: redirectUrl,
            method: 'POST', 
            success: function (response) {      
                $.ajax({
                    url: '/Dashboard/ClearSession',
                    method: 'POST', 
                    success: function () {
                        window.location.href = redirectUrl;
                    },
                    error: function (xhr, status, error) {
                        console.error('Failed to clear session:', error);
                    }
                });
            },
            error: function (xhr, status, error) {
                console.error('AJAX request failed:', error);
            }
        });
    });
});
