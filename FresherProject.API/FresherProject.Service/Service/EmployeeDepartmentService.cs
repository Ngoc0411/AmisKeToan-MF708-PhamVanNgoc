using FresherProject.Common;
using FresherProject.DataLayer.Interfaces;
using FresherProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Service.Service
{
    public class EmployeeDepartmentService : BaseService<EmployeeDepartment>, IEmployeeDepartmentService
    {
        public EmployeeDepartmentService(IEmployeeDepartmentRepository _employeeDepartmentRepository) : base(_employeeDepartmentRepository)
        {

        }
    }
}
