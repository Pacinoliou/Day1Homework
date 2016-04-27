using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Day1Homework.ViewModels
{
    public class InsAcbModels
    {


        public string Category { get; set; }

        [Required]
        [Display(Name = "金額")]
        [Range(1, int.MaxValue, ErrorMessage = "不可以輸入負數")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "日期")]
        [Remote("ValidateDate", "Home", ErrorMessage = "「日期」不得大於今天")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public System.DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "備註")]
        public string Remark { get; set; }

    }
}
