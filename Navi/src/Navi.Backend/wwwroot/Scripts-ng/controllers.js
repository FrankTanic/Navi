var navigatorControllers = angular.module('navigatorControllers', []);

navigatorControllers.service('dataService', function ($http) {
this.getData = function() {
    return $http({
        method: 'GET',
        url: 'http://localhost:59184/api/locations',
     });
 }
});

navigatorControllers.controller('LocationListCtrl', function ($scope, dataService) {
    $scope.locations = null;
    dataService.getData().then(function(dataResponse) {
        $scope.locations = dataResponse;
    });
});

navigatorControllers.controller('CreateCtrl', function ($scope, dataService) {
    window.initialize();
});