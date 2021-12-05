using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookStore
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int uId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string permission { get; set; }
    }
}
