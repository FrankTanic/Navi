var navigatorApp = angular.module('navigatorApp', []);

navigatorApp.controller('LocationListCtrl', function ($scope) {
    $scope.locations = [
      {
          'name': 'BLiS',
          'description': 'Where the cool kids roam.',
          'coords': 'None jet.'
      },
      {
          'name': 'Microsoft',
          'description': 'You love them or you hate them.',
          'coords': 'None jet.'
      },
      {
          'name': 'Those people from Iphone and stuff',
          'description': 'Heard the cult leader passed away recently.',
          'coords': 'None jet.'
      }
    ];
});