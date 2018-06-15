import Vue from 'vue';
import Abstract from './pages/common/abstract';
import NotFound from './pages/common/404';
import NotAllow from './pages/common/401';
import Login from './pages/login/login';


const root = Vue.component('root', {
    template: '<router-view></router-view>'
});

let routes = [{
        path: '/login',
        component: Login,
        name: 'login',
        meta: {
            hidden: true
        }
    },
    {
        path: '/404',
        component: NotFound,
        name: '404',
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/401',
        component: NotAllow,
        name: '401',
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/',
        component: root,
        meta: {
            requiresAuth: true
        },
        children: [
            {
                path: 'manage',
                component: Abstract,
                name: '系统设置',
                iconClass: 'el-icon-setting',
                children: [{
                        path: 'users',
                        name: '用户管理',
                        component: Abstract,
                        imgUrl: 'https://o0p2g4ul8.qnssl.com/vsite%2Fbackground.jpg',
                        meta: {
                            requiresAuth: true,
                            requiresAdmin: true
                        },

                    },
                    {
                        path: 'printers',
                        name: '打印机管理',
                        component: Abstract,
                        imgUrl: 'https://o0p2g4ul8.qnssl.com/vsite%2Fbackground.jpg',
                        meta: {
                            requiresAuth: true
                        },
                    }
                ]
            }
        ]
    },
    {
        path: '*',
        redirect: {
            path: '/404'
        }
    }
];
let menuCount = routes.length;
routes[menuCount - 2].children.forEach(route => {
    if (route.children) {
        if (!route.meta) route.meta = {};
        route.meta.children = route.children;
    }
});

export default routes;