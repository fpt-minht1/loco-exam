(function() {
    'use strict';

    angular.module('app.controllers').controller('ProductController', ProductController);

    ProductController.$inject = ['AppServices'];
    function ProductController(AppServices) {
        var self = this;
        this.productList = [];
        this.model = {
            
        };

        this.init = function () {
            self.getProductList();
        };

        this.getProductList = function() {
            $.when(AppServices.getProductList())
            .done(function (res) {
                self.productList = angular.fromJson(res);
            })
            .fail();
        };
    }

})(window.angular);
