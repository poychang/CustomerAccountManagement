using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomerAccountManagement.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.是否已刪除 != true);
        }
        public IQueryable<客戶資料> All(bool isGetAll)
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
        public IQueryable<客戶資料> Get取得前10筆資料()
        {
            var data = this.All().Where(p => p.是否已刪除 != true);
            return data.Take(10);
        }
        public 客戶資料 GetByID(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id.Value && p.是否已刪除 != true);
        }
        public 客戶資料 GetByName(string str)
        {
            return this.All().FirstOrDefault(p => p.客戶名稱.Contains(str) && p.是否已刪除 != true);
        }
        public IQueryable<客戶資料> SearchByName(string str)
        {
            return base.All().Where(p => p.客戶名稱.Contains(str) && p.是否已刪除 != true);
        }
    }

    public interface I客戶資料Repository : IRepository<客戶資料>
    {

    }
}