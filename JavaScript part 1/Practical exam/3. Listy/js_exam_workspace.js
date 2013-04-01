/*
 *     Exam 3: ...
 */
 
/*--- CONTROL VALUES ------------------------------------------------------*/

isDebugMode = true; //Change before submit code
testIndex = -1; //To run All tests set to -1


/*--- MAIN LOGIC ----------------------------------------------------------*/

variables = new Array();
result = undefined;

function Solve(args) {
    variables = new Array();
    result = undefined;

    for (var i = 0; i < args.length; i++) {
        if (typeof args[i] != "undefined") {
            Execute(args[i].trim());
        }
    }

    if (typeof result == "undefined") {
        var lastPropValue;
        for (var prop in variables) {
            lastPropValue = variables[prop];
        }

        result = lastPropValue;
    }

    return result;
}

function Execute(expression) {
    
    var expressionValues = GetValues(expression);

    expression = expression.replaceAll("  ", " ");  //Set all spaces to one space
    var parts = (expression.substring(0, expression.indexOf("["))).toString().split(" ");

    //Remove empty elements
    for (var i = 0; i < parts.length; i++) {
        if (parts[i].trim().length == 0) {
            parts.pop(i);
        }
    }
     
    if (parts.length == 0) { 
        result = parseInt(expressionValues);  //Only execute function. Parse because it can be an array
    }
    else if (parts[0] == "def") {
        if (parts.length == 2) {
            variables[parts[1].trim().toString()] = expressionValues;  //Only define
        }
        else if (parts.length == 3) {
            var varValue = CalculateFunction(parts[2], expressionValues);   //Define with function
            variables[parts[1].trim().toString()] = varValue;
        }
    }
    else if (parts.length == 1) {
        result = CalculateFunction(parts[0], expressionValues);  //Function calling
    }
}

function GetValues(expression) {
    var expressionValues = new Array(); //Validated values
    var funcValues = expression.substring(expression.indexOf("[") + 1, expression.length - 1).split(",");

    for (var i = 0; i < funcValues.length; i++) {
        if (typeof funcValues[i] != "undefined" && funcValues[i] != null && funcValues[i].length > 0) {
            funcValues[i] = funcValues[i].trim();

            if (!isNaN(funcValues[i])) {
                //Add number
                funcValues[i] = funcValues[i].trim();
                if (typeof funcValues[i] == "undefined" || funcValues[i] == null || funcValues[i].toString().length == 0) {
                    //funcValues.pop(i);
                } else {
                    expressionValues.push(parseInt(funcValues[i]));
                }
            }
            else if (typeof variables[funcValues[i]] != "undefined") {
                //Replace variable with his values
                if (variables[funcValues[i]].length >= 0) {
                    for (var j = 0; j < variables[funcValues[i]].length; j++) {
                        expressionValues.push(variables[funcValues[i]][j]);
                    }
                } else {
                    expressionValues.push(variables[funcValues[i]]);
                }
            }
        }
    }

    return expressionValues;
}

function CalculateFunction(func, values) {
    //Sum
    if (func == "sum") {
        return getSum(values);
    }

    //Average
    if (func == "avg") {
        return parseInt(getSum(values) / values.length);
    }

    //Min
    if (func == "min") {
        var min = values[0];
        for (var i = 0; i < values.length; i++) {
            if (values[i] < min) {
                min = values[i];
            }
        }
        return min;
    }

    //Max
    if (func == "max") {
        var max = values[0];
        for (var i = 0; i < values.length; i++) {
            if (values[i] > max) {
                max = values[i];
            }
        }
        return max;
    }
}

function getSum(values) {
    var sum = 0;
    for (var i = 0; i < values.length; i++) {
        sum += values[i];
    }

    return sum;
}

/*--- TESTS SCENARIOS -------------------------------------------------------*/

testsArguments = [];

//Load test values
function initializeTests() {
    var test1args = [
        "def func sum[5,  3,  7 ,  2,  6, 3]",
        "def func2 [5, 3, 7, 2, 6, 3]",
        "def func3 min[func2]",
        "def func4 max[5, 3, 7, 2, 6, 3]",
        "def func5 avg[5, 3, 7, 2, 6, 3]",
        "def func6 sum[func2, func3, func4 ]",
        "sum[func6, func4]"];
    testsArguments.push(test1args);

    var test2args = [
        "def func sum[1, -4, 2, 3 , -6]",
        "def newList [func, 10, 1]",
        "def newFunc sum[func, 100, newList]", ,
        " [newFunc]"];
    testsArguments.push(test2args);

    var test3args = [
        "def func[4, 1]",
        "def func2 sum[func,  10]"];
    testsArguments.push(test3args);

    var test4args = [
        "def func   sum[4, 1]",
        "[func]"];
    testsArguments.push(test4args);
}

//Call all test scenarios
function runAllTests(){
	if(testsArguments.length == 0){
		console.log("Not available test scenarios");
		return;
	}

	for(var i=0; i<testsArguments.length; i++){
		runTest(i);
	}
}

//Call a single test scenario
function runTest(index){
	if(index < 0 || index > testsArguments.length){
		console.error("Not existing test scenario");
		return;
	}

	console.warn("TEST " + (index+1) + " ---------------------------------------------------");
	console.log("  Input:", testsArguments[index]);
	console.log("  Result:", Solve(testsArguments[index]));
	console.log("");
}


//Shows message to the console when is in debug mode
function debugShow(message){
	if(isDebugMode){
		console.log("    Log: " + message);
	}
}


/*--- EXTENSIONS -----------------------------------------------------------*/

//Returns sequence of repeating text
String.repeat = function(chr, count){
  var result = ''; 
  for(var i = 0; i < count; i++) 
    result += chr;   
	
  return result;
}


//Inserts a string into another string given position
String.prototype.insert = function (index, text) {
	if (index > 0)
		return this.substring(0, index) + text + this.substring(index, this.length);
	else
	    return text + this;
};


//Check if string contains or not some string
String.prototype.contains = function (substring) {
	if(this.indexOf(substring) == -1){
		return false;
	}
	
	return true;
};


//Replaces all seached values with another string
String.prototype.replaceAll = function (searchValue, replaceValue) {
	var content = this;
	while (content.indexOf(searchValue) != -1) {
		content = content.replace(searchValue, replaceValue);
	}
	
	return content;
};


//Returs the count of how much times a substring is countained
String.prototype.count = function (searchValue) {
    var count = 0;
    var content = this;
    while (content.contains(searchValue)) {
        content = content.replace(searchValue, "");
        count++;
    }

    return count;
}


//Formats string by replacing arguments positions with real arguments
String.prototype.format = function () {
	var formatted = this;
	for (arg in arguments) {
		var argString = "{" + arg + "}";
		while (formatted.contains(argString)) {
			formatted = formatted.replace(argString, arguments[arg]);
		}
	}

	return formatted;
};


//Initializes a new StringBuilder class and appends the given value if supplied
function StringBuilder(value){
    this.strings = new Array("");
    this.append(value);
}


//Appends the given value to the end of this instance.
StringBuilder.prototype.append = function (value){
    if (value) {
        this.strings.push(value);
    }
}


//Clears the string buffer
StringBuilder.prototype.clear = function (){
    this.strings.length = 1;
}


//Converts this instance to a String.
StringBuilder.prototype.toString = function (){
    return this.strings.join("");
}

//Creatrs new two dimensional Array object
function newMatrix(rows, cols) {
    var matrix = [];
    var i = 0;
    var j = 0;

    for (i = 0; i < rows; i++) {
        matrix[i] = new Array(cols);
        for (j = 0; j < cols; j++) {
            matrix[i][j] = 0;
        }
    }

    return matrix;
}


/*--- EXECUTE ----------------------------------------------------------------*/

if(isDebugMode){
    initializeTests();
	
	if(testIndex >= 0){
		runTest(testIndex);
	}else{
		runAllTests();
	}
}