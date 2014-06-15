var timesheetData = {};

function timesheetPageBeforeShow() {
    timesheetData = getEmpListJSONMock();

    populateEmpList(timesheetData);

    var tableColHeader = ["Day of weeks", "Expected hours", "Actual hours"];
    tableColHeader.forEach(function (val) {
        $('<th>').append($('<span>').text(val)).appendTo('#timesheet thead tr');
    });

    $('#timesheet-table').tablesorter();

    $("#timesheet").on("click", "#employee-list a", function () {
        var empId = $(this).attr("data-emp-id");        
        displaySelectedEmp(timesheetData,empId);
    })
}

function timesheetPageShow() {
    // Display first record by default
    if (timesheetData.length > 0) {
        var firstEmpItem = timesheetData[0];
        displaySelectedEmp(timesheetData, firstEmpItem.Id);
    }
}

function populateEmpList(timesheetData) {
    $.each(timesheetData, function (i, v) {
        var name = $("<a>").attr({ "href": "", "data-emp-id": v.Id }).text(v.LastName + ", " + v.FirstName);
        var listItem = $("<li>").append(name);
        $("#employee-list").append(listItem);
    });

    $('#employee-list').listview('refresh');
}

function displaySelectedEmp(timesheetData, empId) {
    $("#timesheet-table tbody").empty();
    $("#timesheet-table").trigger("update");

    var empTimesheet = getObjects(timesheetData, 'Id', empId);

    if (empTimesheet.length != 0 && empTimesheet[0].Timesheet.length != 0) {
        var empTimesheet = empTimesheet[0]
        $("#employee-info h1").empty().append(empTimesheet.LastName + ", " + empTimesheet.FirstName);
        $("#employee-info h3").empty().append(empTimesheet.ProjectName + ", " + empTimesheet.JobTyp);
        $("#emp-image").css("background-position", empTimesheet.Image);

        prepareTableBody(empTimesheet.Timesheet);
        $("#timesheet-table").trigger("update");

        var expectedHrs = [];
        $.each(empTimesheet.Timesheet, function (i, v) {
            expectedHrs.push(v.ExpectedHours);
        });

        var actualHrs = [];
        $.each(empTimesheet.Timesheet, function (i, v) {
            actualHrs.push(v.ActualHours);
        });

        displayChart(expectedHrs, actualHrs);
    }
}

function prepareTableBody(empTimesheet) {
    $.each(empTimesheet, function (i, item) {
        var $tr = $('<tr>').append(
            $('<td>').text(item.DayOfWeek),
            $('<td>').text(item.ExpectedHours),
            $('<td>').text(item.ActualHours)
        ).appendTo('#timesheet tbody');
    });
}

function getObjects(obj, key, val) {
    var objects = [];
    for (var i in obj) {
        if (!obj.hasOwnProperty(i)) continue;
        if (typeof obj[i] == 'object') {
            objects = objects.concat(getObjects(obj[i], key, val));
        } else if (i == key && obj[key] == val) {
            objects.push(obj);
        }
    }
    return objects;
}

function getEmpListJSONMock() {
    var serviceURL = '/Timesheet/Timesheet';
    var serviceData = null;
    $.ajax({
        type: "POST",
        url: serviceURL,
        dataType: "json",
        async: false
    }).done(successFunc);

    function successFunc(data) {
        serviceData = data.timesheetData;
    }

    function errorFunc() {
        alert('error');
    }
    return serviceData;
}

function displayChart(bar1, bar2) {
    var s1 = bar1;
    var s2 = bar2;

    // Can specify a custom tick Array.
    // Ticks should match up one for each y value (category) in the series.
    var ticks = ['Monday', 'Tuesday', 'Wenesday', 'Thursday', 'Friday'];
    $("#chart").empty();
    var plot1 = $.jqplot('chart', [s1, s2], {
        // The "seriesDefaults" option is an options object that will
        // be applied to all series in the chart.
        seriesDefaults: {
            renderer: $.jqplot.BarRenderer,
            rendererOptions: { fillToZero: true, barMargin: 30 },
            pointLabels: { show: true }
        },
        // Custom labels for the series are specified with the "label"
        // option on the series option.  Here a series option object
        // is specified for each series.
        series: [
            { label: 'Expected Hours' },
            { label: 'Actual Hours' }
    
        ],
        // Show the legend and put it outside the grid, but inside the
        // plot container, shrinking the grid to accomodate the legend.
        // A value of "outside" would not shrink the grid and allow
        // the legend to overflow the container.
        legend: {
            show: true,
            placement: 'outsideGrid'
        },
        axes: {
            // Use a category axis on the x axis and use our custom ticks.
            xaxis: {
                renderer: $.jqplot.CategoryAxisRenderer,
                ticks: ticks
            },
            // Pad the y axis just a little so bars can get close to, but
            // not touch, the grid boundaries.  1.2 is the default padding.
            yaxis: {
                max:15
                //pad: 2,
                //tickOptions: { formatString: '%d' }
            }
        }
    });
}

