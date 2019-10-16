using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<PropertySubType> PropertySubTypes { get; set; }
    }
}
