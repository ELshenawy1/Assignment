using Microsoft.IdentityModel.Tokens;
using TechnoManagementAssignment.Models;

namespace TechnoManagementAssignment.Specifications
{
    public class VacationSpecification : BaseSpecification<Vacation>
    {
        public VacationSpecification(VacationSpecParams vacationParams)
            : base(p =>
            string.IsNullOrEmpty(vacationParams.Search) || p.Employee.UserName.ToLower().Contains(vacationParams.Search))
        {
            AddIncludes(x => x.Department);
            AddIncludes(x => x.Employee);
            if (!string.IsNullOrEmpty(vacationParams.Sort))
            {
                switch (vacationParams.Sort.ToLower())
                {
                    case "latest":
                        AddOrderByDescending(x => x.SubmissionDate);
                        break;
                    case "oldest":
                        AddOrderBy(x => x.SubmissionDate);
                        break;
                }
            }

            ApplyPaging(vacationParams.PageSize, vacationParams.PageSize * (vacationParams.PageIndex - 1));
        }

        public VacationSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.Department);
            AddIncludes(x => x.Employee);

        }
    }
}
