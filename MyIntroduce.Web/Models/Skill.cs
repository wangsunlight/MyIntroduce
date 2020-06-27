using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Models
{
    /// <summary>
    /// 专业技能
    /// </summary>
    public class Skill
    {
        public int UserID { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
