using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Models
{
    public class ProjectDetails
    {
        public int ProjectID { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
