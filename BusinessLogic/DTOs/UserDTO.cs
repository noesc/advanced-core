using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BusinessLogic.DTOs
{
    public class UserDTO
    {
        public int? userId { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
