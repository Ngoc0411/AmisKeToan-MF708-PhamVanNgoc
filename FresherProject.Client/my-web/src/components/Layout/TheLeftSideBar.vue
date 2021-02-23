<template>
  <div id="leftsidebar">
    <div class="menu">
      <router-link v-for="(item, index) in listItemMenu" :key="index" :to="item.link">
        <a class="menu__item" v-on:click="setActive(item.link)" :class="{ active: isActive(item.link) }">
          <div
           class="menu__item--icon"
           :class="item.classIcon">
            <!-- <img :src="item.icon" /> -->
          </div>
          <div class="menu__item--text">{{ item.name }}</div>
        </a>
      </router-link>
    </div>
  </div>
</template>

<script>
require('../../style/layout/leftsidebar.css')
export default {
  name: "leftsidebar",
  data() {
    return {
      activeLink: '/quan-li-nhan-vien',
      listItemMenu: [
        {
          //icon: require("@/assets/content/icon/document-online.png"),
          classIcon:"icon-tongquan",
          name: "Tổng quan",
          link: '/tong-quan'
        },
        {
          classIcon:"icon-tienmat",
          name: "Tiền mặt",
          link: "/tien-mat"
        },
        {
          classIcon:"icon-tiengui",
          name: "Tiền gửi",
          link: "/tien-gui"
        },
        {
          classIcon:"icon-muahang",
          name: "Mua hàng",
          link: "/mua-hang"
        },
        {
          classIcon:"icon-banhang",
          name: "Bán hàng",
          link: "/ban-hang"
        },
        {
          classIcon: "icon-quanlinhanvien",
          name: "Quản lí nhân viên",
          link: "/quan-li-nhan-vien"
        },
        {
          classIcon: "icon-quanlihoadon",
          name: "Quản lí hóa đơn",
          link: "/quan-li-hoa-don"
        },
        {
          classIcon:"icon-kho",
          name: "Kho",
          link: "/kho"
        },
        {
          classIcon:"icon-congcudungcu",
          name: "Công cụ dụng cụ",
          link: "/cong-cu-dung-cu"
        },
        {
          classIcon:"icon-taisancodinh",
          name: "Tài sản cố định",
          link: "/tai-san-co-dinh"
        },
        {
          classIcon:"icon-thue",
          name: "Thuế",
          link: "/thue"
        },
        {
          classIcon:"icon-giathanh",
          name: "Giá thành",
          link: "/gia-thanh"
        },
        {
          classIcon:"icon-tonghop",
          name: "Tổng hợp",
          link: "/tong-hop"
        },
        {
          classIcon:"icon-ngansach",
          name: "Ngân sách",
          link: "/ngan-sach"
        },
        {
          classIcon:"icon-baocao",
          name: "Báo cáo",
          link: "/bao-cao"
        },
        {
          classIcon:"icon-phantichtaichinh",
          name: "Phân tích tài chính",
          link: "/phan-tich-tai-chinh"
        },
      ],
    };
  },
  methods: {
    isActive: function (menuItem) {
      return this.activeLink === menuItem
    },
    setActive: function (menuItem) {
      this.activeLink = menuItem
    }
  }
};
</script>

<style>

</style>