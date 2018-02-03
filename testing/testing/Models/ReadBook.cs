using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testing.Models
{
    public class ReadBook
    {
    }
    public class adminlogin
    {
      
    }
    public class admin
    {
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string Username
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password
        {
            get;
            set;
        }
    }


}
