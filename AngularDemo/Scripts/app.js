var app = angular.module('app', ['ngResource', 'ngRoute']).config(function ($routeProvider) {
    $routeProvider.when('/', {
        controller: HomeController,
        templateUrl: 'template/home.html'
    }).when('/edit/:person', {
        controller: EditController,
        templateUrl: 'template/edit.html'
    }).otherwise({ redirectTo: '/' });
});

var HomeController = function ($scope, $http) {
    $scope.data = [];

    $http({
        url: 'api/getdata',
        method: "GET",
    }).success(function (data) {
        var deserializedJsonString = angular.fromJson(data);
        var javaScriptObject = $.parseJSON(deserializedJsonString);
        $scope.data = javaScriptObject;
    });
};

var EditController = function ($scope, $http, $routeParams) {
    $scope.data = [];

    $http({
        url: 'api/getdata',
        method: "GET",
    }).success(function (data) {
        var deserializedJsonString = angular.fromJson(data);
        var javaScriptObject = $.parseJSON(deserializedJsonString);
        var personData = javaScriptObject.contacts.contact[$routeParams.person];
        $scope.data = javaScriptObject;
        $scope.person = personData;
    });

    $scope.exportPerson = function (exportData) {
        $http({
            url: 'api/exportdata',
            method: "POST",
            data: exportData
        }).success(function () {
            alert("Your data has been exported!")
        });
    };
    
    $scope.eventLog = function (dataToLog) {
        $http({
            url: 'api/windowseventlog',
            method: "POST",
            data: dataToLog
        }).success(function () {
            alert("Your data has been logged!")
        });
    };
};