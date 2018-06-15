<template lang="html">
  <div id="login-page" @keyup.enter="login">
    <div class="login-form">
      <div class="input-group">
        <div class="title">
          <img src="../../assets/logo.png"></img>
        </div>
        <el-input
          :autofocus="true"
          placeholder="请输入用户名"
          icon="time"
          v-model="username">
        </el-input>
      </div>
      <div class="input-group">
        <el-input
          placeholder="请输入密码"
          type="password"
          icon="time"
          v-model="password">
        </el-input>
      </div>
      <div class="input-group">
        <label>记住我？</label>
        <el-switch
          v-model="rememberMe"
          on-text=""
          off-text="">
        </el-switch>
      </div>
      <div class="input-group">
        <el-button @click.native="login" type="primary" :loading="isBtnLoading">{{btnText}}</el-button>
      </div>
    </div>
  </div>
</template>

<script>
import { signIn } from "../../api/api";
export default {
  data() {
    return {
      username: "",
      password: "",
      rememberMe: true,
      isBtnLoading: false
    };
  },
  computed: {
    btnText() {
      if (this.isBtnLoading) return "登录中...";
      return "登录";
    }
  },
  methods: {
    login() {
      if (!this.username) {
        this.$message.error("请填写用户名！！！");
        return;
      }
      if (!this.password) {
        this.$message.error("请填写密码");
        return;
      }
      let loginParams = { username: this.username, password: this.password };
      this.isBtnLoading = true;
      signIn(loginParams).then(data => {
        this.isBtnLoading = false;
        if (!data.Result) {
          this.$message.error(data.Message);
        } else {
          let user = data.User;
          localStorage.setItem("user", JSON.stringify(user));
          if (this.$route.query.redirect) {
            this.$router.push({ path: this.$route.query.redirect });
          } else {
            this.$router.push({ path: "/" });
          }
        }
      });
    }
  }
};
</script>

<style lang="scss" scoped>
#login-page {
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #efeeee;

  .login-form {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 500px;
    height: 400px;
    border-radius: 10px;
    background: white;
    border: 1px #eaeaea solid;
    box-shadow: 0px 0px 25px #cac6c6;

    .title {
      color: #20a0ff;
      font-weight: bold;
      font-size: 40px;
      text-align: center;
      line-height: 2.2;
      font-family: sans-serif;
    }

    .input-group {
      margin-top: 30px;
      width: 80%;
      button {
        width: 100%;
      }
    }
  }
}
</style>
