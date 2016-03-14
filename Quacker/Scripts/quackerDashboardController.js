(function () {
	angular.module('quackerApp').controller('DashboardController', ['constants', '$scope', '$http', '$cookies', function (constants, $scope, $http, $cookies) {
		var _this = this;
		_this.quacks = [];
		_this.quacksNotLoaded = true;

		_this.loadQuacks = function () {
			$http.get('/Quacker/Get').then(function (response) {
				_this.quacksNotLoaded = false;
				_this.quacks = response.data;
			}, _this.handleError);
		}

		_this.loadReplies = function (quack) {
			if (!quack.Replies) {
				$http.get('/Quacker/Get/' + quack.QuackId).then(function (response) {
					quack.Replies = response.data;
				}, _this.handleError);
			}
		};

		_this.hasReplies = function (quack) {
			return quack.RepliesCount > 0;
		};

		_this.postQuack = function (quack, callback) {
			var authorName = $cookies.get(constants.userName);
			if (authorName) {
				quack.AuthorName = authorName;

				$http.post('/Quacker/Add', { quack: quack }).then(function success(response) {
					var serverQuack = response.data;

					if (serverQuack.ParentQuackId) {
						var parentQuack = $.grep(_this.quacks, function (quack, index) { return quack.QuackId == serverQuack.ParentQuackId; })[0];

						if (parentQuack) {
							if (parentQuack.Replies) {
								parentQuack.Replies.push(serverQuack);
							}

							parentQuack.RepliesCount++;
						}
					}
					else {
						_this.quacks.unshift(serverQuack);
					}

					callback();
				}, _this.handleError);
			}
		};

		_this.handleError = function (response) {
			window.alert('An error occured while processing your request'); // temporarily
		};

		_this.loadQuacks(); // load quacks at start
	}]);
})();