(function(){
	angular.module('quackerDirectives', [])
		.directive('quackForm', function () {
			return {
				restrict: 'E',
				scope: {
					labelText: '@',
					parentQuackId: '=',
					onPost: '&'
				},
				templateUrl: '/Template/QuackForm',
				controller: ['$scope', function ($scope) {
					$scope.quack = { ParentQuackId: $scope.parentQuackId };
					$scope.formName = 'quackForm' + $scope.parentQuackId;
					$scope.onPostCallback = function () {
						$scope.quack = {};
					};
				}]
			};
		});
})();