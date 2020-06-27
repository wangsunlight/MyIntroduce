using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Models
{
    /// <summary>
    /// 项目经验
    /// </summary>
    public class Project
    {
        public int ProjectID { get; set; }

        public int UserID { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public List<ProjectDetails> ProjectDetails { get; set; }
    }
}
