using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }


        [Display(Name ="گروه صفحه")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید ")]
        public int GroupId { get; set; }


        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        [MaxLength(100)]
        public string Title { get; set; }


        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        [MaxLength(350)]
        public string ShortDescription { get; set; }


        [Display(Name = "متن صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public string Text { get; set; }


        [Display(Name = "تعداد بازدید صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public int Visit { get; set; }

        [Display(Name = "عکس صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public string ImageName { get; set; }


        [Display(Name = "نمایش در اسلایدر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public bool ShowInSlider { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public DateTime CreaetDate { get; set; }


    }
}
