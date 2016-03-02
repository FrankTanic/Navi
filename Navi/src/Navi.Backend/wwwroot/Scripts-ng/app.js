var navigatorApp = angular.module('navigatorApp', [
  'ngRoute',
  'navigatorControllers'
]);

navigatorApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/locations', {
            templateUrl: 'Partials/location-list.html',
            controller: 'locationListCtrl'
        }).
        when('/create', {
            templateUrl: 'CreateLocation/create.html',
            controller: 'createCtrl'
        }).
        when('/radius', {
            templateUrl: 'CreateLocation/radius.html',
            controller: 'radiusCtrl'
        }).
        otherwise({
            redirectTo: '/locations'
        });
  }]);