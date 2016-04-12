var cityController = function ($scope, $routeParams, $location, $http) {
    $scope.cities = [];
    $scope.fillCities = function () {
        $http.get('/City/GetAll', {})
            .success(function (data) {
                $scope.cities = data;
            })
            .error(function (error) {
                console.error(error);
            });
    };
    $scope.fillCities();

    $scope.addCity = function (name) {
        $http.post(
               '/City/Add', { city: name })
           .success(function (data) {
               $scope.fillCities();
           })
           .error(function (error) {
               console.error(error);
           });
    }
}

cityController.$inject = ['$scope', '$routeParams', '$location', '$http'];