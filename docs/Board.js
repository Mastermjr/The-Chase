function readTextFile(file)
{
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function ()
    {
        if(rawFile.readyState === 4)
        {
            if(rawFile.status === 200 || rawFile.status == 0)
            {
                var allText = rawFile.responseText;
                alert(allText);
            }
        }
    }
    rawFile.send(null);
}

var leaderData = readTextFile("leaderboard.csv")

$scope.$watch("leaderData", function() {
    var lines, lineNumber, data, length;
    $scope.leaderboard = [];
    lines = $scope.leaderData.split('\n');
    lineNumber = 0;
    for (var i = lines.length - 1; i >= 0; i--) {
        l = lines[i];

        lineNumber++;
        data = l.split(',');

        var name = data[0];
        var score = data[1];

        $scope.leaderboard.push({
            name: name,
            score: score
        });
    }
});