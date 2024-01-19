using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Exam4.Business.Models
{
    public class UpdateInstructorVM
    {
        public string Name { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public int SpecializedAreaId { get; set; }
    }
}
