function saveAndDownloadPDF(fileDownloadUrl) {
    // Send an AJAX request to the server to trigger the PDF generation and save
    $.ajax({
        url: fileDownloadUrl,
        type: 'POST',
        success: function (data) {
            // Open the generated PDF in a new browser tab for download
            window.open(data);
        }
    });
}