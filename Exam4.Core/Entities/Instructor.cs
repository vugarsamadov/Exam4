using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam4.Core.Entities
{
    public class Instructor : BaseEntity
    {
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public SpecializedArea SpecializedArea { get; set; }
        public int SpecializedAreaId { get; set; }
    }
}
