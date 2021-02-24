<template>
  <button class="m-btn m-btn-default" v-on:click="clickOnButton">
    <img :class="{'icon-button' : urlIcon !== undefined }" :src="urlIcon" />
    <div class="btn-text">
      {{text}}
    </div>
  </button>
</template>

<script>
export default {
  props :{
    urlIcon: String,
    text: String,
  },
  data(){
    return{
      
    }
  },
  methods: {
    clickOnButton(){
      this.$emit("clickOnButton", this.text);
    }
  },
}
</script>

<style>
/* .icon-add {
  width: 16px;
  height: 16px;

  /* background-image: url('../../assets/content/icon/add.png'); */
    /* :style="'background-image:url(' + `${require('../../assets/content/icon/add.png')})`" 
} */
.m-second-button:hover {
    background-color: #e9ebee;
}
.m-second-button {
    background-color: #ffffff;
    border: 1px solid #bbbbbb;
    border-radius: 4px;
    height: 40px;
    color: #000000;
    padding-left: 24px;
    padding-right: 24px;
    text-align: center;
    cursor: pointer;
    outline: none;
}
.m-btn .icon-button {
  margin-right: 8px;
}
/* 
#btnDeleteEmployee {
  padding-left: 0;
  margin-right: 14px;
  background-color: #dc143c;
}
.icon-delete {
  width: 30px;
  height: 55px;
  background-repeat: no-repeat;
  background-position: 16px center;
  padding: 0;
} */
.m-btn {
    display: flex;
    align-items: center;
    border-radius: 4px;
    height: 40px;
    font-size: 13px;
    color: #ffffff;
    font-family: GoogleSans-Regular;
    padding-left: 16px;
    padding-right: 16px;
    cursor: pointer;
    outline: none;
    border: none;
    justify-content: center;
}
</style>