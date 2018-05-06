import Vue from 'vue';
import VueRouter from 'vue-router';
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';

import Breadcrumb from './components/breadcrumb';

import App from './app.vue';
import routes from './routes';
import './style.scss';

Vue.use(VueRouter);
Vue.use(ElementUI, {
    size: 'small'
});

// register dashboard components
Vue.component('db-breadcrumb', Breadcrumb);


export const router = new VueRouter({
    routes,
    mode: 'hash',
    linkActiveClass: 'active'
});

let api = require('./api/api.js')
api.init((axios) => {
    axios.defaults.headers.post['Content-Type'] = 'application/json;charset=UTF-8';
    axios.defaults.headers.put['Content-Type'] = 'application/json;charset=UTF-8';
    axios.defaults.withCredentials = true;
    axios.interceptors.response.use(
        response => {
            return response;
        },
        error => {
            if (error.response) {
                console.log(error.request);
                if (error.response.status == '401') {
                    Vue.prototype.$confirm('您缺少权限, 是否退出重新登录', '提示ʾ', {
                        confirmButtonText: '重新登录',
                        cancelButtonText: '取消',
                        type: 'warning'
                    }).then(() => {
                        localStorage.removeItem("user");
                        router.push({
                            path: "/login",
                            query: {
                                redirect: router.currentRoute.fullPath
                            }
                        });
                    }).catch(() => {
                        router.push({
                            path: "/401"
                        });
                    });
                    return {
                        data: {
                            Result: false,
                            Message: "您缺少相关权限"
                        }
                    }
                }
                return {
                    data: {
                        Result: false,
                        Message: error.response.statusText + "(" + error.response.status + ")"
                    }
                }
            }
        });
})

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        let user = JSON.parse(localStorage.getItem('user'));
        if (!user) {
            next({
                path: '/login',
                query: {
                    redirect: to.fullPath
                }
            });
            return;
        }
    }
    if (to.matched.some(record => record.meta.requiresAdmin)) {
        let user = JSON.parse(localStorage.getItem('user'));
        if ((!user)||user.Role!=1) {
            next({
                path: '/401',
            });
            return
        }
    }

    next();
});

new Vue({
    render: h => h(App),
    router
}).$mount('#app');