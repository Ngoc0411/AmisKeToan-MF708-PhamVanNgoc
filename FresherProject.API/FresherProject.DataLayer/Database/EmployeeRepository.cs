using Dapper;
using FresherProject.Common;
using FresherProject.DataLayer.Database;
using FresherProject.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FresherProject.DataLayer.Database
{
    public class EmployeeRepository : DBConnector<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Lấy 100 nhân viên đầu tiên
        /// </summary>x
        /// <returns></returns>
        //public IEnumerable<Employee> GetEmployeeTop100()
        //{
        //    return GetAllData("SELECT * FROM Employee LIMIT 100");
        //}

        public override IEnumerable<Employee> GetAllData()
        {
            var storeName = $"Proc_GetEmployees";
            var entity = dBConnection.Query<Employee>(storeName, commandType: CommandType.StoredProcedure);

            var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
            {
                e.EmployeeDepartment = department;
                return e;
            }, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);

            return (IEnumerable<Employee>)entitys;
        }

        public override IEnumerable<Employee> GetById(Guid id)
        {
            var tableName = typeof(Employee).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id.ToString());
            var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
            {
                e.EmployeeDepartment = department;
                return e;
            }, dynamicParameters, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);
            return (IEnumerable<Employee>)entitys;
        }
        public override IEnumerable<Employee> GetByFilter(string filter)
        {
            var tableName = typeof(Employee).Name;
            var storeName = $"proc_get{tableName}byfilter";

            var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
            {
                e.EmployeeDepartment = department;
                return e;
            }, new { filter = filter }, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);

            return (IEnumerable<Employee>)entitys;
        }
    }
}
