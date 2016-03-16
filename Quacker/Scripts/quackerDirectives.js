(function () {
	angular.module('quackerDirectives', [])
		.directive('quackForm', function () {
			return {
				restrict: 'E',
				scope: {
					labelText: '@',
					parentQuackId: '@',
					onPost: '&'
				},
				templateUrl: '/Template/QuackForm',
				controller: ['$scope', function ($scope) {
					$scope.createQuack = function () {
						$scope.quack = { ParentQuackId: $scope.parentQuackId };
					};

					$scope.formName = 'quackForm' + $scope.parentQuackId;
					$scope.createQuack();
					$scope.onPostCallback = function () {
						$scope.createQuack();
					};
				}]
			};
		})

		.directive('quackDetails', function () {
			return {
				restrict: 'E',
				scope: {
					quack: '='
				},
				templateUrl: '/Template/QuackDetails',
				controller: ['$scope', function ($scope) {
					$scope.getQuackCreationRelativeDate = function () {
						return moment($scope.quack.CreationDate).fromNow();
					};
				}]
			};
		});
})();
