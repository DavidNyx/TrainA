using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainA.Models
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        [MaxLength(30)]
        public string password { get; set; }
    }
}
