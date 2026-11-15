using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _25DH110393_MyStore.Models
{
    public class CategoryMetadata
    {
        [HiddenInput]
        public int CatID { get; set; }

        [Required]
        [StringLength(50,MinimumLength =5)]
        public string NameCate { get; set; }
    }

    public class UserMetadata
    {
        [Required(ErrorMessage ="Username is required!!")]
        [StringLength(30,MinimumLength =5)]
        [RegularExpression("\r\n ^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$\r\n")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
    public class CustormerMetadata
    {

    }
}