using System;
using SQLite;

namespace SLFormsApp.Models
{
    public class User
    {
        [PrimaryKey]
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
