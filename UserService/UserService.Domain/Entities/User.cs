using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Entities
{
    [Table("UserEntity")]
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

    
        public bool IsAdmin { get; set; } = false;
    }
}
