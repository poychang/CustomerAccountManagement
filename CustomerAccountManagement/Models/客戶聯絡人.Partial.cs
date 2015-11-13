namespace CustomerAccountManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }

    public partial class 客戶聯絡人MetaData : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }

        [CustomerAccountManagement.Models.Attribute.Email]
        [EmailAddress(ErrorMessage = "請檢查email格式")]
        [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]
        [Required]
        public string Email { get; set; }

        [Mobile]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "手機格式必須為1234-123456")]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        public Nullable<bool> 是否已刪除 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var item in 客戶資料.客戶聯絡人)
            {
                if (item.Email.Equals(this.Email))
                {
                    yield return new ValidationResult("電子郵件重複", new[] { "Email" });
                }
            }
        }
    }
}
