using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Models
{
    /// <summary>
    /// Class to represent the reporting structure of an employee
    /// </summary>
    public class ReportingStructure
    {
        public String employeeId { get; private set; }
        public int numberOfReports { get; private set; }

        public ReportingStructure(string employeeId, List<Employee> directReports)
        {
            this.employeeId = employeeId;
            this.numberOfReports = 
                directReports?.Select(e => 1 + CalculateNumberOfReports(e)).Sum() ?? 0;
        }

        /// <summary>
        /// Recursively calculate the number of reports for an employee
        /// </summary>
        public int CalculateNumberOfReports(Employee employee)
        {
            
            // Return 0 if no direct reports
            if (employee.DirectReports == null || !employee.DirectReports.Any())
                return 0;

            // Recursively count the number of reports
            int count = 0;
            foreach (var subordinate in employee.DirectReports)
                count += 1 + CalculateNumberOfReports(subordinate);
            return count;
        }
    }
}