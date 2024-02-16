using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoManagementAssignment.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public DateTime SubmissionDate { get; set; }

        [Remote("CheckStartDate", "Vacation",AdditionalFields = "End")]
        public DateTime Start { get; set; }

        [Remote("CheckEndDate", "Vacation",AdditionalFields ="Start")]
        public DateTime End { get; set; }

        public DateTime Returning { get; set; }
        public int VacationDaysNumber => (End - Start).Days;
        public IdentityUser? Employee { get; set; }
        public Department? Department { get; set; }
    }
}
