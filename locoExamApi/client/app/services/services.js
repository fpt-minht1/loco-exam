(function(angular) {
    'use strict';

    angular.module('app.services').service('AppServices', AppServices);

    AppServices.$inject = [
        '$http', '$q'
    ];
    function AppServices() {
        var that = this;
        var apiUrl = '/api/product';

        this.sendRequest = function (url, type, data) {
            var deferred = $.Deferred();
            //if (!type || type == 'GET') {
            //    $.get(url)
            //    .done(function (response) {
            //        deferred.resolve(response);
            //    }).fail(function (response) {
            //        deferred.reject(response);
            //    });
            //}
            //if (type == 'POST') {
            //    $.post(url, data)
            //    .done(function (response) {
            //        deferred.resolve(response);
            //    }).fail(function (response) {
            //        deferred.reject(response);
            //    });
            //}
            
            $.ajax({
                method: type || 'GET',
                url: url,
                data: JSON.stringify(data) || null,
                dataType: "json",
                contentType: "application/json",
                traditional: true
            }).done(function (response) {
                deferred.resolve(response);
            }).fail(function (response) {
                console.log('error: ', response);
                deferred.reject(response);
            });
            return deferred.promise();
        }
        
        this.getProductList = function () {
            return that.sendRequest(apiUrl);
        };
        this.getProduct = function (product) {
            return that.sendRequest(apiUrl + product);
        };
        
        this.addProduct = function (product) {
            return that.sendRequest(apiUrl, 'POST', product);
        }

        this.deleteProduct = function (id) {
            return that.sendRequest(apiUrl, 'DELETE', { Id: id });
        }
    }

})(window.angular);
