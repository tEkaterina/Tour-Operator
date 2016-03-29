var tourOperatorApp = angular.module('tourOperatorApp', ['ngRoute']);

tourOperatorApp.controller('userController', userController);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/user/', {
            templateUrl: function () {
                chooseNavbarItem(document.getElementById('newUser'));
                return '/User/AddUser';
            }
        })
        .when('/users/', {
            templateUrl: function (params) {
                chooseNavbarItem(document.getElementById('allUsers'));
                return '/User/GetAllUsers/';
            }
        })
        .when('/customer/', {
                templateUrl: function() {
                    chooseNavbarItem(document.getElementById('newCustomer'));
                    return '/Customer/AddCustomer';
                }
            })
    ;
}
configFunction.$inject = ['$routeProvider'];

tourOperatorApp.config(configFunction);

var chooseNavbarItem = function (item) {
    var navbar = document
        .getElementById('navbar')
        .getElementsByTagName('li');

    $(navbar).each(function () {
        $(this).removeClass('active');
    });
    $(item).addClass('active');
}