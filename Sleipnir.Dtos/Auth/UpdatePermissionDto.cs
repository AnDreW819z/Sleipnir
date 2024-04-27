using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleipnir.Dtos.Auth
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Email обязателен!")]
        public string Email { get; set; }
    }
}
