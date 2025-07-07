using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebBanHang.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(5000, ErrorMessage = "Mô tả tối đa 5000 ký tự")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 100000000, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0 và nhỏ hơn 100 củ")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(0, 1000, ErrorMessage = "Số lượng phải lớn hơn 0 và nhỏ hơn 1000")]
        public int Quantity { get; set; }


        [StringLength(255)]
        public string ImageUrl { get; set; }


        [Required]
        public bool IsActive { get; set; } = true; // trạng thái hiển thị mặc định là true


        [DataType(DataType.DateTime)] // kiểu dữ liệu datetime
        public DateTime CreatedAt { get; set; } = DateTime.Now; // thời gian thêm sản phẩm mặc định là hiện tại


        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }


        // Liên kết với danh mục
        [ForeignKey("Category")] // khóa ngoại danh mục
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } // navigation property, giúp truy cập đối tượng danh mục liên quan, virtual hỗ trợ lazy loading
    }
}
