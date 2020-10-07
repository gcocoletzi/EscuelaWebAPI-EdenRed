using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace DataAccess.Model
{
    public class Major
    {
        public long Id { get; set; }
        public string MajorName { get; set; }
    }
}
