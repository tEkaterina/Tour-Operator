
var customerController = function ($scope, $routeParams, $location, $http) {
    $scope.addForm = {
        surname:'',
        name:'',
        patronymic:'',

        birthdate: new Date(),
        sex:'',

        passportCode:'',
        passportNumber:'',
        passportIssuePlace:'',
        passportIssueDate: '',
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

        returnUrl: $routeParams.returnUrl,
    };
    
    $scope.customerId = 0;

    $scope.fillForm = function (model) {
        
        $scope.addForm.surname = model.Surname;
        $scope.addForm.name = model.Name;
        $scope.addForm.patronymic = model.Patronymic;

        $scope.addForm.birthdate = $scope.parseDate(model.Birthdate);
        console.log(model.Sex);
        if (model.Sex == 'M') {
            var male = document.getElementById('male');
            male.checked = true;
        } else {
            var female = document.getElementById('female');
            female.checked = true;
        }
        $scope.addForm.sex = model.Sex;
        
        $scope.addForm.passportCode = model.PassportCode;
        $scope.addForm.passportNumber = model.PassportNumber;
        $scope.addForm.passportIssuePlace = model.PassportIssuePlace;
        $scope.addForm.passportIssueDate = model.PassportIssueDate;
        $scope.addForm.id = model.PassportId;

        $scope.addForm.birthplace = model.BirthPlace;

        $scope.addForm.city = model.City;
        $scope.addForm.address = model.Address;
        $scope.addForm.mobilePhone = model.MobilePhone;
        $scope.addForm.homePhone = model.HomePhone;
        $scope.addForm.email = model.Email;

        $scope.addForm.maritalStatus = model.MaritalStatus;
        $scope.addForm.citizenship = model.Citizenship;
        $scope.addForm.disability = model.Disability;
        $scope.addForm.pensioner = model.Pensioner;
        $scope.addForm.reservist = model.Reservist;

        $scope.addForm.salary = model.Salary;

        $scope.customerId = model.Id;
    }

    $scope.add = function () {
        $scope.customerId = 0;
        $scope.excecuteSaveQuery('/Customer/AddCustomer');
    }

    $scope.save = function () {
        $scope.excecuteSaveQuery('/Customer/EditCustomer');
    }

    $scope.excecuteSaveQuery = function(url) {
        if (document.getElementById('male').checked) {
            $scope.addForm.sex = 'M';
        } else {
            $scope.addForm.sex = 'F';
        }
        chooseNavbarItem();
        $http.post(url, {
                Id: $scope.customerId,

                Surname: $scope.addForm.surname,
                Name: $scope.addForm.name,
                Patronymic: $scope.addForm.patronymic,

                Birthdate: $scope.addForm.birthdate,
                Sex: $scope.addForm.sex,

                PassportCode: $scope.addForm.passportCode,
                PassportNumber: $scope.addForm.passportNumber,
                PassportIssueplace: $scope.addForm.passportIssuePlace,
                PassportIssueDate: $scope.addForm.passportIssueDate,
                PassportId: $scope.addForm.id,

                Birthplace: $scope.addForm.birthplace,

                City: $scope.addForm.city,
                Address: $scope.addForm.address,
                MobilePhone: $scope.addForm.mobilePhone,
                HomePhone: $scope.addForm.homePhone,
                Email: $scope.addForm.email,

                MaritalStatus: $scope.addForm.maritalStatus,
                Citizenship: $scope.addForm.citizenship,
                Disability: $scope.addForm.disability,
                Pensioner: $scope.addForm.pensioner,
                Reservist: $scope.addForm.reservist,

                Salary: +($scope.addForm.salary)
            })
            .success(function (data) {
                if ($scope.addForm.returnUrl === undefined) {
                    $location.path('/');
                } else {
                    $location.path($scope.addForm.returnUrl);
                }
                window.location.reload();
            })
            .error(function (error) {
                console.error(error);
            });
    }

    $scope.remove = function(id) {
        $http.post('/Customer/Remove', { id: id })
            .success(function(data) {
                $location.path('/customers');
            })
            .error(function(error) {
                console.error(error);
            });
    };

    $scope.isDisabledDate = function (currentDate, mode) {
        return mode === 'day' && (currentDate.getDay() === 0 || currentDate.getDay() === 6);
    };

    $scope.datePickers = {
        birthdateIsOpened: false,
        birthdateOpen: function() {
            $scope.datePickers.birthdateIsOpened = true;
        },
        passportIsOpened: false,
        passportOpen: function() {
            $scope.datePickers.passportIsOpened = true;
        }
    }

    $scope.parseDate = function(strDate){
        var dateParts = strDate.split(".");
        return new Date(dateParts[2], (dateParts[1] - 1), dateParts[0]);
    };
}

customerController.$inject= ['$scope', '$routeParams', '$location', '$http'];