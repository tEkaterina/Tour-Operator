var infrastructureController = function($scope, $http) {
    $scope.citizenships = [];
    $scope.getCitizenships = function() {
        $http.get(
                '/Infrastructure/GetAllCitizenships', {})
            .success(function(data) {
                $scope.citizenships = data;
            })
            .error(function(error) {
                console.error(error);
            });
    }
    $scope.getCitizenships();

    $scope.disabilities = [];
    $scope.getDisabilities = function () {
        $http.get(
                '/Infrastructure/GetAllDisabilities', {})
            .success(function (data) {
                $scope.disabilities = data;
            })
            .error(function (error) {
                console.error(error);
            });
    }
    $scope.getDisabilities();

    $scope.maritalStatuses = [];
    $scope.getMaritalStatuses = function () {
        $http.get(
                '/Infrastructure/GetAllMaritalStatuses', {})
            .success(function (data) {
                $scope.maritalStatuses = data;
            })
            .error(function (error) {
                console.error(error);
            });
    }
    $scope.getMaritalStatuses();
}

infrastructureController.$inject = ['$scope', '$http'];