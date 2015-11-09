using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerAccountManagement.Models;

namespace CustomerAccountManagement.Controllers
{
    public class vw客戶聯絡人及帳戶數量Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: vw客戶聯絡人及帳戶數量
        public ActionResult Index()
        {
            return View(db.vw客戶聯絡人及帳戶數量.ToList());
        }

        // GET: vw客戶聯絡人及帳戶數量/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量 = db.vw客戶聯絡人及帳戶數量.Find(id);
            if (vw客戶聯絡人及帳戶數量 == null)
            {
                return HttpNotFound();
            }
            return View(vw客戶聯絡人及帳戶數量);
        }

        // GET: vw客戶聯絡人及帳戶數量/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vw客戶聯絡人及帳戶數量/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,客戶名稱,銀行帳戶數量,聯絡人數量")] vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量)
        {
            if (ModelState.IsValid)
            {
                db.vw客戶聯絡人及帳戶數量.Add(vw客戶聯絡人及帳戶數量);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw客戶聯絡人及帳戶數量);
        }

        // GET: vw客戶聯絡人及帳戶數量/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量 = db.vw客戶聯絡人及帳戶數量.Find(id);
            if (vw客戶聯絡人及帳戶數量 == null)
            {
                return HttpNotFound();
            }
            return View(vw客戶聯絡人及帳戶數量);
        }

        // POST: vw客戶聯絡人及帳戶數量/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,客戶名稱,銀行帳戶數量,聯絡人數量")] vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw客戶聯絡人及帳戶數量).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw客戶聯絡人及帳戶數量);
        }

        // GET: vw客戶聯絡人及帳戶數量/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量 = db.vw客戶聯絡人及帳戶數量.Find(id);
            if (vw客戶聯絡人及帳戶數量 == null)
            {
                return HttpNotFound();
            }
            return View(vw客戶聯絡人及帳戶數量);
        }

        // POST: vw客戶聯絡人及帳戶數量/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vw客戶聯絡人及帳戶數量 vw客戶聯絡人及帳戶數量 = db.vw客戶聯絡人及帳戶數量.Find(id);
            db.vw客戶聯絡人及帳戶數量.Remove(vw客戶聯絡人及帳戶數量);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
