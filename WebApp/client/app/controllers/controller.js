(function() {
    'use strict';

    angular.module('app.controllers').controller('BaseController', BaseController);

    BaseController.$inject = ['$rootScope'];
    function BaseController($rootScope) {
        var self = this;
        this.model = {};
        this.$rootScope = $rootScope;
        this.$rootScope.url = url;
    }

})(window.angular);
