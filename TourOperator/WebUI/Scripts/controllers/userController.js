
var userController = function($scope, $routeParams, $location, $http) {
    $scope.addForm = {
        name: '',
        email: '',
        password: '',
        isAdmin: false,
        returnUrl: $routeParams.returnUrl
    };

    $scope.add = function () {
        var roles = ['USER'];
        if ($scope.addForm.isAdmin) {
            roles.push('ADMIN');
        }
        $http.post(
            '/User/AddUser', {
                    Email: $scope.addForm.email,
                    Password: $scope.addForm.password,
                    Name: $scope.addForm.name,
                    Roles: roles
                })
            .success(function (data) {
                if ($scope.addForm.returnUrl === undefined) {
                    $location.path('/');
                } else {
                    $location.path($scope.addForm.returnUrl);
                }
            })
            .error(function(error) {
                console.error(error);
            });
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
userController.$inject = ['$scope', '$routeParams', '$location', '$http'];