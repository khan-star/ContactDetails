using PartialViewsDemos.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SummitAfrica.Models
{
    public class UserContactDetails
    {
        public Userxml UserDataxml { get; set; }
        public UserDataTable UserDataTable { get; set; }
        public List<UserDataTable> UserDataTableList { get; set; }
    }

  //  Insert/Update
    public class Userxml : EntityBase
    {
        [Key]
        public int SNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
//List
    public class UserDataTable
    {
        [Key]
        public int SNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
