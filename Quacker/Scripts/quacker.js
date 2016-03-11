(function () {
	var quackerApp = angular.module('quackerApp', ['ngRoute']);

	// routing configuration
	quackerApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
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
			});
			//.otherwise({
		//	redirectTo: '/login'
			//});

		//$locationProvider.html5Mode(true);
	}]);

	quackerApp.controller('LoginController', ["$scope", function () {
		this.message = 'LoginController is here';
	}]);

	quackerApp.controller('DashboardController', function () {
		this.message = 'DashboardController is here';
	});

})();