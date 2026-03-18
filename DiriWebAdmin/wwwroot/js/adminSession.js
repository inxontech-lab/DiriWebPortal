window.adminSession = {
    get: function (key) {
        return window.sessionStorage.getItem(key);
    },
    set: function (key, value) {
        window.sessionStorage.setItem(key, value);
    },
    remove: function (key) {
        window.sessionStorage.removeItem(key);
    }
};
