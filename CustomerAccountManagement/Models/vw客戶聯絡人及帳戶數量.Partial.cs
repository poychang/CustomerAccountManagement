namespace CustomerAccountManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vw客戶聯絡人及帳戶數量MetaData))]
    public partial class vw客戶聯絡人及帳戶數量
    {
    }
    
    public partial class vw客戶聯絡人及帳戶數量MetaData
    {
        [Required]
        public int id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        [Required]
        public int 銀行帳戶數量 { get; set; }
        [Required]
        public int 聯絡人數量 { get; set; }
    }
}
