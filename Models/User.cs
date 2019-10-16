using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxPhone { get; set; }
        public string OtherPhoneType { get; set; }
        public string OtherPhone { get; set; }
        public string Bio { get; set; }

        public List<PropertyAndUserLink> PropertyLinks { get; set; }
    }
}
