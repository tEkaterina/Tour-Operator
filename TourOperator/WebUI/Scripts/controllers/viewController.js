var viewController = function($scope, $http) {
    $scope.isViewLoading = false;

    $scope.$on('$routeChangeStart', function() {
        $scope.isViewLoading = true;
        var viewDiv = document.getElementById('viewDiv');
        if (viewDiv != null) {
            viewDiv.innerHTML = '';
        }
    });
    $scope.$on('$routeChangeSuccess', function() {
        $scope.isViewLoading = false;
    });
    $scope.$on('$routeChangeError', function() {
        $scope.isViewLoading = false;
    });

}
viewController.$inject = ['$scope', '$http'];