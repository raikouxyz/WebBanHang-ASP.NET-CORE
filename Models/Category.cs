using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(255, ErrorMessage = "Ký tự không quá 255")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Ký tự không quá 1000")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } // quan hệ 1 - n giữa danh mục và sản phẩm
    }
}
