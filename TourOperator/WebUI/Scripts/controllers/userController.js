
var userController = function($scope, $routeParams, $location, $http) {
    $scope.addForm = {
        id: 0,
        name: '',
        email: '',
        password: '',
        isAdmin: false,
        returnUrl: $routeParams.returnUrl
    };
    $scope.fillForm = function (model, isAdmin) {
        $scope.addForm.name = model.Name;
        $scope.addForm.email = model.Email;
        $scope.addForm.password = model.Password;
        $scope.addForm.isAdmin = isAdmin;
        $scope.addForm.id = model.Id;
    }

    $scope.add = function () {
        var roles = ['USER'];
        if ($scope.addForm.isAdmin) {
            roles.push('ADMIN');
        }
        chooseNavbarItem();
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

    $scope.save = function () {
        var roles = ['USER'];
        if ($scope.addForm.isAdmin) {
            roles.push('ADMIN');
        }
        chooseNavbarItem();
        $http.post(
            '/User/EditUser', {
                Email: $scope.addForm.email,
                Password: $scope.addForm.password,
                Name: $scope.addForm.name,
                Roles: roles,
                Id: $scope.addForm.id
            })
            .success(function (data) {
                if ($scope.addForm.returnUrl === undefined) {
                    $location.path('/');
                } else {
                    $location.path($scope.addForm.returnUrl);
                }
            })
            .error(function (error) {
                console.error(error);
            });
    }

    $scope.remove = function(id) {
        $http.post(
                '/User/RemoveUser', {
                    id: id
                })
            .success(function(data) {
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