var navigatorApp = angular.module('navigatorApp', []);

navigatorApp.service('dataService', function ($http) {
this.getData = function() {
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