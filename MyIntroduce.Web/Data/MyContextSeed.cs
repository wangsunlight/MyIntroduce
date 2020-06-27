using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyIntroduce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Data
{
    public class MyContextSeed
    {
        private ILogger<MyContextSeed> _logger;
        public MyContextSeed(ILogger<MyContextSeed> logger)
        {
            this._logger = logger;
        }

        public static async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int? retry = 0)
        {
            var retryForAvaiability = retry.Value;

            try
            {
                using (var scope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = (MyContext)scope.ServiceProvider.GetService(typeof(MyContext));
                    var logger = (ILogger<MyContextSeed>)scope.ServiceProvider.GetService(typeof(ILogger<MyContextSeed>));
                    logger.LogDebug("Begin UserContextSeed SeedAsync");

                    context.Database.Migrate();
                    if (!context.Users.Any())
                    {
                        User user = new User()
                        {
                            CnblogsUrl = "https://www.cnblogs.com/wzhaoyang",
                            Email = "1872903310@163.com",
                            GithubUrl = "https://github.com/MrWangzhaoyang",
                            Motto = "生的平凡，不能活的平凡。",
                            Name = "王朝阳",
                            PhotoUrl = "images/me.jpg",
                            QQ = "528770307",
                            Url = "zhaoyang",
                            Wchar = "18272903310",
                            WebTitle = "朝阳(zhaoyang)个人网站-全栈工程师|.NET开发工程师",
                            Introduces = new List<Introduce>()
                            {
                                new Introduce(){ Content =".NET开发工程师 / 全栈开发工程师" },
                                new Introduce(){ Content ="王朝阳(zhaoyang) / 1998年05月 / 金牛座 / 河南" },
                                new Introduce(){ Content ="爱好：篮球，上网，旅游，技术" },
                                new Introduce(){ Content ="座右铭：生的平凡，不能活的平凡" },
                            },
                            Skills = new List<Skill>()
                            {
                                new Skill(){ Content ="<b>前端技术：</b>HTML、CSS、javascript、jQuery、EasyUI、Bootstrap、AngularJS、Ionic、LayUI；" },
                                new Skill(){ Content ="<b>后端技术：</b>C#、Ado.NET、Asp.NET、.NETCore、MVC、WebSerivce、WCF、WebApi、EntityFramewor、" },
                                new Skill(){ Content ="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;多线程、Socket、Linq、IOC、面向对象（OOP）、面向切面（AOP）、面向服务（SOA）编程思想、了解Asp.NET、" },
                                new Skill(){ Content ="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web Api、.Net Core HTTP管道处理模型流程以及实现原理、了解23种设计模式以及六大原则，以及微服务相关流程" },
                                new Skill(){ Content ="<b>数据库技术：</b>熟练掌握SqlServer、Mysql、Redis；" },
                                new Skill(){ Content ="熟悉Tomcat、IIS、Nginx等 web服务器并了解实现原理；" },
                                new Skill(){ Content ="熟练使用Xshell、Xftp、VS、VScode、Navicat、SVN、VSS、Git 等工具；" },
                                new Skill(){ Content ="熟练掌握Windows、linux常用命令；" },
                                new Skill(){ Content ="具有系统业务分析和良好的文档编写能力以及熟悉常用的开发模式；" }
                            },
                            Projects = new List<Project>()
                            {
                                new Project(){
                                    Title="1、吃喝拉撒（社区服务平台） —— 开发工程师 （2018年~2019年）",
                                    Content="技术栈:NET、Redis、读写分离、跨平台、Mysql、LayUI、ExtJS、ORM      开发环境：Windows",
                                    ProjectDetails = new List<ProjectDetails>(){
                                    new ProjectDetails(){  Content = "主要负责房产、社区、商城、咨询，新闻、活动、产品相关功能的开发工作。"},
                                    new ProjectDetails(){  Content = "1、基于NET框架，公司自己开发了一套O/RM框架，使用缓存提高了网站的访问速度，使用Quartz.NET实现定时任务调度，使用Log4Net实现记录日志，消息队列Queue，跨平台，多种数据库支持。"},
                                    new ProjectDetails(){  Content = "2、通过扩展HTTP管道处理模型自定Url地址实现地址拦截，处理业务逻辑。"},
                                    }
                                },
                                new Project(){
                                    Title="2、 exShop电商服务平台 ———— 开发工程师",
                                    Content="技术栈:NET、Redis、读写分离、跨平台、Mysql、LayUI、ExtJS、ORM      开发环境：Windows",
                                    ProjectDetails = new List<ProjectDetails>(){
                                    new ProjectDetails(){  Content = "主要负责代理商利润，三级分销，商品优惠的一些开发"}
                                    }
                                },
                            },
                            Summarys = new List<Summary>() {
                             new Summary(){ Content ="<b>我对自己的定位:</b> 全栈开发工程师。我不希望过于依赖别人,即使没有前端没有产品经理,我依然想要把这个产品做到完美。毕竟全栈 才能最高效地解决问题。"},
                             new Summary(){ Content ="<b>我对工作的态度:</b> 第一,要高效完成自己的本职工作。第二,要在完成的基础上寻找完美。第三,要在完美的基础上,与其他同事 互相交流学习,互相提升。工作是一种生活方式,不是一份养家糊口的差事。"},
                             new Summary(){ Content ="<b>我怎样克服困难:</b> 不用百度是第一原则,在遇到技术问题时我往往会去Google、CSDN、博客园上寻找答案。但通常很多问题 并不一定已经被人解决,所以熟练地阅读源码、以及阅读官网相关文档才是最终解决问题的办法。相信事实的结果,自己动手去做。"}
                             }
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    var logger = loggerFactory.CreateLogger(typeof(MyContextSeed));
                    logger.LogError(ex.Message);

                    await SeedAsync(applicationBuilder, loggerFactory, retryForAvaiability);
                }
            }
        }
    }
}
