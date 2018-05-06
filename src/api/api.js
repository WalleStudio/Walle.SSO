import axios from 'axios';
let base = 'api';
//init settings
export const init = (setting) => {
    setting(axios);
}
//sign
export const signIn = params => {
    return axios.post(`${ base }/signin`, params).then(res => res.data);
};
export const signout = params => {
    return axios.post(`${ base }/signout`, params).then(res => res.data);
};

//user
export const getUsers = params => {
    return axios.get(`${ base }/user/list`, {
        params: params
    });
};
export const addUser = params => {
    return axios.post(`${base}/user/add`, params);
};
export const editUser = params => {
    return axios.put(`${base}/user/${params.id}/name/${params.name}/workid/${params.workId}`);
};
export const removeUser = params => {
    return axios.delete(`${base}/user/${params.id}`);
};
export const editUserRole = params => {
    return axios.put(`${base}/user/${params.id}/role/${params.role}`);
};
export const resetUserPwd = params=>{
    return axios.put(`${base}/user/${params.id}/resetpwd`);
}
export const updatePwd = (params) => {
    return axios.put(`${base}/user/pwd/${params.pass}`);
}

