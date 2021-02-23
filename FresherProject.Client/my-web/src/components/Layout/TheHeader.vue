<template>
  <div class="header">
    <div class="header-left">
      <div class="logo">
        <div class="expend-icon"></div>
        <div class="logo-page"></div>
        <!-- <div class="name-page">Kế toán</div> -->
      </div>
    </div>
    <div class="header-right">
      <div class="chooseTheCompany">
        <select class="selectCompany" style="font-weight: bold;">
          <option value="misa">CÔNG TY TNHH NƯỚC UỐNG TINH KHIẾT SÀI GÒN</option>
          <option value="uet">Trường đại học Công nghệ</option>
        </select>
      </div>
      <div class="records">
        <div class="icon-records icon-input-search">
          <input
            class="icon-search input-search input-search-key"
            type="text"
            placeholder="Nhập từ khóa tìm kiếm"
          />
        </div>
        <div class="icon-records icon-more-infor"></div>
        <div class="icon-records icon-setting"></div>
        <div class="icon-records icon-messenger"></div>
        <div class="icon-records icon-question"></div>
        <div class="icon-records icon-notif"></div>

        <div class="picture"></div>
        <div class="fullname"><b>Phạm Văn Ngọc</b></div>
        <div class="icon"></div>
      </div>
    </div>
  </div>
</template>

<script>
require('../../style/layout/header.css')
export default {
};
</script>

<style>

</style>
