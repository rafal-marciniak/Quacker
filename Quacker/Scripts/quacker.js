(function () {
	angular.module('quackerApp', ['ngRoute', 'ngCookies', 'quackerDirectives'])
	.constant('constants', {
		userName: 'quackerUserName',
	})
	.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
		//$locationProvider.html5Mode(true);

		$routeProvider
			.when('/', {
				redirectTo: '/login'
			})
			.when('/login', {
				templateUrl: '/Template/Login',
				controller: 'LoginController',
				controllerAs: 'loginCtrl'
			})
			.when('/dashboard', {
				templateUrl: '/Template/Dashboard',
				controller: 'DashboardController',
				controllerAs: 'dashboardCtrl'
			})
			.otherwise({
				templateUrl: '/Template/Error404'
			});

		//initialize get if it isn't there
		if (!$httpProvider.defaults.headers.get) {
			$httpProvider.defaults.headers.get = {};
		}

		//disable IE ajax request caching
		$httpProvider.defaults.headers.get['If-Modified-Since'] = '0';
		//$httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
		//$httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
	}]);
})();