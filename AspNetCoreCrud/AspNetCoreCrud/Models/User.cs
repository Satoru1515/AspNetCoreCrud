using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime birthDate { get; set; }
    }
}
