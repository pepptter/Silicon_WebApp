document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload();
    setupFormValidation();
});

function handleProfileImageUpload() {
    let fileUploader = document.querySelector('#fileUploader');
    if (fileUploader) {
        fileUploader.addEventListener('change', function () {
            if (this.files.length > 0) {
                this.form.submit();
            }
        });
    }
}

function setupFormValidation() {
    const signupForm = document.getElementById('signupForm');
    if (signupForm) {
        signupForm.addEventListener('submit', function (event) {
            if (!validateForm()) {
                event.preventDefault(); // Prevent form from submitting if validation fails
            }
        });
    }
}

function validateForm() {
    let isValid = true;
    const firstName = document.querySelector('#form-firstname input');
    const lastName = document.querySelector('#form-lastname input');
    const email = document.querySelector('#form-email input');
    const password = document.querySelector('#form-password input');
    const confirmPassword = document.querySelector('#form-confirmpassword input');
    const termsAccepted = document.querySelector('#form-checkbox input[type="checkbox"]');

    // Clear previous errors
    clearError(firstName);
    clearError(lastName);
    clearError(email);
    clearError(password);
    clearError(confirmPassword);

    if (!firstName.value.trim()) {
        showError(firstName, 'First name is required.');
        isValid = false;
    }

    if (!lastName.value.trim()) {
        showError(lastName, 'Last name is required.');
        isValid = false;
    }

    if (!email.value.trim().match(/^[^\s@]+@[^\s@]+\.[^\s@]+$/)) {
        showError(email, 'Please enter a valid email address.');
        isValid = false;
    }

    if (password.value.length < 8) {
        showError(password, 'Password must be at least 8 characters long.');
        isValid = false;
    }

    if (!password.value.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).*/)) {
        showError(password, 'Password must include at least one number, one uppercase letter, one lowercase letter, and one special character.');
        isValid = false;
    }

    if (password.value !== confirmPassword.value) {
        showError(confirmPassword, 'Passwords do not match.');
        isValid = false;
    }

    if (!termsAccepted.checked) {
        showError(termsAccepted, 'You must accept the terms and conditions.');
        isValid = false;
    }

    return isValid;
}


function showError(element, message) {
    const container = element.parentElement;
    const errorSpan = container.querySelector('.text-danger');
    if (errorSpan) {
        errorSpan.textContent = message;
    }
    element.classList.add('is-invalid');
}

function clearError(element) {
    const container = element.parentElement;
    const errorSpan = container.querySelector('.text-danger');
    if (errorSpan) {
        errorSpan.textContent = '';
    }
    element.classList.remove('is-invalid');
}
