using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StudentInformation.Models
{
    public class SampleData
    {
        public async static Task InitDB(IServiceProvider service)
        {
            //获取上下文实例
            var db = service.GetRequiredService<StudentContext>();

            //获取UserManager实例
            var userManager = service.GetRequiredService<UserManager<User>>();

            if(db.Database!=null&&db.Database.EnsureCreated())
            {
                //创建初始用户
                await userManager.CreateAsync(new User
                {
                    UserName = "admin",
                    Email = "343224963@qq.com"
                }, "Cream2015!@#");

                //创建初始个人信息，int型ID会根据seed自动递增
                db.Students.Add(new Student
                {
                    Name = "Cream",
                    Sex = "M",
                    Age = 20,
                    Class = "软件121",
                    Address = "地球村",
                    Note="无"
                    
                });
                db.Students.Add(new Student
                {
                    Name = "CXS",
                    Sex = "W",
                    Age = 25,
                    Class = "软件122",
                    Address = "克山火车站旁边小卖部",
                    Note = "无"
                });
                db.Students.Add(new Student
                {
                    Name = "YYP",
                    Sex = "M",
                    Age = 30,
                    Class = "软件123",
                    Address = "大连华信软件公司",
                    Note = "无"
                });
                db.SaveChanges();
            }
        }
    }
}
