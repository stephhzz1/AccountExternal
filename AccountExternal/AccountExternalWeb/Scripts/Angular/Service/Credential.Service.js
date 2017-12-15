(function () {
    'use strict';

    angular
        .module('App')
        .factory('CredentialService', CredentialService);

    CredentialService.$inject = ['$http'];

    function CredentialService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Credential/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(credentialId) {
            return $http({
                method: 'DELETE',
                url: '/Credential/Delete/' + credentialId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();