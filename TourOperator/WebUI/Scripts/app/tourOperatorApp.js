var tourOperatorApp = angular.module('tourOperatorApp', ["ngRoute", "ui.bootstrap"]);

tourOperatorApp.controller('userController', userController);
tourOperatorApp.controller('customerController', customerController);
tourOperatorApp.controller('viewController', viewController);
tourOperatorApp.controller('cityController', cityController);
tourOperatorApp.controller('infrastructureController', infrastructureController);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/user', {
            templateUrl: function() {
                chooseNavbarItem(document.getElementById('newUser'));
                return '/User/AddUser';
            }
        })
        .when('/users', {
            templateUrl: function(params) {
                chooseNavbarItem(document.getElementById('allUsers'));
                return '/User/GetAllUsers';
            }
        })
        .when('/user/edit/:id', {
            templateUrl: function (params) { return '/User/EditUser?id=' + params.id; }
        })
        .when('/customer', {
            templateUrl: function() {
                chooseNavbarItem(document.getElementById('newCustomer'));
                return '/Customer/AddCustomer';
            }
        })
        .when('/customer/:id', {
            templateUrl: function (params) { return '/Customer/GetCustomer?id=' + params.id; }
        })
        .when('/customer/edit/:id', {
            templateUrl: function (params) { return '/Customer/EditCustomer?id=' + params.id; }
        })
        .when('/customers', {
            templateUrl: function() {
                chooseNavbarItem(document.getElementById('allCustomers'));
                return '/Customer/GetAllCustomers';
            }
        });
}
configFunction.$inject = ['$routeProvider'];

tourOperatorApp.config(configFunction);

var chooseNavbarItem = function (item) {
    var navbar = document
        .getElementById('navbar')
        .getElementsByTagName('li');
    var activeBtnClass = 'active';

    $(navbar).each(function () {
        $(this).removeClass(activeBtnClass);
    });
    $(item).addClass(activeBtnClass);
}