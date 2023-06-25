using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skill_CodeFirstEntity.Models.MyClass;

namespace Skill_CodeFirstEntity.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        // GET: Admin
        public ActionResult Index()
        {            
            var query = context.Skills.ToList();
            return View(query);
        }

        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSkill(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return View();
        }

        public ActionResult SkillDelete(int id)
        {
            var query = context.Skills.Find(id);
            context.Skills.Remove(query);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            var query = context.Skills.Find(id);
            return View("SkillUpdate", query);
        }

        [HttpPost]
        public ActionResult SkillUpdate(Skill skill)
        {
            var query = context.Skills.Find(skill.SkillId);
            query.SkillName = skill.SkillName;
            query.PercentageValue = skill.PercentageValue;
            context.SaveChanges();
            return View("Index");
        }
    }
}