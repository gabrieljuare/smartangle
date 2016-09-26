/// <reference path="jquery-1.7.1.js" />
/// <reference path="angular.js" />

smartAngleApp.controller('loginController', function ($scope, $location, $rootScope, $http) {
    $scope.submit = function () {
        var clave = $scope.clave;
        var email = $scope.email;
        var solicitudLogin = {
            method: "GET",
            url: $rootScope.SmartApiUri + '/api/usuario/autenticacion?login=true',
            headers: {
                'Content-Type': "application/json",
                'email': email,
                'clave': clave
            }
        }

        $http(solicitudLogin)
            .then(function successCallback(response) {
                $rootScope.UsuarioActual = response.data;
                $scope.UsuarioActual = response.data;
                $rootScope.loggeado = true;
                $scope.loggeado = true;
                $location.path('/panelDeControl');
            }, function errorCallback(response) {
                alert("Error al iniciar");
            });
    }

});