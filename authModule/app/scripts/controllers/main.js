'use strict';

/**
 * @ngdoc function
 * @name nglarApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the nglarApp
 */
angular.module('nglarApp')
  .controller('MainCtrl', function ($scope) {
      $scope.awesomeThings = [
        'HTML5 Boilerplate',
        'AngularJS',
        'Karma'
      ];
  });

