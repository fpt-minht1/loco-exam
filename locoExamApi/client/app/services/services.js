(function(angular) {
    'use strict';

    angular.module('app.services').service('AppServices', AppServices);

    function AppServices() {
        var that = this;
        var apiUrl = '/api/product';

        this.sendRequest = function (url, type, data) {
            var deferred = $.Deferred();
            
            $.ajax({
                type: type || 'GET',
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

        this.deleteProduct = function (product) {
            return that.sendRequest(apiUrl, 'DELETE', {Id: id});
        }
    }

})(window.angular);
