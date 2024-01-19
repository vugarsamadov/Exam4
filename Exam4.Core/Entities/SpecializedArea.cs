using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam4.Core.Entities
{
    public class SpecializedArea : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
