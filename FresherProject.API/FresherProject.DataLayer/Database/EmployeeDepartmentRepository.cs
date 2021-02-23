using FresherProject.Common;
using FresherProject.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.DataLayer.Database
{
    public class EmployeeDepartmentRepository : DBConnector<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        /// <summary>
        /// Lấy 100 nhân viên đầu tiên
        /// </summary>x
        /// <returns></returns>
        public IEnumerable<EmployeeDepartment> GetEmployeeTop100()
        {
            return GetAllData("SELECT * FROM EmployeeDepartment LIMIT 2");
        }
    }
}
