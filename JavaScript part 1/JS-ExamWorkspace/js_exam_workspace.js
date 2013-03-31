/*
 *     TELERIK ACADEMY JS EXAM WORKSPACE
 *       created by Tsvetomir Nikolov
 *       (not author of the solution)
 */
 
/*--- CONTROL VALUES ------------------------------------------------------*/

isDebugMode = true; //Change before submit code
testIndex = -1; //To run All tests set to -1


/*--- MAIN LOGIC ----------------------------------------------------------*/

function Solve(args){

	//TOD0: Implement the main logic...
	
	return sb.toString();
}


/*--- TESTS SCENARIOS -------------------------------------------------------*/

testsArguments = [];

//Load test values
function initializeTests() {

	//TOD0: Add test scenarios
	
	// Test example
	// var test1args = ["1"];
	// test1args[0] = "1";
	// test1args[1] = "1 2 3 4";
	// testsArguments.push(test1args);
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


/*--- EXECUTE ----------------------------------------------------------------*/

if(isDebugMode){
    initializeTests();
	
	if(testIndex >= 0){
		runTest(testIndex);
	}else{
		runAllTests();
	}
}