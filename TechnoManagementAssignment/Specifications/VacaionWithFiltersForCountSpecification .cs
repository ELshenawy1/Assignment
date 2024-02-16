using TechnoManagementAssignment.Models;

namespace TechnoManagementAssignment.Specifications
{
    public class VacaionWithFiltersForCountSpecification : BaseSpecification<Vacation>
    {
        public VacaionWithFiltersForCountSpecification(VacationSpecParams vacationParams)
            : base(p =>
            string.IsNullOrEmpty(vacationParams.Search) || p.Employee.UserName.ToLower().Contains(vacationParams.Search))
        {
        }
    }
}
