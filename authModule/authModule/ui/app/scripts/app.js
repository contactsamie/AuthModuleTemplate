'use strict';

/**
 * @ngdoc overview
 * @name nglarApp
 * @description
 * # nglarApp
 *
 * Main module of the application.
 */
angular
  .module('nglarApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'angularMoment',
    'ngTable',
    'xeditable'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  }).run(function(editableOptions) {
      editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'

      (function ($) {
          $.fn.autosubmit = function () {
              this.submit(function (event) {
                  var form = $(this);
                  $.ajax({
                      type: form.attr('method'),
                      url: form.attr('action'),
                      data: form.serialize()
                  }).done(function (r, e, s) {
                      console.log(r);
                      console.log("success");
                  }).fail(function (r, e, s) {
                      console.log(r);
                      console.log("fail");
                  });
                  event.preventDefault();
              });
          };
      })(jQuery);

  });