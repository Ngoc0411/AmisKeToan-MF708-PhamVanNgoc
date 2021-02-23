using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FresherProject.Service;
using FresherProject.Common.Enum;
using FresherProject.Service.Interfaces;

namespace FresherProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<T> : ControllerBase
    {
        #region Khai báo và khởi tạo
        IBaseService<T> _baseService;

        public BaseEntitiesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Các hàm được cài đặt
        // GET: api/<TsController>
        /// <summary>
        /// API thực hiện lấy ds T
        /// </summary>
        /// <returns>List T</returns>
        /// createdBy NgocPham (24/02/2021)
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_baseService.GetAllData());
        }
        /// <summary>
        /// API thực hiện việc lấy dữ liệu theo filter truyền vào
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>list object</returns>
        /// createdBy NgocPham (24/02/2021)
        [HttpGet("filter")]
        public virtual IActionResult Get([FromQuery] string filter)
        {
            return Ok(_baseService.GetByFilter(filter));
        }
        /// <summary>
        /// API thực hiện get object theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object</returns>
        /// createdBy NgocPham (24/02/2021)
        // GET api/<TsController>/5
        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            return Ok(_baseService.GetById(id));
        }

        // POST api/<TsController>
        /// <summary>
        /// API thực hiện thêm 1 object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// /// createdBy NgocPham
        [HttpPost]
        public virtual IActionResult Insert([FromBody] T entity)
        {
            //return Ok(_baseService.Insert(entity));
            // Validate tại Service
            var res = _baseService.Insert(entity);
            //Trả về kết quả
            switch (res.MISACukCukCode)
            {
                case MISACukCukServiceCode.Success:
                    return Ok(res);
                case MISACukCukServiceCode.BadRequest:
                    return BadRequest(res);
                case MISACukCukServiceCode.Exception:
                    return StatusCode(500);
                default:
                    return Ok();
            }
        }
        /// <summary>
        /// API thực hiện cập nhật đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <returns></returns>
        /// createdBy NgocPham (24/02/2021)
        // PUT api/<TsController>/5
        [HttpPut]
        public virtual IActionResult Put([FromBody] T entity)
        {
            return Ok(_baseService.Update(entity));
        }
        /// <summary>
        /// API thực hiện xóa đối tượng
        /// </summary>
        /// <param name="id">id của Đối tượng cần xóa</param>
        /// <returns></returns>
        /// createdBy NgocPham (24/02/2021)
        // DELETE api/<TsController>/5
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            return Ok(_baseService.Delete(id));
        }
        #endregion
    }
}
