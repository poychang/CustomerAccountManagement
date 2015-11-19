using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerAccountManagement.Models;
using System.Data.Entity.Validation;

namespace CustomerAccountManagement.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶資料
        public ActionResult Index()
        {
            return View(repo客戶資料.Get取得前10筆資料());
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return RedirectToAction("Index");
            }
            return View(repo客戶資料.SearchByName(search));
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                if (repo客戶資料.GetByID(id) != null)
                {
                    return View(repo客戶資料.GetByID(id));
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,是否已刪除")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo客戶資料.Add(客戶資料);
                try
                {
                    repo客戶資料.UnitOfWork.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    var allErrors = new List<string>();

                    foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                    {
                        foreach (DbValidationError err in re.ValidationErrors)
                        {
                            allErrors.Add(err.ErrorMessage);
                        }
                    }
                    ViewBag.Errors = allErrors;
                }
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (repo客戶資料.GetByID(id) == null)
            {
                return HttpNotFound();
            }
            return View(repo客戶資料.GetByID(id));
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,是否已刪除")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                ((客戶資料Entities)repo客戶資料.UnitOfWork.Context).Entry(客戶資料).State = EntityState.Modified;
                repo客戶資料.UnitOfWork.Commit();
                //db.Entry(客戶資料).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (repo客戶資料.GetByID(id) == null)
            {
                return HttpNotFound();
            }
            return View(repo客戶資料.GetByID(id));
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //客戶資料.是否已刪除 = true;
            var 客戶資料 = repo客戶資料.GetByID(id);
            客戶資料.是否已刪除 = true;
            repo客戶資料.UnitOfWork.Commit();

            //與客戶資料相關聯的銀行帳戶&聯絡人資料也要一併刪除
            var repo客戶銀行資訊 = RepositoryHelper.Get客戶銀行資訊Repository();
            var 客戶銀行資訊 = repo客戶銀行資訊.All().Where(p=>p.客戶Id == 客戶資料.Id);
            foreach (var item in 客戶銀行資訊)
            {
                item.是否已刪除 = true;
            }
            repo客戶銀行資訊.UnitOfWork.Commit();

            var repo客戶聯絡人 = RepositoryHelper.Get客戶聯絡人Repository();
            var 客戶聯絡人 = repo客戶聯絡人.All().Where(p => p.客戶Id == 客戶資料.Id);
            foreach (var item in 客戶聯絡人)
            {
                item.是否已刪除 = true;
            }
            repo客戶聯絡人.UnitOfWork.Commit();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo客戶資料.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
