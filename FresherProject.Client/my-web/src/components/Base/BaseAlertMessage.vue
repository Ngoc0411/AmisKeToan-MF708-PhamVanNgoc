<template>

  <div class="DialogDeleteEmployee dialog-detail"  :class="{ isHide: isHide }" >
      <div class="dialog-modal"></div>
      <div class="dialog-content">
        <div class="dialog-header"  :class="colorAlert">
          <div class="dialog-header-title">{{ title }}</div>
          <div>
            <button class="dialog-header-close" v-on:click="btnCancelOnClick">
              x
            </button>
          </div>
        </div>
        <div class="dialog-body"  :class="colorAlert">
            <div :class="imageAlert">

            </div>
            {{ contentText }}
        </div>
        <div class="dialog-footer">
            <div class="button-footer">
              <div class="button-footer-left">
              </div>
              <div class="button-footer-right">
                <BaseButton 
                    text = "Done"
                    class = "btn-done"
                    @clickOnButton ="btnCancelOnClick"
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
    imageAlert: String,
    colorAlert: String,
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
  },
}
</script>

<style scoped>
.success{
  background-color: #a7e6a8;
}
.failure{
  background-color: rgb(212 148 148);;
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

.dialog-header {
  position: relative;
  height: 40px;
  padding-left: 24px;
  display: flex;
  font-size: 24px;
  line-height: 60px;
}

.dialog-modal {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
  z-index: 4;
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
    display: flex;
}
.dialog-body .image-warning{
  background: url('../../assets/content/icon/list-icon.svg') no-repeat -598px -463px;
	width: 50px;
	height: 37px;
  margin-right: 20px;
  padding-right: 0;
}
.dialog-body .image-success{
  background: url('../../assets/content/icon/list-icon.svg') no-repeat -990px -462px;
	width: 48px;
	height: 36px;
  margin-right: 20px;
  padding-right: 0;
}
.dialog-body .image-failure{
  background: url('../../assets/content/icon/list-icon.svg') no-repeat -752px -462px;
	width: 36px;
	height: 36px;
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
.btn-done{
  background-color: #7190f8;
  padding: 0 20px 0 20px;
}
.btn-done:hover{
  background-color: #A5B8F8;
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