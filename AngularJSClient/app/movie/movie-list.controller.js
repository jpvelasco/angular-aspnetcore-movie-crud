(function () {

    'use strict';

    angular
        .module('movieApp')
        .controller('MovieListController', MovieListController);

    MovieListController.$inject = ['$scope', '$state', 'popupService', '$window', 'moviebus'];

    function MovieListController($scope, $state, popupService, $window, moviebus) {

        moviebus.getItems().then(function (data) {
            $scope.movies = data;
        });

        $scope.deleteMovie = function (movie) {
            if (popupService.showPopup('Do you really want to delete this?')) {

                // Delete
                moviebus.deleteItem(movie.id).then(function () {
                    $window.location.href = '';
                });
            }
        }
    }
})();