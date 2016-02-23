var navigatorApp = angular.module('navigatorApp', []);

navigatorApp.service('dataService', function ($http) {
delete $http.defaults.headers.common['X-Requested-With'];
this.getData = function() {
    // $http() returns a $promise that we can add handlers with .then()
    return $http({
        method: 'GET',
        url: 'http://localhost:59184/api/location',
     });
 }
});

navigatorApp.controller('LocationListCtrl', function ($scope, dataService) {
    $scope.data = null;
    dataService.getData().then(function(dataResponse) {
        $scope.data = dataResponse;
    });
});