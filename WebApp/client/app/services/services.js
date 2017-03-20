(function(angular) {
    'use strict';

    angular.module('app.services').service('AppServices', AppServices);

    AppServices.$inject = [
        '$http', '$q'
    ];
    function AppServices() {
        var apiHost = "";
        var that = this;
        this.sendRequest = function (url, type) {
            var deferred = $.Deferred();
            if (!type || type == 'GET') {
                $.get(apiHost + url)
                .done(function (response) {
                    console.log(response);
                    deferred.resolve(response);
                }).fail(function (response) {
                    deferred.reject(response);
                });
            }
            if (type == 'POST') {
                $.post(apiHost + url)
                .done(function (response) {
                    deferred.resolve(response);
                }).fail(function (response) {
                    deferred.reject(response);
                });
            }
            return deferred.promise();
        }
        
        this.getProductList = function () {
            var url = '/api/product';
            return that.sendRequest(url);
        };
        this.getProduct = function (id) {
            var url = '/api/product/' + id;
            return that.sendRequest(url);
        };
        
    }

})(window.angular);
