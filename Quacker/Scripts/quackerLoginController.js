(function () {
	angular.module('quackerApp').controller('LoginController', ['constants', '$scope', '$cookies', function (constants, $scope, $cookies) {
		var _this = this;

		_this.name = function (value) {
			if (arguments.length) {
				$cookies.put(constants.userName, value);
			}
			else {
				return $cookies.get(constants.userName);
			}
		};

		_this.hasUserName = function () {
			return _this.name() ? true : false;
		};
	}]);
})();