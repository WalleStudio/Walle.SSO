<template>
<<<<<<< HEAD
  <div id="app">
    <img src="./assets/logo.png">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
=======
  <section class="db">
    <template v-if="!$route.meta.hidden">
      <!-- header start  -->
      <header class="db-header">
        <router-link class="logo" :to="{path: '/list/filters'}">
          <img src="../src/assets/logo.png"/>
        </router-link>
        <div class="user-info" v-if="user._Id">
          <span v-text="user.UserName+ user.WorkId"></span>
          <el-dropdown trigger="click">
            <span class="el-dropdown-link">
              <img src="../src/assets/avatar1.png">
            </span>
            <el-dropdown-menu slot="dropdown">
               <el-dropdown-item @click.native="updatepassword">修改密码</el-dropdown-item>
              <el-dropdown-item @click.native="logout">退出登录</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
        </div>
      </header>
      <!-- header end  -->

      <!-- body start  -->
      <div class="db-body">

        <!-- menu start -->
        <aside class="db-menu-wrapper">
          <el-menu :default-active="activeMenu" class="db-menu-bar" router>
            <template v-for="(route, index) in $router.options.routes[$router.options.routes.length - 2].children">
              <template v-if="route.children && route.name">
                <el-submenu :index="route.name">
                  <template slot="title"><i :class="route.iconClass"></i>{{route.name}}</template>
                  <el-menu-item :index="cRoute.name" v-for="(cRoute, cIndex) in route.children" :route="cRoute" v-if="!cRoute.meta.requiresAdmin">{{cRoute.name}}</el-menu-item>
                  <el-menu-item :index="cRoute.name" v-for="(cRoute, cIndex) in route.children" :route="cRoute" v-if="cRoute.meta.requiresAdmin&&isAdmin">{{cRoute.name}}</el-menu-item>
                </el-submenu>
              </template>

              <template v-if="!route.children && route.name">
                <el-menu-item :index="route.name" :route="route"><i :class="route.iconClass"></i>{{route.name}}</el-menu-item>
              </template>
            </template>
          </el-menu>
        </aside>
        <!-- menu end -->

        <!-- content start -->
        <div class="db-content-wrapper">
          <section class="db-content">
            <router-view></router-view>
          </section>
        </div>
        <!-- content end -->
      </div>
      <!-- body end  -->
    </template>
    <template v-else>
      <router-view></router-view>
    </template>
  </section>
</template>

<script>
import * as api from "./api/api"

export default {
  data() {
    return {
      user: {
        _Id: "",
        UserName: "",
        WorkId: ""
      },
      activeMenu: "",
      isAdmin:false
    };
  },
 
  created() {
    this.activeMenu = this.$route.name;
    this.user = JSON.parse(localStorage.getItem("user"));
    if(this.user && this.user.Role == 1)
      {
        this.isAdmin = true;
      }
  },
  watch: {
    $route(to, from) {
      this.activeMenu = this.$route.name;
      this.user = JSON.parse(localStorage.getItem("user"));
      if(this.user && this.user.Role == 1)
      {
        this.isAdmin = true;
      }
    }
  },
  methods: {
    logout() {
      this.$confirm("确定要注销吗?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "info"
      })
        .then(() => {
          this.isAdmin = false;
          localStorage.removeItem("user");
          this.$router.push({ path: "/login" });
        })
        .catch(() => {});
    },
    updatepassword(){
     
        this.$prompt('请输入新密码', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          inputPattern: /^[A-Za-z0-9]{6,20}$/,
          inputErrorMessage: '请输入最少6位,最大20位字符'
        }).then(({ value }) => {
          api.updatePass({pass:value}).then(resp=>{
            this.$message({
              type:'warning',
              message:resp.data.Message
            })
          });
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '取消输入'
          });       
        });
      
    }
  }
};
</script>

<style lang="scss">
@import "./styles/_variables.scss";
.db {
  .el-dropdown-menu {
    margin-top: 20px;
  }
  // header
  .db-header {
    width: 100%;
    height: 50px;
    background: #012f3c;
    padding: 6.5px 20px;
    box-sizing: border-box;
    color: #ffffff;
    z-index: 99;
    position: fixed;
    left: 0;
    top: 0;
    .logo {
      font-size: 2.4rem;
      img {
        margin-top: 5px;
      }
    }
    .user-info {
      font-size: 1.6rem;
      float: right;
      img {
        width: 30px;
        height: 30px;
        border-radius:15px;
        vertical-align: -7px;
        margin: 0 0 0 10px;
        cursor: pointer;
      }
    }
  }

  // body
  .db-body {
    // menu
    .db-menu-wrapper {
      position: fixed;
      left: 0;
      top: 50px;
      background: red;
      height: 100%;
      overflow: auto;
      z-index: 98;

      .db-menu-bar {
        height: 100%;
        flex-grow: 0;
        width: 160px;
      }
    }

    // content
    .db-content-wrapper {
      width: 100%;
      z-index: 97;
      box-sizing: border-box;
      padding: 50px 0px 0px 160px;

      .db-content {
        padding: 15px;

        .db-content-inner {
          padding: 15px 0px;
        }
      }
    }
  }
>>>>>>> f1caae70876329049f8cba9b178228d64483fa39
}
</style>
