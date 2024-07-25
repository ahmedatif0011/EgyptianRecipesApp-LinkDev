// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', (event) => {
    var deleteButtons = document.querySelectorAll('button[data-bs-toggle="modal"][data-bs-target="#DeletingModal"]');
    deleteButtons.forEach(button => {
        button.addEventListener('click', function () {
            var branchId = this.getAttribute('data-id');
            var branchTitle = this.getAttribute('data-title'); // Add a data-title attribute to the button if needed

            // Set the ID in the modal
            var confirmDeleteBtn = document.getElementById('confirmDeleteBtn');
            confirmDeleteBtn.href = `/Branches/DeleteBranch/${branchId}`;

            // Optionally set the title in the modal
            document.getElementById('branchTitle').textContent = branchTitle;
            document.getElementById('branchTitleBody').textContent = branchTitle;
        });
    });
});
function Search(pageNumber) {
    var searchCriteria = $('#searchCriteria').val();

    $.ajax({
        url: 'TablePartial',
        type: 'GET',
        data: { pageNumber: pageNumber, searchCriteria: searchCriteria },
        success: function (response) {
            $('#results').html(response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', status, error);
        }
    });
}