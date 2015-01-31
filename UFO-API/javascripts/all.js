var app = angular.module('app', []);

app.controller("ProductsController", [
    "$scope", "$http", function ($scope, $http) {
        $http.get("/api/products").success(function(data) {
            $scope.products = data;
        });
    }
]);


