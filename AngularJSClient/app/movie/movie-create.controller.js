(function () {

    'use strict';

    angular
        .module('movieApp')
        .controller('MovieCreateController', MovieCreateController);

    MovieCreateController.$inject = ['$scope', '$state', '$stateParams', 'moviebus'];

    function MovieCreateController($scope, $state, $stateParams, moviebus) {

        // $scope.movie = new Movie();
        $scope.movie = { title: "", releaseYear: "", director: "", genre: "" };

        $scope.addMovie = function () {

            moviebus.postItem($scope.movie).then(function () {
                $state.go('movies');
            });
        }
    }

})();