using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class PersonalMenu
    {
        public bool IsLoggedIn { get; set; }
        public string Username { get; set; }
        public int CartCount { get; set; }
    }
}