
    window.addEventListener('DOMContentLoaded', function () {
        const form = document.querySelector('.login-form');
    if (form) {
        form.addEventListener('submit', function (e) {
            e.preventDefault();
            document.getElementById('plane-spinner').style.display = 'flex';
            setTimeout(function () {
                form.submit();
            }, 1500);
        });
        }
    });

