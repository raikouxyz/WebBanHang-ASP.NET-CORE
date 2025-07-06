using System;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public enum UserRole
    {
        User,
        Admin
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Mã hóa mật khẩu

        [Required]
        public UserRole Role { get; set; } = UserRole.User;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
