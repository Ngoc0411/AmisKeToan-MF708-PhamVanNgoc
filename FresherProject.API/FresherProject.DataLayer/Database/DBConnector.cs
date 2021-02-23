using Dapper;
using FresherProject.Common;
using FresherProject.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FresherProject.DataLayer.Database
{
    public class DBConnector<T>: IDisposable
    {
        #region Khai báo và khởi tạo
        protected static string connectionString = "Host=47.241.69.179; " +
            "Port=3306; User Id=nvmanh; password=12345678; " +
            "Database=MF708_PhamVanNgoc; Character Set=utf8;";
        //public static string connectionString;
        IDbConnection dBConnection;
        public DBConnector()
        {
            dBConnection = new MySqlConnection(connectionString);
        }
        public void Dispose()
        {
            dBConnection.Close();
        }
        #endregion
        #region Cài đặt các hàm
        /// <summary>
        /// Get danh sách toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <typeparam name="T">Đối tượng muốn lấy ra danh sách trong CSDL</typeparam>
        /// <returns>List of T</returns>
        public virtual IEnumerable<T> GetAllData()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dBConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);

            if (tableName == "Employee")
            {
                var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
                {
                    e.EmployeeDepartment = department;
                    return e;
                }, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);
                return (IEnumerable<T>)entitys;
            }

            return entity;
        }
        /// <summary>
        /// Lấy dữ liệu theo command Text truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">Mã sql</param>
        /// <returns>Mảng các object lấy được từ database</returns>
        /// Created by: Ngoc (2/1/2021)
        public virtual IEnumerable<T> GetAllData(string commandText)
        {
            string className = typeof(T).Name;
            var sql = commandText;
            var entities = dBConnection.Query<T>(sql);
            return entities;
        }
        /// <summary>
        /// Hàm thao tác với csdl để lấy ra đối tượng theo id của nó
        /// </summary>
        /// <param name="id">id của đối tượng cần lấy</param>
        /// <returns>object</returns>
        /// Created by: Ngoc (24/2/2021)
        public virtual IEnumerable<T> GetById(Guid id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id.ToString());
            var entity = dBConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            if (tableName == "Employee")
            {
                var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
                {
                    e.EmployeeDepartment = department;
                    return e;
                }, dynamicParameters, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);
                return (IEnumerable<T>)entitys;
            }

            return entity;
        }
        /// <summary>
        /// Hàm thao tác với cơ sở dữ liệu để lấy ra danh sách đối tượng dựa vào filter truyền vào
        /// </summary>
        /// <param name="filter">chuỗi cần tìm kiếm</param>
        /// <returns></returns>
        /// CreatedBy: Pham Van Ngoc (24/02/2021)
        public virtual IEnumerable<T> GetByFilter(string filter)
        {
            var tableName = typeof(T).Name;
            var storeName = $"proc_get{tableName}byfilter";
            var entity = dBConnection.Query<T>(storeName, new { filter = filter }, commandType: CommandType.StoredProcedure);

            if (tableName == "Employee")
            {
                var entitys = dBConnection.Query<Employee, EmployeeDepartment, Employee>(storeName, (e, department) =>
                {
                    e.EmployeeDepartment = department;
                    return e;
                }, new { filter = filter }, splitOn: "EmployeeDepartmentId", commandType: CommandType.StoredProcedure);
                return (IEnumerable<T>)entitys;
            }

            return entity;
        }


        /// <summary>
        /// Thao tác với csdl để thêm mới 1 đối tượng vào csdl
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created by: Ngoc (24/2/2021)
        public virtual int Insert(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Đọc các property của T:
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType.Name;
                if (propertyType != "String" && propertyType != "DateTime" && propertyValue != null)  
                    propertyValue = property.GetValue(entity).ToString();
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
        /// <summary>
        /// Hàm xóa đối tượng dựa theo id của nó
        /// </summary>
        /// <param name="id">id của đối tượng cần xóa</param>
        /// <returns></returns>
        /// Created by: Ngoc (24/2/2021)
        public virtual int Delete(Guid id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Delete{tableName}Id", id.ToString());
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
        /// <summary>
        /// Cập nhật 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <returns></returns>
        /// Created by: Ngoc (24/2/2021)
        public virtual int Update(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Đọc các property của T:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType.Name;
                if (propertyType != "String" && propertyType != "DateTime")
                    propertyValue = property.GetValue(entity).ToString();
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dBConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
        #endregion
    }
}
