(function() {
    'use strict';

    angular.module('app.controllers').controller('ProductController', ProductController);

    ProductController.$inject = ['AppServices'];
    function ProductController(AppServices) {
        var self = this;
        this.productList = [];
        this.productListCache = [];
        this.model = {
            weight: null,
            productId: null,
            price: null
        };

        this.init = function () {
            self.getProductList();
        };
        this.getProductList = function() {
            $.when(AppServices.getProductList())
            .done(function (res) {
                self.productListCache = angular.fromJson(res)
            })
            .fail();
        };

        this.analyze = function () {
            if (!self.model.weight) {
                return;
            }

            self.productList = self.knapsack();
        };

        this.knapsack = function () {
            var n = self.productListCache.length;
            var store = {}, i = 0, j = 0, items = [];

            for (i = 0; i <= self.model.weight; i++) {
                store[0 + '-' + i] = 0;
            }

            for (i = 1; i <= n; i++) {
                for (j = 0; j <= self.model.weight; j++) {
                    if (self.productListCache[i - 1].Weight > j) {
                        store[i + '-' + j] = store[(i - 1) + '-' + j];
                    } else {
                        store[i + '-' + j] = Math.max(store[(i - 1) + '-' + j], store[(i - 1) + '-' + (j - self.productListCache[i - 1].Weight)] + self.productListCache[i - 1].Price);
                    }
                }
            }

            i = n; var w = self.model.weight;

            while (i > 0 && w > 0) {
                if (store[i + '-' + w] != store[(i - 1) + '-' + w]) {
                    var item = angular.copy(self.productListCache[i - 1]);
                    item.Qty = 1;
                    items.push(item);
                    w = w - self.productListCache[i - 1].Weight;
                }
                i--;
            }
            return items;
        };
    }

})(window.angular);
