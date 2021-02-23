using FresherProject.Common.AttributeBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Common
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [Required("Mã nhân viên", "Bạn phải nhập mã nhân viên")]
        [CheckDuplicate("Mã nhân viên", "Mã nhân viên đã tồn tại")]
        [MaxLength("Mã nhân viên", 20)]
        public string EmployeeCode { get; set; }
        [Required("Tên nhân viên", "Tên nhân viên là bắt buộc phải nhập")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public Guid? EmployeeDepartmentId { get; set; }
        public string Position { get; set; }
        //public string EmployeeDepartmentName { get; set; }
        public EmployeeDepartment EmployeeDepartment { get; set; }
        //public virtual EmployeeDepartment EmployeeDepartment { get; set; }
        [CheckDuplicate("Số chứng minh nhân dân")]
        public string IdentityCardNumber { get; set; }
        public DateTime IssuedOn { get; set; }
        public string IssuedPlace { get; set; }
        public string Address { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string LandlinePhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string StatusBankAccount { get; set; }
        public string BankProvince { get; set; }
    }
}
