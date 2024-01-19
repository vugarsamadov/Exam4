using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Exam4.Business.Models
{
    public class CreateInstructorVM
    {
        public string Name { get; set; }
        public IFormFile ProfileImage { get; set; }
        public int SpecializedAreaId { get; set; }
    }
}
