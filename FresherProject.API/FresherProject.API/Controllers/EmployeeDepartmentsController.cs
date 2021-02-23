using FresherProject.Common;
using FresherProject.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FresherProject.API.Controllers
{
    public class EmployeeDepartmentsController : BaseEntitiesController<EmployeeDepartment>
    {
        public EmployeeDepartmentsController(IEmployeeDepartmentService _employeeDepartmentService) : base(_employeeDepartmentService)
        {
        }
    }
}
