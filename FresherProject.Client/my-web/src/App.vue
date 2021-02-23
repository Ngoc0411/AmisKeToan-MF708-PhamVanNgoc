<template>
  <div id="app">
    <Header></Header>
    <div style="display: flex">
        <LeftSideBar></LeftSideBar>
        <div class="router-view">
            <router-view></router-view>
        </div>
    </div>
  </div>
</template>

<script>
import Header from './components/Layout/TheHeader'
import LeftSideBar from './components/Layout/TheLeftSideBar'
require('./style/common/common.css')

export default {
  name: 'App',
  components: {
    Header,
    LeftSideBar,
  }
}
</script>

<style >


</style>
