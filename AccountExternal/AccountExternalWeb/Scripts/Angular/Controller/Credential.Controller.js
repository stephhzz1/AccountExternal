(function () {
    'use strict';

    angular
        .module('App')
        .controller('CredentialController', CredentialController);

    CredentialController.$inject = ['$filter', '$window','EmployeeService', 'CredentialService'];

    function CredentialController($filter, $window, EmployeeService, CredentialService) {
        var vm = this;

        vm.Employees = [];
        vm.Credentials = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.UpdateEmployee = UpdateEmployee;

        vm.Delete = Delete;
        
        function GoToUpdatePage(credentialId) {
            $window.location.href = '../Credential/Update/' + credentialId;
        } 

        function Initialise() {
            Read();
            ReadEmployees();
        }

        function ReadEmployees() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Read() {
            CredentialService.Read()
                .then(function (response) {
                    vm.Credentials = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateEmployee(credential) {
            credential.Employee = $filter('filter')(vm.Employees, { EmployeeId: credential.EmployeeId })[0];
        }

        function Delete(credentialId) {
            CredentialService.Delete(credentialId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

    }
})();