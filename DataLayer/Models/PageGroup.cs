using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }



        [Display(Name ="عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید ")]
        [MaxLength(100)]
        public int GroupTitle { get; set; }


        //Navigation Property
        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {

        }
    }
}
