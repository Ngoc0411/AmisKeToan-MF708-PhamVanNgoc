<template>
  <div class="content">
    <div class="header-content">
      <div class="title">
        Nhân viên
        <div class="all-category">	&lt;  Tất cả các danh mục</div>
      </div>
      <div class="content-feature">
        <BaseButton
          text = "Thêm"
          class = "btn-add"
          @clickOnButton ="showEmployeeProfileDetail({}, false)"
        />
      </div>
    </div>
    <div class="content-employee">
      <div class="filter-bar">
        <div class="filter-left">
          <input
            class="icon-search input-search"
            type="text"
            placeholder="Tìm kiếm theo Mã, Tên nhân viên"
            v-model="filterSearch"
            @change="searchByFilter()"
          />
        </div>
      </div>
      <div class="grid grid-employee">
        <table
          id="tbListData"
          border="0"
          width="100%"
          cellspacing="0"
          cellpadding="0"
        >
          <thead>
            <tr>
              <th class="manhanvien">Mã nhân viên</th>
              <th class="tennhanvien">Tên nhân viên</th>
              <th class="chucdanh">Chức danh</th>
              <th class="tendonvi">Tên đơn vị</th>
              <th class="sotaikhoan">Số tài khoản</th>
              <th class="tennganhang">Tên ngân hàng</th>
              <th class="trangthai">Trạng thái</th>
              <th class="chinhanh">Chi nhánh</th>
              <th class="chucnang">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in listEmployee" :key="index">
              <td>{{ item.EmployeeCode }}</td>
              <td>{{ item.FullName }}</td>
              <td>{{ item.Position }}</td>
              <td>{{ item.EmployeeDepartment.EmployeeDepartmentName }}</td>
              <td>{{ item.BankAccountNumber }}</td>
              <td>{{ item.BankName }}</td>
              <td>{{ item.StatusBankAccount }}</td>
              <td>{{ item.BankBranch }}</td>
              <td style="display: flex;">
                <div class="td-update" v-on:click="showEmployeeProfileDetail(item, true)"><b>Sửa</b></div>
                <div class="more-function dropdown">
                  <div class="icon-more-function"></div>
                    <div class="dropdown-content">
                      <a>Nhân bản</a>
                      <a class="delete-dropdown-content" v-on:click="showDialogConfirmDeleteEmployee(item)">Xóa</a>
                      <a>Ngưng sử dụng</a>
                    </div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="paging-bar">
      <div class="note1">
        Tổng số <b>{{ totalRecords }}</b> bản ghi
      </div>
      <div class="listPage">
        <ol id="listPageOl">
          <!--<li value="0" class="selected">1</li>
                        <li value="12">2</li>
                        <li value="24">3</li>
                        <li value="36">4</li>-->
        </ol>
      </div>
      <div class="note2">
        <select>
          <option>11 bản ghi trên 1 trang</option>
        </select>
        <button>Trước</button>
        <button>1</button>
        <button>2</button>
        <button>3</button>
        <button>...</button>
        <button>5</button>
        <button>Sau</button>
      </div>
    </div>

    <EmployeeProfileDetail
      :isHide="isHideDetail"
      @closePopup="closePopup"
      ref="EmployeeProfileDetail"
    />

    <DialogConfirmDeleteEmployee
      title=""
      :contentText="contentText"
      :isHide="isHideDialogConfirmDelete"
      imageAlert="image-warning"
      @clickOnButtonCancel="closePopup"
      @clickOnButtonDelete="deleteEmployeeSelected"
    />

    <AlertMessage
      title=""
      :contentText="contentTextAlert"
      :isHide="isHideAlert"
      :imageAlert="imageAlert"
      :colorAlert="colorAlert"
      @clickOnButtonCancel="closePopup"
    />
  </div>
</template>

<script>
import axios from "axios";
import EmployeeProfileDetail from "./EmployeeProfileDetail.vue";
import DialogConfirmDeleteEmployee from "../Base/BaseDialogWarning"
import BaseButton from "../Base/BaseButton"
import AlertMessage from "../Base/BaseAlertMessage"
require('../../style/pages/employee.css')
export default {
  data() {
    return {
      isHideDetail: true,
      isHideDialogConfirmDelete: true,
      EmployeeSelected: {},
      listEmployee: [],
      filterSearch:'',
      isUpdate: false,
      totalRecords: 0,
      contentText: "",
      maxEmployeeCode: 0,
      maxEmployeeCodeString:"",

      contentTextAlert: "",
      isHideAlert: true,
      imageAlert: "",
      colorAlert: "",
    };
  },
  components: {
    EmployeeProfileDetail,
    BaseButton,
    DialogConfirmDeleteEmployee,
    AlertMessage
  },
  created() {
    this.getEmployees();
  },
  computed:{
  },
  methods: {
    /// Hàm thực hiện tìm kiếm nhân viên theo filterSearch
    /// createdBy NgocPham (24/02/2021)
    async searchByFilter(){
      if(this.filterSearch == "" || this.filterSearch == undefined){
        this.getEmployees();
      }
      else{
        await axios
        .get("https://localhost:44312/api/v1/employees/filter?filter=" + this.filterSearch)
        .then((response) => (
          this.listEmployee = response.data.Data,
          this.totalRecords = response.data.Data.length
        ));
      }
      
    },
    /// Hàm thực hiện mở alert thông báo thành công
    /// createdBy NgocPham (24/02/2021)
    openAlertSuccess(message){
      this.isHideAlert = false;
      this.contentTextAlert = message;
      this.imageAlert = "image-success";
      this.colorAlert = "success";
    },
    /// Hàm thực hiện mở alert thông báo thất bại
    /// createdBy NgocPham (24/02/2021)
    openAlertFail(message){
      this.contentTextAlert = message;
      this.isHideAlert = false;
      this.imageAlert = "image-failure";
      this.colorAlert = "failure";
    },
    /// Hàm thực hiện xóa nhân viên được chọn
    /// createdBy NgocPham (24/02/2021)
    async deleteEmployeeSelected(){
      //Call api để delete EmployeeSelected
        await axios
        .delete("https://localhost:44312/api/v1/employees/" + this.EmployeeSelected.EmployeeId)
        .then((response) => {
          console.log(response);
          //Ẩn form confirm
          this.isHideDialogConfirmDelete = true;
          //Load lại danh sách employee
          this.getEmployees();
          //Mở thông báo xóa thành công
          this.openAlertSuccess("Xóa nhân viên thành công!");
        })
        .catch(error => {
          //Mở thông báo xóa thất bại
          if(error != null) this.openAlertFail("Xóa nhân viên thất bại!");
        },);
    },
    /// Hàm thực hiện mở dialog cảnh báo xóa
    /// createdBy NgocPham (24/02/2021)
    showDialogConfirmDeleteEmployee(item){
      this.isHideDialogConfirmDelete = false;
      this.contentText = "Bạn có chắc muốn xóa nhân viên " + item.FullName + " không?";
      this.EmployeeSelected = item;
    },
    /// Hàm thực hiện mở dialog chi tiết nhân viên
    /// createdBy NgocPham (24/02/2021)
    async showEmployeeProfileDetail(item, isUpdate){
      if(isUpdate === false) item.EmployeeCode = this.maxEmployeeCodeString;
      this.$refs.EmployeeProfileDetail.ShowDetail(item, isUpdate);
      this.isHideDetail = false;
    },
    /// Hàm thực hiện gọi server để lấy dữ liệu
    /// createdBy NgocPham (24/02/2021)
    async getEmployees() {
      await axios
        .get("https://localhost:44312/api/v1/employees")
        .then((response) => (
          this.listEmployee = response.data.Data,
          this.totalRecords = response.data.Data.length
        ));
        //Vòng for để lấy ra mã nhân viên cao nhất
        let number = 0;
        this.listEmployee.forEach(employee => {

          number = Number(employee.EmployeeCode.substring(2, employee.EmployeeCode.length));
          if(number > this.maxEmployeeCode) this.maxEmployeeCode = number;

        });

        number = this.maxEmployeeCode + 1;
        this.maxEmployeeCodeString =  "NV" + number; 
    },
    /// Hàm thực hiện đóng các dialog/ popup
    /// createdBy NgocPham (24/02/2021)
    closePopup(isHide) {
      this.isHideDetail = isHide;
      this.isHideDialogConfirmDelete = isHide;
      this.isHideAlert = isHide;
      this.getEmployees();
    },
  },
};
</script>

<style scoped>
.icon-search {
  background-image: url("../../assets/content/icon/search.png");
  background-position: center;
  background-repeat: no-repeat;
  background-position: 244px 4px;;
  background-size: 25px;
}

.note2 select{
  height: 30px;
  width: 170px;
  padding: 0 0 0 10px;
  font-size: 13px;
}
.note2 button{
  border: none;
}
</style>
