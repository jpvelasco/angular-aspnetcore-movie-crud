(function () {

    'use strict';

    angular
        .module('movieApp')
        .controller('MovieViewController', MovieViewController);

    MovieViewController.$inject = ['$scope', '$stateParams', 'moviebus'];

    function MovieViewController($scope, $stateParams, moviebus) {

        moviebus.getItem($stateParams.id).then(function (data) {
            $scope.movie = data;
        });
    }
})();