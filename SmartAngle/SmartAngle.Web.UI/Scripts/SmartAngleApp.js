var smartAngleApp = angular.module('SmartAngleApp', ['ngRoute'])
.run(function ($rootScope) {
    $rootScope.SmartApiUri = "http://localhost:17289";
    $rootScope.loggedIn = false;
});

smartAngleApp.config(['$routeProvider', '$locationProvider',
     function ($routeProvider, $locationProvider, $rootScope, $location) {
        $routeProvider.when('/', {
            templateUrl: '/home.html'
        }).when('/login', {
            templateUrl: '/login.html'
        }).when('/signUp', {
            templateUrl: '/createUser.html'
        }).when('/crearCuenta', {
            templateUrl: '/createUser.html'
        }).when('/panelDeControl', {
            templateUrl: '/dashboard.html'
        }).otherwise({
            redirectTo: '/',
            templateUrl: '/inicio'
        });

     }]);


