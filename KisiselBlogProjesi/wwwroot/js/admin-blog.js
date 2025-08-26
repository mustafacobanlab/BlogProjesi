document.addEventListener('DOMContentLoaded', function () {
    // Sil butonuna tıklanınca confirm
    document.querySelectorAll('.delete-btn').forEach(function (btn) {
        btn.addEventListener('click', function (e) {
            if (!confirm('Bu blogu silmek istediğinize emin misiniz?')) {
                e.preventDefault();
            }
        });
    });
});
