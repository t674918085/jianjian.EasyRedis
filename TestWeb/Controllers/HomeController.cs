using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Models;
using JianJian.EasyRedis.Middleware;
using JianJian.EasyRedis.Base.Interface;
using EasyCaching.Core;

namespace TestWeb.Controllers
{
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    public class HomeController : Controller
    {
         public IJianjianEasyCachingProvider jianjianEasyCachingProvider { get; set; }
       // public IEasyCachingProvider easyCachingProvider { get; set; }
        public HomeController(IJianjianEasyCachingProvider jianjian)
        {
             jianjianEasyCachingProvider = jianjian;
            //easyCachingProvider = easy;
        }
        public IActionResult Index()
        {
            //string
            jianjianEasyCachingProvider.StringSet("test", "12345");
            jianjianEasyCachingProvider.StringSet("test1", "12345", TimeSpan.FromSeconds(50));
            //list
            
            jianjianEasyCachingProvider.ListLeftPush("list", 1);
            jianjianEasyCachingProvider.ListLeftPush("list", 2);
            jianjianEasyCachingProvider.ListRightPush("list", 11);
            jianjianEasyCachingProvider.ListRightPush("list", 22);
            jianjianEasyCachingProvider.ListLeftPush("list", 100);
            //
            Student st1 = new Student();
            st1.name = "st1";
            st1.age = 1;
            Student st2 = new Student();
            st2.name = "st2";
            st2.age = 2;
            Student st3 = new Student();
            st3.name = "st3";
            st3.age = 3;
            jianjianEasyCachingProvider.ListLeftPush("listStudent", st1);
            jianjianEasyCachingProvider.ListLeftPush("listStudent", st2);
            jianjianEasyCachingProvider.ListRightPush("listStudent", st3);
            //hash
            jianjianEasyCachingProvider.HashSet("user", "u1", "66666666666666666");
            jianjianEasyCachingProvider.HashSet("user", "u2", "1234");
            jianjianEasyCachingProvider.HashSet("user", "u3", "1235");
            var news = jianjianEasyCachingProvider.HashGet<string>("user", "u2");
            //hash 
            jianjianEasyCachingProvider.SortedSetAdd<Student>("sort", st1, 1);
            jianjianEasyCachingProvider.SortedSetAdd<Student>("sort", st2, 5);
            jianjianEasyCachingProvider.SortedSetAdd<Student>("sort", st3, 2);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
