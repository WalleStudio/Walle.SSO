export const format = (date, fmt) => {
    var o = {
        "M+": date.getMonth() + 1, //月份 
        "d+": date.getDate(), //日 
        "H+": date.getHours(), //小时 
        "m+": date.getMinutes(), //分 
        "s+": date.getSeconds(), //秒 
        "q+": Math.floor((date.getMonth() + 3) / 3), //季度 
        "S": date.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (date.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

export const addSeconds = (dt, sec) => {
    let timeStamp = Date.parse(dt);
    timeStamp = timeStamp / 1000;
    let result = new Date();
    result.setTime((timeStamp + sec) * 1000);
    return result;
}

export const addMinutes = (dt, min) => {
    let timeStamp = Date.parse(dt);
    timeStamp = timeStamp / 1000;
    let result = new Date();
    result.setTime((timeStamp + min * 60) * 1000);
    return result;
}

export const ParseDate=(remote) =>{
    var dateStr = remote.replace(/\/Date\((\d+)\)\//gi, "$1");
    var date = new Date();
    date.setTime(dateStr);
    console.log(date);
    return date.toLocaleString();
}