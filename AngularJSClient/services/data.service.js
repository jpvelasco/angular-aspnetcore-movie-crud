(function () {

    'use strict';

    angular.module('movieApp')
        .factory('moviebus', moviebus)

    moviebus.$inject = ['$http'];

    function moviebus($http) {

        var apiEndpoint = "http://localhost:1479/"; // TODO: Update to use the root location of your Web API

        $http.defaults.useXDomain = true;
        delete $http.defaults.headers.common['X-Requested-With'];

        return {
            getItems: function () {
                var request = $http({
                    method: 'GET',
                    url: apiEndpoint + 'api/movies'
                });
                return (request
                    .then(function success(response) {
                        return (response.data);
                    }, function error(response) {
                        return ($q.reject(response.data.message));
                    }));
            },

            getItem: function (id) {
                return $http.get(apiEndpoint + 'api/movies/' + id)
                    .then(function success(response) {
                        return (response.data);
                    }, function error(response) {
                        return ($q.reject(response.data.message));
                    });
            },

            postItem: function (item) {
                var request =
                    {
                        Id: item.id,
                        Title: item.title,
                        ReleaseYear: item.releaseYear,
                        Director: item.director,
                        Description: item.description,
                        Genre: item.genre
                    };

                return $http.post(apiEndpoint + 'api/movies/', request)
                    .then(function success(response) {
                        return (response.data);
                    }, function error(response) {
                        return ($q.reject(response.data.message));
                    });
            },

            putItem: function (item) {
                var request =
                    {
                        Id: item.id,
                        Title: item.title,
                        ReleaseYear: item.releaseYear,
                        Director: item.director,
                        Description: item.description,
                        Genre: item.genre
                    };

                return $http.put(apiEndpoint + 'api/movies/', request)
                    .then(function success(response) {
                        return (response.data);
                    }, function error(response) {
                        return ($q.reject(response.data.message));
                    });
            },

            deleteItem: function (id) {
                return $http({
                    method: 'DELETE',
                    url: apiEndpoint + 'api/movies/' + id,
                }).then(
                    function success(response) {
                        return (response.data);
                    }, function error(response) {
                        return ($q.reject(response.data.message));
                    });
            }
        };
    }

})();