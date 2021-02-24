<template>
  <div>
    <div
      title="Thông tin nhân viên"
      :class="{ isHide: isHide }"
    >
      <div class="dialog-modal"></div>
      <div class="dialog-content" >
        <div class="dialog-header">
          <div class="dialog-header-title"><b>Thông tin nhân viên</b></div>
          <div>
            <button class="dialog-header-close" v-on:click="btnCancelOnClick">
              x
            </button>
          </div>
        </div>
        <div class="dialog-body">

          <div class="row-body">
            <div class="margin-right6" style="width: 130px;">
              <div class="m-label">
                Mã <span class="label-required">*</span>
              </div>
              <div class="">
                <input
                  id="txtEmployeeCode"
                  required
                  class="input-required"
                  type="text"
                  v-model="Employee.EmployeeCode"
                  autofocus
                  tabindex="1"
                  ref="txtEmployeeCode"
                />
                <small style="color: red;" v-if="isHideErrorEmployeeCode == false">{{ errorMsgEmployeeCode }}</small>
              </div>
            </div>

            <div class="margin-right15" style="width: 227px">
              <div class="m-label">
                Tên <span class="label-required">*</span>
              </div>
              <div class="m-control">
                <input
                  class="input-required"
                  type="text"
                  required
                  v-model="Employee.FullName"
                  tabindex="2"
                />
                <small style="color: red;" v-if="isHideErrorFullName == false">{{ errorMsgFullName }}</small>
              </div>
            </div>

            <div class="margin-right15" style="width: 160px;">
              <div class="m-label">Ngày sinh</div>
              <input
                class="m-combobox-input"
                type="date"
                autocomplete="off"
                v-model="Employee.DateOfBirth"
                tabindex="3"
              />
            </div>

            <div class="" style="width: 169px">
              <div class="m-label">Giới tính</div>
                <div class="gender">
                  <input type="radio" value="1" name="gender" v-model="Employee.Gender">
                  <label>Nam</label><br>
                  <input type="radio" value="0" name="gender" v-model="Employee.Gender">
                  <label>Nữ</label><br>
                  <input type="radio" value="2" name="gender" v-model="Employee.Gender">
                  <label>Khác</label><br>
                </div>
            </div>

          </div>
          
          <div class="row-body">
            <div class="margin-right15" style="width: 362px">
              <div class="m-label">Đơn vị <span class="label-required">*</span></div>
              <select
                v-model="Employee.EmployeeDepartmentId"
                class="m-control"
                tabindex="4"
              >
                <option
                  v-for="(item, index) in listEmployeeDepartment"
                  :key="index"
                  :value="item.EmployeeDepartmentId"
                >
                  {{ item.EmployeeDepartmentName }}
                </option>
                <!-- <option value="19165ed7-212e-21c4-0428-030d4265475f">
                  Phòng đào tạo
                </option> -->
              </select>
              <small style="color: red;" v-if="isHideErrorEmployeeDepartment == false">Bạn chưa chọn đơn vị</small>
            </div>

            <div class="margin-right6" style="width: 189px">
              <div
                class="m-label"
                title="Số chứng minh thư nhân dân hoặc căn cước công dân"
              >
                Số CMTND
              </div>
              <div class="m-control">
                <input
                  id="txtIdentityNumber"
                  fieldName="text"
                  type="text"
                  required
                  v-model="Employee.IdentityCardNumber"
                  tabindex="5"
                />
                <small style="color: red;" v-if="isHideErrorIdentityCardNumber == false">Số CMND đã bị trùng</small>
              </div>
            </div>

            <div class="" style="width: 168px">
              <div class="m-label">Ngày cấp</div>
              <input
                class="m-combobox-input"
                type="date"
                autocomplete="off"
                v-model="Employee.IssuedOn"
                tabindex="6"
              />
            </div>

          </div>

          <div class="row-body">
            <div class="margin-right15" style="width: 50%">
              <div class="m-label">
                Chức danh
              </div>
              <div class="m-control">
                <input
                  id="txtPosition"
                  fieldName="Position"
                  type="text"
                  required
                  v-model="Employee.Position"
                  tabindex="7"
                />
              </div>
            </div>
            <div class="" style="width: 50%">
                <div class="m-flex-1">
                  <div class="m-label">Nơi cấp</div>
                  <div class="m-control">
                    <input
                      id="txtIdentityPlace"
                      fieldName="PhoneNumber"
                      class="input-required"
                      type="text"
                      v-model="Employee.IssuedPlace"
                      tabindex="8"
                    />
                  </div>
                </div>
                <div class="m-flex-1"></div>
              </div>
          </div>

          <div class="contact-bankaccount">
            <div class="header-contact-bankaccount">
              <div style="width: 67px; margin-right: 2px;">
                <div style="height: 10px" v-if="isBodyContact == false"></div>
                <div 
                  class="header-contact" 
                  title="Thông tin liên hệ" 
                  v-on:click="isBodyContact = true"
                  :class="{ 'tab-selected' : isBodyContact }"
                >Liên hệ</div>
              </div>
              <div style="width: 150px">
                <div style="height: 10px" v-if="isBodyContact"></div>
                <div 
                  class="header-bankaccount" 
                  title="Thông tin tài khoản ngân hàng" 
                  v-on:click="isBodyContact = false"
                  :class="{ 'tab-selected' : isBodyContact==false }"
                >Tài khoản ngân hàng</div>
              </div>
            </div>
            <div class="body-contact-bankaccount">
              <div class="body-contact" v-if="isBodyContact">
                <div class="" style="width: 100%">
                  <div class="m-label">Địa chỉ</div>
                  <div class="m-control">
                    <input
                      id="address"
                      fieldName="text"
                      type="text"
                      required
                      v-model="Employee.Address"
                      tabindex="9"
                    />
                  </div>
                </div>
                <div class="row-body" style="width:100%">
                  <div class="margin-right6">
                    <div class="m-label">ĐT di động</div>
                    <div class="m-control">
                      <input
                        id="mobilePhoneNumber"
                        fieldName="text"
                        type="text"
                        required
                        v-model="Employee.MobilePhoneNumber"
                        tabindex="10"
                      />
                    </div>
                  </div>
                  <div class="margin-right6">
                    <div class="m-label">ĐT cố định</div>
                    <div class="m-control">
                      <input
                        id="landlinePhoneNumber"
                        fieldName="text"
                        type="text"
                        required
                        v-model="Employee.LandlinePhoneNumber"
                        tabindex="11"
                      />
                    </div>
                  </div>
                  <div>
                    <div class="m-label">Email</div>
                    <div class="m-control">
                      <input
                        id="email"
                        fieldName="text"
                        type="text"
                        required
                        v-model="Employee.Email"
                        tabindex="12"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="body-bankaccount" v-if="isBodyContact==false">
                <div class="table-list-bankaccount"> 
                  <table
                    border="0"
                    width="100%"
                    cellspacing="0"
                    cellpadding="0"
                  >
                    <thead>
                      <tr>
                        <th>Số tài khoản</th>
                        <th>Tên ngân hàng</th>
                        <th>Chi nhánh</th>
                        <th>Tỉnh/TP của ngân hàng</th>
                        <th></th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>
                          <input
                            id="bankAccountNumber"
                            fieldName="text"
                            type="text"
                            required
                            v-model="Employee.BankAccountNumber"
                            tabindex="9"
                          />
                        </td>
                        <td>
                          <input
                            id="bankName"
                            fieldName="text"
                            type="text"
                            required
                            v-model="Employee.BankName"
                            tabindex="10"
                          />
                        </td>
                        <td>
                          <input
                            id="bankBranch"
                            fieldName="text"
                            type="text"
                            required
                            v-model="Employee.BankBranch"
                            tabindex="11"
                          />
                        </td>
                        <td>
                          <input
                            id="bankProvince"
                            fieldName="text"
                            type="text"
                            required
                            v-model="Employee.BankProvince"
                            tabindex="12"
                          />
                        </td>
                        <td title="Xóa tài khoản" class="td-deleteBankAccount">
                          <div class="deleteBankAccount" v-on:click="deleteBankAccount()"></div>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                
                  <div class="action-bankaccount">
                    <BaseButton
                      text="Thêm dòng"
                      class="btn-action-bankaccount"
                      @clickOnButton="addBankAccount"
                    />
                    <BaseButton
                      text="Xóa hết dòng"
                      class="btn-action-bankaccount"
                      @clickOnButton="deleteAllBankAccount"
                    />
                  </div>
              </div>
            </div>
          </div>

        </div>
        <div class="dialog-footer">
          <!-- <button id="btnCancel" class="m-btn m-btn-default m-btn-cancel" v-on:click="btnCancelOnClick">
            Hủy
          </button> -->
          <div class="dialog-footer-left">
            <BaseButton
              text="Hủy"
              class="btn-Cancel"
              @clickOnButton="btnCancelOnClick"
            />
          </div>
          <!-- <button id="btnSave" class="m-btn m-btn-default btn-haveicon" v-on:click="saveEmployee">
            <i class="far fa-save"></i><span class="btn-text">Lưu</span>
          </button> -->
          <div class="dialog-footer-right">
            <BaseButton 
              text="Cất" 
              class="btn-Save"
              @clickOnButton="saveEmployee(false)"
            />
            <BaseButton 
              text="Cất và Thêm" 
              class="btn-SaveAndAdd"
              @clickOnButton="saveEmployee(true)"
            />
          </div>
        </div>
      </div>
    </div>
    <AlertMessage
      title=""
      :contentText="contentTextAlert"
      :isHide="isHideAlert"
      :imageAlert="imageAlert"
      :colorAlert="colorAlert"
      @clickOnButtonCancel="closeAlert"
    />
  </div>
</template>
<script>
import * as axios from "axios";
import AlertMessage from "../Base/BaseAlertMessage"
import BaseButton from "../Base/BaseButton";
export default {
  props: {
    isHide: Boolean,
  },
  data() {
    return {
      // listBankAccount: [{}],
      Employee: {},
      listEmployeeDepartment: [],
      listEmployee: [],
      dialog: false,
      // display: "none",
      iconSave: require("../../assets/content/icon/save.png"),
      isBodyContact: true,
      isUpdate: false,
      checkValidateEmployee: true,
      isHideErrorIdentityCardNumber: true,
      isHideErrorEmployeeCode: true,
      isHideErrorFullName: true,
      errorMsgEmployeeCode: "",
      errorMsgFullName:"",
      isHideErrorEmployeeDepartment: true,

      contentTextAlert: "",
      isHideAlert: true,
      imageAlert: "",
      colorAlert: "",

      //Các biến để check các điều kiện
      checkDuplicateIdentityCardNumber: true,
      checkDuplicateEmployeeCode: true,
      checkRequireEmployeeCode: true,
      checkRequireFullName:true,
      checkRequireDepartment: true,

    };
  },
  components: {
    BaseButton,
    AlertMessage
  },
  methods: {
    /// Hàm thực hiện đóng thông báo
    /// createdBy NgocPham (24/02/2021)
    closeAlert(){
      this.isHideAlert = true;
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
    //Focus vào ô nhập mã nhân viên
    /// createdBy NgocPham (24/02/2021)
    focusToEmployeeCode(){
      this.$refs.txtEmployeeCode.focus();
    },
    /// Hàm thực hiện gán các giá trị của đối tượng lên dialog chi tiết và hiện form chi tiết lên
    /// createdBy NgocPham (24/02/2021)
    async ShowDetail(item, isUpdate) {
      this.Employee = await item;
      this.isUpdate = await isUpdate;

      if(isUpdate){
        this.Employee.IssuedOn = await this.formatDate(this.Employee.IssuedOn);
        this.Employee.DateOfBirth = await this.formatDate(this.Employee.DateOfBirth);
      }
      await this.focusToEmployeeCode();
    },
    /// Hàm thực hiện ẩn popup
    /// createdBy NgocPham (24/02/2021)
    btnCancelOnClick() {
      //Gọi tới cha để thông báo cần ẩn
      this.$emit("closePopup", true);
      this.deleteErrorMsg();
    },
    /// Hàm thực hiện xóa toàn bộ cảnh báo các ô input
    /// createdBy NgocPham (24/02/2021)
    deleteErrorMsg(){
      this.isHideErrorFullName = true;
      this.isHideErrorIdentityCardNumber = true;
      this.isHideErrorEmployeeCode = true;
      this.isHideErrorEmployeeDepartment = true;
    },
    /// Hàm thực hiện kiểm tra bắt buộc nhập của 1 ô input
    /// createdBy NgocPham (24/02/2021)
    checkRequiredInput(text) {
      if (text == "" || text == null) {
        return false;
      }
      else return true;
      // console.log(false);
    },
    /// Hàm thực hiện lấy toàn bộ danh sách nhân viên
    /// createdBy NgocPham (24/02/2021)
    async getEmployees() {
      await axios
        .get("https://localhost:44312/api/v1/employees")
        .then((response) => (
          this.listEmployee = response.data.Data,
          this.totalRecords = response.data.Data.length
        ));
    },
    //Hàm kiểm tra số cmnd khi mà số cmnd khác rỗng
    checkDuplicateIdentityCardNumberExceptionNull(){
      this.listEmployee.forEach(item => {
        if(item.IdentityCardNumber == this.Employee.IdentityCardNumber 
          && item.EmployeeId !== this.Employee.EmployeeId){
          this.isHideErrorIdentityCardNumber = false;
          this.checkDuplicateIdentityCardNumber = false;
        }
      });
    },
    //Hàm kiểm tra trùng số cmnd
    /// createdBy NgocPham (24/02/2021)
    ValidateDuplicateIdentityCardNumber(){
      //Kiểm tra trùng số cmnd
      if(this.Employee.IdentityCardNumber != null || this.Employee.IdentityCardNumber !== undefined)
       this.checkDuplicateIdentityCardNumberExceptionNull();
    },
    //Hàm kiểm tra trùng mã nhân viên
    /// createdBy NgocPham (24/02/2021)
    ValidateDuplicateEmployeeCode(){
      //Kiểm tra trùng mã nhân viên
      this.listEmployee.forEach(item => {
        if(item.EmployeeCode == this.Employee.EmployeeCode && item.EmployeeId !== this.Employee.EmployeeId){
          this.errorMsgEmployeeCode = "Mã nhân viên đã bị trùng.";
          this.isHideErrorEmployeeCode = false;
          this.checkDuplicateEmployeeCode = false;
        }
      })
    },
    /// Hàm thực hiện check bắt buộc nhập employeecode
    /// createdBy NgocPham (24/02/2021)
    ValidateRequireEmployeeCode(){
      if(this.checkRequiredInput(this.Employee.EmployeeCode)==false){
        this.errorMsgEmployeeCode = "Mã nhân viên không được để trống.";
        this.isHideErrorEmployeeCode = false;
        this.checkRequireEmployeeCode = false;
      }else{
        this.checkRequireEmployeeCode = true;
      }
    },
    /// Hàm thực hiện check bắt buộc nhập fullname
    /// createdBy NgocPham (24/02/2021)
    ValidateRequireFullName(){
      if(this.checkRequiredInput(this.Employee.FullName)==false){
        this.errorMsgFullName = "Tên nhân viên không được để trống."
        this.isHideErrorFullName = false;
        this.checkRequireFullName = false;
      }else{
        this.isHideErrorFullName = true;
        this.checkRequireFullName = true;
      }
    },
    /// Hàm thực hiện check bắt buộc chọn employeeDepartment
    /// createdBy NgocPham (24/02/2021)
    ValidateRequireDepartment(){
      if(this.checkRequiredInput(this.Employee.EmployeeDepartmentId)==false){
        this.isHideErrorEmployeeDepartment = false;
        this.checkRequireDepartment = false;
      }else{
        this.isHideErrorEmployeeDepartment = true;
        this.checkRequireDepartment = true;
      }
    },
    /// Hàm thực hiện validate dữ liệu sau khi nhấn cất/ Cất và thêm
    /// createdBy NgocPham (24/02/2021)
    async saveEmployee(isSaveAndAddContinue) {
      //Get ds nhân viên để validate
      await this.getEmployees();

      //Validate dữ liệu trước khi sửa/thêm mới
      this.ValidateDuplicateIdentityCardNumber();
      this.ValidateDuplicateEmployeeCode();
      this.ValidateRequireEmployeeCode();
      this.ValidateRequireFullName();
      this.ValidateRequireDepartment();

      //Kiểm tra từng điều kiện
      if(this.checkDuplicateIdentityCardNumber 
      && this.checkDuplicateEmployeeCode 
      && this.checkRequireEmployeeCode
      && this.checkRequireFullName
      && this.checkRequireDepartment)

        this.checkValidateEmployee = true;

      else this.checkValidateEmployee = false;

      this.resetVariableCheck();

      // await this.validateEmployee();

      console.log(this.checkValidateEmployee);

      if(this.checkValidateEmployee){
        if(this.isUpdate){
          const response = await axios.put(
            "https://localhost:44312/api/v1/employees",
            this.Employee
          ).then((response) => {
            console.log(response);
            //Ẩn form chi tiết
            if(isSaveAndAddContinue === false) this.$emit("closePopup", true);
            //Mở thông báo thêm thành công
            this.openAlertSuccess("Cập nhật nhân viên thành công!");
          })
          .catch(error => {
            //Mở thông báo xóa thất bại
            if(error != null) this.openAlertFail("Cập nhật nhân viên thất bại!");
          });
          console.log(response);
        }else{
          if(this.Employee.DateOfBirth == undefined) this.Employee.DateOfBirth = "2000-11-04";
          if(this.Employee.IssuedOn == undefined) this.Employee.IssuedOn = "2000-11-04";

          console.log(this.Employee);

          const response = await axios.post(
            "https://localhost:44312/api/v1/employees",
            this.Employee
          ).then((response) => {
            console.log(response);
            //Ẩn form chi tiết
            if(isSaveAndAddContinue === false) this.$emit("closePopup", true);
            //Mở thông báo thêm thành công
            this.openAlertSuccess("Đã thêm nhân viên thành công!");
          })
          .catch(error => {
            //Mở thông báo xóa thất bại
            if(error != null) this.openAlertFail("Thêm nhân viên thất bại!");
          });
          console.log(response);
        }
        this.deleteErrorMsg();
      }else{
        if(this.isUpdate){
          //Mở thông báo xóa thất bại
          this.openAlertFail("Cập nhật nhân viên thất bại!");
        }else{
          //Mở thông báo xóa thất bại
          this.openAlertFail("Thêm nhân viên thất bại!");
        }
      }
    },
    resetVariableCheck(){
      this.checkDuplicateIdentityCardNumber = true ;
      this.checkDuplicateEmployeeCode = true ;
      this.checkRequireEmployeeCode = true;
      this.checkRequireFullName = true;
      this.checkRequireDepartment = true;
    },
    async getListEmployeeDepartment() {
      await axios
        .get("https://localhost:44312/api/v1/employeedepartments")
        .then((response) => (this.listEmployeeDepartment = response.data.Data));
    },
    addBankAccount(){
      // this.listBankAccount.push({});
    },
    deleteAllBankAccount(){
      // this.listBankAccount.splice(0, this.listBankAccount.length);
      // this.listBankAccount.push({});
    },
    deleteBankAccount(){
      // this.listBankAccount.splice(index, 1);
    },
    formatDate(date) {
      var d = new Date(date);
      if (Number.isNaN(d.getTime())) {
          return "";
      } else {
          var day = d.getDate();
          var month = d.getMonth() + 1;
          var year = d.getFullYear();

          day = day < 10 ? '0' + day : day;
          month = month < 10 ? '0' + month : month;

          return  year + '-' + month + '-' +  day  ;
      }
    }
  },
  created() {
    this.getListEmployeeDepartment();
  },
};
</script>
<style scoped>
input-selected{
  background-color: red;
}
.gender{
  display: flex;
  align-items: center;
  padding: 5px 0px 0px 0px;
}
table tbody tr td .deleteBankAccount{
  background: url('../../assets/content/icon/list-icon.svg') no-repeat -464px -313px;
	width: 15px;
	height: 15px;
}
.td-deleteBankAccount:hover{
  background-color: #DADCE1;
}
.action-bankaccount{
  display: flex;
}
.action-bankaccount .btn-action-bankaccount{
  height: 24px;
  color: #bbbbbb;
  border: 1px solid #bbbbbb;
  background-color: #ffffff;
  margin-right: 10px;
}
/* .action-bankaccount .btn-action-bankaccount:hover{
  background-color: #F4F5FA;
} */
table {
  display: table;
  border-collapse: separate;
  box-sizing: border-box;
  text-indent: initial;
  border-color: grey;
  background-color: #F0F2FB;
}
table th,
td {
  padding: 7px;
  padding-right: 16px;
  padding-left: 16px;
  border-bottom: 1px solid #bbbbbb;
  border-right: 1px solid #bbbbbb;
  text-align: left;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}
.table-list-bankaccount{
  overflow: auto;
  height: 95px;
}
/* width */
.table-list-bankaccount::-webkit-scrollbar {
  height: 6px;
  width: 6px;
}

/* Track */
.table-list-bankaccount::-webkit-scrollbar-track {
  box-shadow: inset 0 0 5px grey;
  border-radius: 10px;
}

/* Handle */
.table-list-bankaccount::-webkit-scrollbar-thumb {
  background: #a9a8a8;
  border-radius: 10px;
}

/* Handle on hover */
.table-list-bankaccount::-webkit-scrollbar-thumb:hover {
  background: #939191;
}
.contact-bankaccount{
  margin-top: 30px;
  height: 230px; 

}
.header-contact-bankaccount{
  display: flex;
}

.header-contact-bankaccount .header-contact{
  border: 1px solid #ccc;
  padding: 5px 5px 5px 11px;
  height: 15px;
}
.header-contact-bankaccount .header-contact:hover{
  cursor: pointer;
}
.header-contact-bankaccount .header-bankaccount{
  padding: 5px 5px 5px 11px;
  border: 1px solid #ccc;
  height: 15px;
}
.header-contact-bankaccount .header-bankaccount{
  cursor: pointer;
}
.header-contact-bankaccount .tab-selected{
  background-color: #B7D3E2;
  padding: 10px 10px 10px 10px;
}
.contact-bankaccount .body-contact-bankaccount{
  border: 1px solid #ccc;
  height: calc(100% - 30px);
}

.contact-bankaccount .body-contact{
  padding: 10px 10px 10px 10px;
}
.contact-bankaccount .body-bankaccount{
  padding: 10px 10px 10px 10px;
}

.isHide {
  display: none;
}

.dialog-header {
  position: relative;
  height: 40px;
  line-height: 60px;
  padding-left: 16px;
  display: flex;
  font-size: 24px;
}

.dialog-header-close {
  position: absolute;
  right: 16px;
  width: 24px;
  height: 24px;
  border-radius: 50%;
  cursor: pointer;
  top: 10px;
  align-items: center;
  border: none;
  background-color: transparent;
  font-size: 24px;
  line-height: 24px;
}
.dialog-modal {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  z-index: 2;
  opacity: 0.4;
}

.dialog-content {
  z-index: 3;
  position: fixed;
  border-radius: 5px;
  width: 800px;
  background-color: #fff;
  left: calc(50% - 325px);
  top: calc(50% - 314px);
}
.dialog-body {
  padding: 10px 30px 40px 30px;
}
.dialog-footer {
  display: flex;
  width: 100%;
  height: 70px;
  border-radius: 0 0 5px 5px;
  align-items: center;
  /* justify-content: flex-end; */
  box-sizing: border-box;
  border-top: 1px solid #ccc;
  padding: 15px 30px 15px 30px;
}
.dialog-footer .dialog-footer-left{
  left: 0;
}
.dialog-footer .dialog-footer-right{
  position: absolute;
  right: 30px;
  display: flex;
}
.text-align-right {
  text-align: right;
}

.text-align-center {
  text-align: center;
}

a {
  text-decoration: none;
  color: #000000;
}

.m-label {
  margin-bottom: 4px;
  font-weight: bold;
}


.label-required {
  color: #ff0000;
}

input[required]::after {
  display: block;
  width: 10px;
  height: 10px;
  position: absolute;
  background-color: #ff4747;
  transform: rotate(45deg);
  left: 50%;
  content: "Thông tin";
}

input.border-red {
  border: 1px solid #ff4747;
}



.row-selected {
  background-color: #01916026 !important;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
}

.box-toast-msg {
  display: none;
  position: fixed;
  background-color: #ffffff;
  padding: 24px;
  color: #019160;
  font-size: 20px;
  bottom: 24px;
  text-align: center;
  right: 24px;
  border: 1px solid #ccc;
}


input,
select {
  padding: 10px 16px;
  border-radius: 2px !important;
  outline: none !important;
  width: 100%;
  height: 38px;
  box-sizing: border-box !important;
}

input[type="radio"] {
  height: 20px;
  width: 20px;
}

input:focus,
select:focus {
  border-color: #019160;
}

input::placeholder {
  font-size: 11px;
}

.input-search {
  padding-left: 40px;
}

.m-date-picker {
  display: block;
}

.m-date-picker .dateInput {
  position: relative;
  display: flex;
  align-items: center;
}

.m-date-picker .dateInput .ui-datepicker-trigger {
  width: 16px;
  height: 16px;
  position: absolute;
  right: 0px;
  z-index: 1;
  border: 12px solid rgba(0, 0, 0, 0);
  border-radius: 0 5px 5px 0;
  cursor: pointer;
}

.m-date-picker .dateInput .dateInput-icon-box {
  width: 40px;
  height: 40px;
  border-radius: 0 5px 5px 0;
  position: absolute;
  right: 0;
  border-left: 1px solid #bbbbbb;
  z-index: 0;
}

#btnSave {
  background-image: url("../../assets/content/icon/save.png");
}
.btn-Cancel {
  background-color: #ffffff;
  color: #000000 !important;
  border: 1px solid #ABABAB;
  margin-right: 16px;
}
.btn-Cancel:hover {
  background-color: #d2cfcf;
}
.btn-SaveAndAdd {
  background-color: #19BA1C;
  color: #ffffff !important;
  font-family: GoogleSans-Semibold;
}
.btn-Save {
  color: #000000 !important;
  font-family: GoogleSans-Semibold;
  background-color: #ffffff;
  border: 1px solid #b5b5b5;
  margin-right: 10px;
}
.btn-SaveAndAdd:hover {
  background-color: #1FDC22;
}
.btn-Save:hover {
  background-color: #b5b5b5;
}
input:focus {
  border: 1px solid #01b075 !important;
}
input.border-red {
  border: 1px solid #ff4747;
}
.row-body{
  margin-top: 10px;
  display: flex;
}
.margin-right6{
  margin-right: 6px;
}
.margin-right15{
  margin-right: 15px;
}
table {
    padding-left: 0px; 
     padding-right: 0px;
}
</style>
