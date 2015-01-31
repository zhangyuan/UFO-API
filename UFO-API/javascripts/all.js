var app = angular.module('app', []);

app.controller("ProductsController", [
    "$scope", function($scope) {
        $scope.products = [
            {name: "Subway"},
            { name: "Burger King" }
        ];
    }
]);


