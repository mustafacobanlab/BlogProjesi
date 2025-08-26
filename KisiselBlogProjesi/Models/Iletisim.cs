using System.ComponentModel.DataAnnotations;

namespace KisiselBlogProjesi.Models
{
    public class Iletisim
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad Soyad alanı en fazla 50 karakter olabilir.")]
        public String? adSoyad { get; set; }

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Mesaj alanı en fazla 1000 karakter olabilir.")]
        public String? mesaj { get; set; }
    }
}
