using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DougHomework2.Models
{
    public class Douglas
    {
        public int DouglasId { get; set; }
        public int DougLevel { get; set; }
        public string DougMasteries { get; set; }
        public string Name { get; set; }

        public Doug Doug { get; set; }
        public int DougId { get; set; }
    }
}