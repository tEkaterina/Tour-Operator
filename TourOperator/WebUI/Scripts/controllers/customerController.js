
var customerController = function ($scope, $routeParams, $location, $http) {
    $scope.addForm = {
        surname:'',
        name:'',
        patronymic:'',

        birthdate: '',
        sex:'',

        passportCode:'',
        passportNumber:'',
        passportIssuePlace:'',
        passportIssueDate:'',
        id:'',

        birthplace:'',

        city:'',
        address:'',
        mobilePhone:'',
        homePhone:'',
        email:'',

        maritalStatus:'',
        citizenship:'',
        disability:'',
        pensioner: false,
        reservist: false,

        salary: '',

        returnUrl: $routeParams.returnUrl
    };

    $scope.add = function () {
        console.log(document.getElementById('male').checked);
        if (document.getElementById('male').checked) {
            $scope.addForm.sex = 'M';
        } else {
            $scope.addForm.sex = 'F';
        }
        chooseNavbarItem();
        $http.post(
            '/Customer/AddCustomer', {
                Surname: $scope.addForm.surname,
                Name: $scope.addForm.name,
                Patronymic: $scope.addForm.patronymic,

                Birthdate: new Date($scope.addForm.birthdate),
                Sex: $scope.addForm.sex,

                PassportCode: $scope.addForm.passportCode,
                PassportNumber: $scope.addForm.passportNumber,
                PassportIssueplace: $scope.addForm.passportIssuePlace,
                PassportIssueDate: new Date($scope.addForm.passportIssueDate),
                Id: $scope.addForm.id,

                Birthplace: $scope.addForm.birthplace,

                City: $scope.addForm.city,
                Address: $scope.addForm.address,
                MobilePhone: $scope.addForm.mobilePhone,
                HomePhone: $scope.addForm.homePhone,
                Email: $scope.addForm.email,

                MaritalStatus: $scope.addForm.maritalStatus,
                Citizenship: $scope.addForm.citizenship,
                Disability: $scope.addForm.disability,
                Pensioner:  $scope.addForm.pensioner,
                Reservist: $scope.addForm.reservist,

                Salary: +($scope.addForm.salary)
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
}

customerController.$inject= ['$scope', '$routeParams', '$location', '$http'];