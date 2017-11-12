using AbstractedORMLibrary;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenfinchTest.Entity
{
    [PrimaryKey("Id")]
    public class HeardAbout : BaseResultEntity
    {
        public long Id { get; set; }
        public string HeardFrom { get; set; }

    }
}