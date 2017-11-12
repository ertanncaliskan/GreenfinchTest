using AbstractedORMLibrary;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenfinchTest.Entity
{
    [PrimaryKey("Id")]
    public class LoginUser : BaseResultEntity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public long HeardId { get; set; }
        public string Reason { get; set; }
    }
}