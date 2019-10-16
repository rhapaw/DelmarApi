using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class PropertySubType
    {
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public string Description { get; set; }

        public PropertyType PropertyType { get; set; }
    }
}
