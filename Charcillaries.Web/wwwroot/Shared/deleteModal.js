document.addEventListener('DOMContentLoaded', function () {
    var confirmButton = document.getElementById('confirmDelete');
    var deleteFormId = null;

    document.querySelectorAll('.delete-button').forEach(item => {
        item.addEventListener('click', event => {
            event.stopPropagation();
            event.preventDefault();


            if (event.target.tagName === 'BUTTON') {
                deleteFormId = event.target.getAttribute('data-form-id');
            } else {
                deleteFormId = event.target.parentElement.getAttribute('data-form-id');
            }
            console.log('Delete button clicked. Form ID:', deleteFormId);
        });
    });

    confirmButton.addEventListener('click', function () {
        if (deleteFormId) {
            var form = document.getElementById(deleteFormId);
            console.log('Confirm button clicked. Submitting form with ID:', deleteFormId);
            if (form) {
                form.submit();
            } else {
                console.log('No form found with ID:', deleteFormId);
            }
            deleteFormId = null;
        } else {
            console.log('No form ID set.');
        }
    });

    var exitButton = document.getElementById('btn-close');
    exitButton.addEventListener('click', function () {
        deleteFormId = null;
    });
});

