(function () {
	var quackerApp = angular.module('quackerApp', ['ngRoute', 'ngCookies', 'quackerDirectives']);

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
			})
			.otherwise({
				templateUrl: '/Template/Error404'
			});

		//$locationProvider.html5Mode(true);
	}]);

	quackerApp.controller('LoginController', ['$scope', '$cookies', function ($scope, $cookies) {
		var _this = this;
		var nameMapping = 'quackerName';

		_this.name = function (value) {
			if (arguments.length) {
				$cookies.put(nameMapping, value);
			}
			else {
				return $cookies.get(nameMapping);
			}
		};

		_this.hasUserName = function () {
			if (_this.name()) {
				return true;
			}

			return false;
		};

	}]);

	quackerApp.controller('DashboardController', ['$scope', '$http', '$cookies', function ($scope, $http, $cookies) {	
		var _this = this;
		var nameMapping = 'quackerName';
		_this.quacks = [];

		$http.get('/Quacker/Get').then(function (response) {
			_this.quacks = response.data;
		});

		_this.showReplies = function (quack) {
			var idToCollapse = '#collapse' + quack.QuackId;
			$(idToCollapse).collapse('toggle');

			if (!quack.Replies) {			
				$http.get('/Quacker/Get/' + quack.QuackId).then(function (response) {
					quack.Replies = response.data;
				});
			}
		};

		_this.postQuack = function (quack) {
			var authorName = $cookies.get(nameMapping);
			if (authorName) {
				quack.AuthorName = authorName;

				$http.post('/Quacker/Add', { quack: quack }).then(function (response) {
					var serverQuack = response.data;

					if (serverQuack.ParentQuackId) {
						var parentQuack = $.grep(_this.quacks, function (quack, index) { return quack.QuackId == serverQuack.ParentQuackId; })[0];

						if (parentQuack && parentQuack.Replies) {
							parentQuack.Replies.push(serverQuack);
						}
					}
					else {
						_this.quacks.unshift(serverQuack);
					}
				});
			}
		};
	}]);




	///////////////////////////////////////////////////// DIRECTIVES /////////////////////////////////////////////////////
	angular.module('quackerDirectives', [])
		.directive('quackForm', function () {
			return {
				restrict: 'E',
				scope: {
					parentQuackId: '=',
					onPost: '&'
				},
				templateUrl: '/Template/QuackForm',
				controller: ['$scope', function ($scope) {
					$scope.quack = { ParentQuackId: $scope.parentQuackId };
					$scope.formName = 'quackForm' + $scope.parentQuackId;
				}]
		};
	});

})();