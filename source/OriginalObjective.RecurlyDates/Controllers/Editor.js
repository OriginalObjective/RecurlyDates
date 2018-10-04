angular.module("umbraco").controller("OriginalObjective.RecurlyDates", function ($scope) {

    var vm = this;

    vm.parseDailyRecurrencePattern = function (dailyRecurrencePattern) {
        var retval = [];
        
        if (dailyRecurrencePattern[0] === true) {
            retval.push("sunday");
        }
        if (dailyRecurrencePattern[1] === true) {
            retval.push("monday");
        }
        if (dailyRecurrencePattern[2] === true) {
            retval.push("tuesday");
        }
        if (dailyRecurrencePattern[3] === true) {
            retval.push("wednesday");
        }
        if (dailyRecurrencePattern[4] === true) {
            retval.push("thursday");
        }
        if (dailyRecurrencePattern[5] === true) {
            retval.push("friday");
        }
        if (dailyRecurrencePattern[6] === true) {
            retval.push("saturday");
        }

        return retval;
    };

    $scope.model.value = $scope.model.value || {
        startDate: new Date(new Date().setHours(0, 0, 0, 0)),
        endDate: new Date(new Date().setHours(0, 0, 0, 0)),
        recurrence: null,
        weeklyRecurrencePattern: 1,
        dailyRecurrencePattern: [false, false, false, false, false, false, false],
        recurrenceType: null,
        recurrencePatternSpecificer: "First",
        dayTypeSpecifier: "Monday",
        month: 1
    };

    $scope.startDatePicker = {
        view: "datepicker",
        config: {
            pickDate: true,
            pickTime: false,
            useSeconds: true,
            format: "YYYY-MM-DD",
            icons: {
                time: "icon-time",
                date: "icon-calendar",
                up: "icon-chevron-up",
                down: "icon-chevron-down"
            }
        },
        value: $scope.model.value.startDate
    };

    $scope.endDatePicker = {
        view: "datepicker",
        config: {
            pickDate: true,
            pickTime: false,
            useSeconds: true,
            format: "YYYY-MM-DD",
            icons: {
                time: "icon-time",
                date: "icon-calendar",
                up: "icon-chevron-up",
                down: "icon-chevron-down"
            }
        },
        value: $scope.model.value.endDate
    };

    $scope.recurrencePicker = {
        view: "radiobuttons",
        config: {
            items: {
                none: { value: "None" },
                daily: { value: "Daily" },
                weekly: { value: "Weekly" },
                monthly: { value: "Monthly" },
                annually: { value: "Annually" }
            }
        },
        value: $scope.model.value.recurrence
    }

    $scope.weeklyRecurrencePatternPicker = {
        view: "dropdown",
        config: {
            items: [1, 2, 3, 4, 5],
            multiple: false
        },
        value: $scope.model.value.weeklyRecurrencePattern
    }

    $scope.dailyRecurrencePatternPicker = {
        view: "checkboxlist",
        config: {
            items: {
                monday: { value: "Monday" },
                tuesday: { value: "Tuesday" },
                wednesday: { value: "Wednesday" },
                thursday: { value: "Thursday" },
                friday: { value: "Friday" },
                saturday: { value: "Saturday" },
                sunday: { value: "Sunday" }
            }
        },
        value: vm.parseDailyRecurrencePattern($scope.model.value.dailyRecurrencePattern)
    }

    $scope.recurrenceTypePicker = {
        view: "radiobuttons",
        config: {
            items: {
                useStartDate: { value: "Use Start Date" },
                usePattern: { value: "Use Pattern" }
            }
        },
        value: $scope.model.value.recurrenceType
    }

    $scope.recurrencePatternSpecificerPicker = {
        view: "dropdown",
        config: {
            items: {
                first: "First",
                second: "Second",
                third: "Third",
                fourth: "Fourth",
                fifth: "Fifth",
                last: "Last"
            },
            multiple: false
        },
        value: $scope.model.value.recurrencePatternSpecificer
    }

    $scope.dayTypeSpecifierPicker = {
        view: "dropdown",
        config: {
            items: {
                monday: "Monday",
                tuesday: "Tuesday",
                wednesday: "Wednesday",
                thursday: "Thursday",
                friday: "Friday",
                saturday: "Saturday",
                sunday: "Sunday",
                weekDay: "Week Day",
                weekendDay: "Weekend Day"
            },
            multiple: false
        },
        value: $scope.model.value.dayTypeSpecifier
    }

    $scope.monthPicker = {
        view: "dropdown",
        config: {
            items: {
                1: "January",
                2: "February",
                3: "March",
                4: "April",
                5: "May",
                6: "June",
                7: "July",
                8: "August",
                9: "September",
                10: "October",
                11: "November",
                12: "December"
            },
            multiple: false
        },
        value: $scope.model.value.month
    }

    $scope.$watch("startDatePicker.value",
        function () {
            $scope.model.value.startDate = $scope.startDatePicker.value;
        });

    $scope.$watch("endDatePicker.value",
        function () {
            $scope.model.value.endDate = $scope.endDatePicker.value;
        });

    $scope.$watch("recurrencePicker.value",
        function () {
            $scope.model.value.recurrence = $scope.recurrencePicker.value;
        });

    $scope.$watch("weeklyRecurrencePatternPicker.value",
        function () {
            $scope.model.value.weeklyRecurrencePattern = $scope.weeklyRecurrencePatternPicker.value;
        });

    $scope.$watch("dailyRecurrencePatternPicker.value",
        function () {
            $scope.model.value.dailyRecurrencePattern = [false, false, false, false, false, false, false];
            
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("sunday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[0] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("monday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[1] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("tuesday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[2] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("wednesday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[3] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("thursday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[4] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("friday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[5] = true;
            }
            if ($scope.dailyRecurrencePatternPicker.value.indexOf("saturday") !== -1) {
                $scope.model.value.dailyRecurrencePattern[6] = true;
            }
        });

    $scope.$watch("recurrenceTypePicker.value",
        function () {
            $scope.model.value.recurrenceType = $scope.recurrenceTypePicker.value;
        });

    $scope.$watch("recurrencePatternSpecificerPicker.value",
        function () {
            $scope.model.value.recurrencePatternSpecificer = $scope.recurrencePatternSpecificerPicker.value;
        });

    $scope.$watch("dayTypeSpecifierPicker.value",
        function () {
            $scope.model.value.dayTypeSpecifier = $scope.dayTypeSpecifierPicker.value;
        });

    $scope.$watch("monthPicker.value",
        function () {
            $scope.model.value.month = $scope.monthPicker.value;
        });
});