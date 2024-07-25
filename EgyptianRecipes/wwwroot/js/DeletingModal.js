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