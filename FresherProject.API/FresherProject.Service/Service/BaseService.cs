using FresherProject.Common.AttributeBL;
using FresherProject.Common.Enum;
using FresherProject.Common.Result;
using FresherProject.DataLayer.Database;
using FresherProject.DataLayer.Interfaces;
using FresherProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FresherProject.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Khai báo và khởi tạo
        protected IDBConnector<T> _dBConnector;
        protected ServiceResult _serviceResult;
        public BaseService(IDBConnector<T> dBConnector)
        {
            _dBConnector = dBConnector;
            _serviceResult = new ServiceResult();

        }
        #endregion
        #region Cài đặt các hàm
        /// <summary>
        /// Hàm service lấy ra danh sách nhân viênn
        /// </summary>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public virtual ServiceResult GetAllData()
        {
            _serviceResult.Data = _dBConnector.GetAllData();
            return _serviceResult;
        }
        /// <summary>
        /// Validate việc thêm mới dữ liệu rồi tiến hành thêm mới
        /// </summary>
        /// <param name="entity">object thêm mới</param>
        /// <returns></returns>
        /// Created by: Ngoc (3/1/2021)
        public virtual ServiceResult Insert(T t)
        {
            // Validate dữ liệu
            ValidateObject(t);
            //Kiểm tra Validate
            //Nếu có bad request thì ta trả về thông báo (_serviceResult)
            if (_serviceResult.MISACukCukCode == MISACukCukServiceCode.BadRequest)
            {
                return _serviceResult;
            }
            //Còn kiểm tra không có bad request thì ta thực hiên thêm mới đối tượng
            var serviceResult = new ServiceResult()
            {
                Data = _dBConnector.Insert(t),
                Messenger = new List<string> { Properties.Resources.Msg_Success },
                MISACukCukCode = MISACukCukServiceCode.Success
            };
            return serviceResult;
        }
        /// <summary>
        /// Hàm validate dữ liệu insert và database
        /// </summary>
        /// <param name="t">Đối tượng cần kiểm tra</param>
        /// Created by: Ngoc (18/2/2021)
        protected virtual void ValidateObject(T t)
        {
            var properties = typeof(T).GetProperties();
            //Đối tượng truyền vào được duyệt qua các thuộc tính với attribute tương ứng
            //Nếu có attribute thì ta thực hiện kiểm tra giá trị của trường đó.
            foreach (var property in properties)
            {
                var propValue = property.GetValue(t);
                var propName = property.Name;
                // Kiểm tra nếu có attribute là [Required] thì thực hiện kiểm tra bắt buộc nhập
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} không được phép để trống" : errorMsg));
                        _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                    }

                }
                //Kiểm tra nếu có attribute là [Duplicate] thì thực hiện kiểm tra
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMsg = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        var sql = $"SELECT {propName} FROM {typeof(T).Name} WHERE {propName} = '{propValue}'";
                        var entity = _dBConnector.GetAllData(sql).FirstOrDefault();
                        if (entity != null && propValue != null)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} đã bị trùng" : errorMsg));
                            _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }

                }
                //Kiểm tra nếu có attribute là [MaxLength] thì thực hiện kiểm tra độ dài
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMsg = (requiredAttribute as MaxLength).ErrorMessenger;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} không được dài quá {length} kí tự" : errorMsg));
                            _serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Hàm service lấy đối tượng theo id
        /// </summary>
        /// <returns>object</returns>
        /// Created By: PVNgoc (07/02/2021)
        public virtual ServiceResult GetByFilter(string filter)
        {
            _serviceResult.Data = _dBConnector.GetByFilter(filter);
            return _serviceResult;
        }

        /// <summary>
        /// Hàm service lấy đối tượng theo id
        /// </summary>
        /// <returns>object</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult GetById(Guid id)
        {
            _serviceResult.Data = _dBConnector.GetById(id);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service lấy ra danh sách nhân viên theo command text
        /// </summary>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public virtual ServiceResult GetAllData(string cmText)
        {
            _serviceResult.Data = _dBConnector.GetAllData(cmText);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service cập nhập đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public virtual ServiceResult Update(T entity)
        {
            _serviceResult.Data = _dBConnector.Update(entity);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service Xóa đối tượng
        /// </summary>
        /// <param name="id">ID đối tượng cần xóa</param>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public virtual ServiceResult Delete(Guid id)
        {
            _serviceResult.Data = _dBConnector.Delete(id);
            return _serviceResult;
        }
        #endregion
    }
}
