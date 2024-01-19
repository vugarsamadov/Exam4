using Exam4.Business.Models;

namespace Exam4.Web.Models.Home
{
    public class IndexVM
    {
        public IEnumerable<InstructorVM> Instructors { get; set; }
    }
}
