using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Models
{
    /// <summary>
    /// 个人简介
    /// </summary>
    public class Introduce
    {
        public int UserID { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
