'use strict';

/**
 * @ngdoc function
 * @name nglarApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the nglarApp
 */
angular.module('nglarApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
