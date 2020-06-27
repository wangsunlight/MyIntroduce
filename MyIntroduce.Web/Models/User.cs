using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Models
{
    public class User
    {
        public User()
        {
            Introduces = new List<Introduce>();
            Projects = new List<Project>();
            Skills = new List<Skill>();
            Summarys = new List<Summary>();
        }

        public int UserId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(100)]
        public string Url { get; set; }

        /// <summary>
        /// 座右铭
        /// </summary>
        [StringLength(100)]
        public string Motto { get; set; }

        /// <summary>
        /// 博客地址
        /// </summary>
        [StringLength(100)]
        public string CnblogsUrl { get; set; }

        /// <summary>
        /// Github地址
        /// </summary>
        [StringLength(100)]
        public string GithubUrl { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// 网站Title
        /// </summary>
        [StringLength(100)]
        public string WebTitle { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [StringLength(100)]
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [StringLength(100)]
        public string Wchar { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(100)]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 个人简历
        /// </summary>
        public List<Introduce> Introduces { get; set; }


        /// <summary>
        /// 项目经验
        /// </summary>
        public List<Project> Projects { get; set; }


        /// <summary>
        /// 专业技能
        /// </summary>
        public List<Skill> Skills { get; set; }


        /// <summary>
        /// 个人总结
        /// </summary>
        public List<Summary> Summarys { get; set; }
    }
}
