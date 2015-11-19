using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomerAccountManagement.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.是否已刪除 != true);
        }
        public IQueryable<客戶聯絡人> All(bool isGetAll)
        {
            if (isGetAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }
        public IQueryable<客戶聯絡人> Get取得前50筆資料()
        {
            var data = this.All().Where(p => p.是否已刪除 != true);
            return data.Take(50);
        }
        public 客戶聯絡人 GetByID(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id.Value && p.是否已刪除 != true);
        }
        public 客戶聯絡人 GetByName(string str)
        {
            return this.All().FirstOrDefault(p => p.姓名.Contains(str) && p.是否已刪除 != true);
        }
        public IQueryable<客戶聯絡人> SearchByName(string str)
        {
            return base.All().Where(p => p.姓名.Contains(str) && p.是否已刪除 != true);
        }
    }

    public interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
    {

    }
}