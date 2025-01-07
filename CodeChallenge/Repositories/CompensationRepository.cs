using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        /// <summary>
        /// Add compensation to context
        /// </summary>
        public Compensation Add(Compensation compensation)
        {
            _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        /// <summary>
        /// Retrieve compensation by employee id from context
        /// </summary>
        public Compensation GetById(string employeeId)
        {
            return _compensationContext.Compensations.SingleOrDefault(e => e.EmployeeId == employeeId);
        }

        /// <summary>
        /// Asynchronously save changes to context
        /// </summary>
        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }

        /// <summary>
        /// Remove compensation from context
        /// </summary>
        public Compensation Remove(Compensation compensation)
        {
            return _compensationContext.Remove(compensation).Entity;
        }
    }
}