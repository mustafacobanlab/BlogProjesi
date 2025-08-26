document.addEventListener('DOMContentLoaded', function () {
    // Özet kısaltma veya başka JS kodları buraya
    // Örneğin: her projcard-description için maksimum 100 karakter
    document.querySelectorAll(".projcard-description").forEach(function (box) {
        if (box.innerText.length > 100) {
            box.innerText = box.innerText.substring(0, 100) + "...";
        }
    });
});
