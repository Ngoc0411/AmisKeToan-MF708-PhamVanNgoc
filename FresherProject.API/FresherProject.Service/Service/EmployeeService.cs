using FresherProject.Common;
using FresherProject.Common.AttributeBL;
using FresherProject.Common.Enum;
using FresherProject.Common.Result;
using FresherProject.DataLayer.Interfaces;
using FresherProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FresherProject.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository _employeeRepository) :base(_employeeRepository)
        {

        }
    }
}
