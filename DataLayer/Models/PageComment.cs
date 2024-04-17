using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }



        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        public int PageId { get; set; }



        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        [MaxLength(100)]
        public string Name { get; set; }



        [Display(Name = "ایمیل")]
        [MaxLength(50)]
        public string Email { get; set; }



        [Display(Name = "وب سایت")]
        [MaxLength(50)]
        public string Website { get; set; }



        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        [MaxLength(500)]
        public string Comment { get; set; }


        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }


        //Navigation Property
        public virtual Page Page { get; set; }

        public PageComment()
        {

        }

    }
}
