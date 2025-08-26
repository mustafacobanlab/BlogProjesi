using System.ComponentModel.DataAnnotations;

namespace KisiselBlogProjesi.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public String? title { get; set; }

        public String? photoUrl { get; set; }

        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        public String? content { get; set; }


        [Required(ErrorMessage = "Özet alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Özet en fazla 100 karakter olabilir.")]
        public String? summary { get; set; }

        public DateTime? date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Yazar Adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Başlık en fazla 50 karakter olabilir.")]
        public String? authorId { get; set; }





    }
 }
