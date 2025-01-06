using CodeChallenge.Models;

namespace CodeChallenge;


/// <summary>
/// Extension methods for the Employee class
/// Note: This was made an extension class due to how closely related it is to the ReportingStructure class
///     and the fact that it doesn't need to be a part of the Employee class itself
/// </summary>
public static class EmployeeExtensions {

    /// <summary>
    /// Extension method to recursively count the number of reports for an employee
    /// </summary>
    public static int CountReports(this Employee employee)
    {
        int numReports = 0;
        foreach (var subordinate in employee.DirectReports) {
            numReports += subordinate.CountReports();
        }
        return numReports;
    }
}

/// <summary>
/// Class to represent the reporting structure of an employee
/// </summary>
public class ReportingStructure
{
    public readonly Employee employee;
    public int numberOfReports => employee.CountReports();
    
    /// <summary>
    /// Constructor
    /// </summary>
    public ReportingStructure(Employee employee) {
        this.employee = employee;
    }
}