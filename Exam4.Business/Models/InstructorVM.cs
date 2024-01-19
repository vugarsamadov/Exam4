using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;

namespace Exam4.Business.Models
{
    public class InstructorVM
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string SpecializedArea { get; set; }
    }
}
