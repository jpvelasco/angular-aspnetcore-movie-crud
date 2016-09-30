(function () {

    'use strict';

    angular
        .module('movieApp')
        .controller('MovieEditController', MovieEditController);


    MovieEditController.$inject = ['$scope', '$state', '$stateParams', 'moviebus'];


    function MovieEditController($scope, $state, $stateParams, moviebus) {

        $scope.updateMovie = function () {
            moviebus.putItem($scope.movie).then(function () {
                $state.go('movies');
            });
        };

        $scope.loadMovie = function () {
            moviebus.getItem($stateParams.id).then(function (data) {
                $scope.movie = data;
            });

        };

        $scope.loadMovie();
    }

})();