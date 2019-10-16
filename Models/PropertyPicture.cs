using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delmar1Api.Models
{
    public class PropertyPicture
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string FileName { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }

        public Property Property { get; set; }
    }
}
