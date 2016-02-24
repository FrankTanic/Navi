var navigatorApp = angular.module('navigatorApp', [
  'ngRoute',
  'navigatorControllers'
]);


navigatorApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/locations', {
            templateUrl: 'Partials/location-list.html',
            controller: 'LocationListCtrl'
        }).
        otherwise({
            redirectTo: '/locations'
        });
  }]);