using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class PropertyAndUserLink
    {
        public int PropertyId { get; set; }
        public int UserId { get; set; }

        public Property Property { get; set; }
        public User User { get; set; }
    }
}
