<template>

  <div class="DialogDeleteEmployee dialog-detail" :class="{ isHide: isHide }">
      <div class="dialog-modal"></div>
      <div class="dialog-content">
        <div class="dialog-header">
          <div class="dialog-header-title">{{ title }}</div>
        </div>
        <div class="dialog-body">
            <div class="image-dialog-body">

            </div>
            {{ contentText }}
        </div>
        <div class="dialog-footer">
            <div class="button-footer">
              <div class="button-footer-left">
                <BaseButton
                    text="Hủy"
                    class="btn-Cancel"
                    @clickOnButton="btnCancelOnClick"
                />
              </div>
              <div class="button-footer-right">
                <BaseButton 
                    text = "Có"
                    class = "btn-delete"
                    @clickOnButton ="btnDeleteOnClick"
                />
              </div>
            </div>
        </div>
      </div>
    </div>
</template>

<script>
import BaseButton from "../Base/BaseButton.vue"
export default {
  props: {
    isHide: Boolean,
    title: String,
    contentText: String,
  },
  data() {
      return {
          iconRemove: require('../../assets/content/icon/delete.png'),
      }
  },
  components:{
    BaseButton
  },
  methods: {
      btnCancelOnClick() {
      this.$emit("clickOnButtonCancel", true);
    },
    btnDeleteOnClick(){
      this.$emit("clickOnButtonDelete");
    }
  },
}
</script>

<style scoped>

.dialog-header {
  position: relative;
  height: 40px;
  padding-left: 24px;
  display: flex;
  font-size: 24px;
  line-height: 60px;
}

.dialog-modal {
  z-index: 4;
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
}

.dialog-content {
  z-index: 5;
  position: fixed;
  border-radius: 5px;
  width: 500px;
  background-color: #fff;
  left: calc(50% - 240px);
  top: calc(50% - 120px);
  border-radius: 5px;
}
.dialog-body {
    bottom: 0;
    padding: 0px 35px 24px 35px;
    font-size: 17px;
    border-radius: 5px;
    display: flex;
}
.dialog-body .image-dialog-body{
  background: url('../../assets/content/icon/list-icon.svg') no-repeat -598px -463px;
	width: 50px;
	height: 37px;
  margin-right: 20px;
  padding-right: 0;
}
.isHide {
  display: none;
}

.btn-Cancel {
  color: #000000 !important;
  border: 1px solid #e5e5e5;
  background-color: #ffffff;
}
.button-footer-left{
  position: absolute;
  margin: 17px 0 12px 0;
  left: 35px;
}
.button-footer-right{
  position: absolute;
  right: 35px;
  margin: 17px 0 12px 0;

}
.btn-Cancel:hover {
  background-color: #d2cfcf;
}
.btn-delete{
  background-color: #19BA1C;
  padding: 0 20px 0 20px;
}
.btn-delete:hover{
  background-color: #1FDC22;
}

.DialogDeleteEmployee .dialog-footer {
    width: 100%;
    height: 75px;
    position: relative;
    bottom: 0;
    border-radius: 0 0 5px 5px;
    border-top: 1px solid #e5e5e5 ;
}

    .DialogDeleteEmployee .dialog-footer .button-footer {
        display: flex;
    }
</style>