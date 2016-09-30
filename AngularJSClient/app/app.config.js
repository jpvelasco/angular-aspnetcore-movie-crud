angular
    .module('movieApp')
    .config(function ($stateProvider, $httpProvider) {
        $stateProvider.state('movies', {
            url: '/movies',
            templateUrl: 'app/movie/movie-list.html',
            controller: 'MovieListController'
        }).state('viewMovie', {
            url: '/movies/:id/view',
            templateUrl: 'app/movie/movie-view.html',
            controller: 'MovieViewController'
        }).state('newMovie', {
            url: '/movies/new',
            templateUrl: 'app/movie/movie-create.html',
            controller: 'MovieCreateController'
        }).state('editMovie', {
            url: '/movies/:id/edit',
            templateUrl: 'app/movie/movie-edit.html',
            controller: 'MovieEditController'
        });
    }).run(function ($state) {
        $state.go('movies');
    });