using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DougHomework2.Models
{
    public class Doug
    {
        public int DougId { get; set; }
        public string Name { get; set; }

        public List<Douglas> Douglas { get; set; }
    }
}