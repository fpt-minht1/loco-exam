(function (angular) {
    'use strict';

    angular.module('app.controllers')
    .controller('ProductController', ProductController);

    ProductController.$inject = ['$scope', '$controller'];
    function ProductController($scope, $controller) {
        
        var self = this;
        self.items = [{
            product_id: 'PRODUCT0001',
            price: 20,
            qty: 2
        }];
        self.products = [];

        // get all products
        AppModels.product().all().then(function (items) {
            self.products = items || [];
        });

        self.analyze = function () {

        };

        self.knapsack = function () {

        };


    }
})(window.angular);
