(function(){
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
		});
})();
