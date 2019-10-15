const fs = require("fs");
var Parser = require('expr-eval').Parser;

const json = fs.readFileSync(__dirname + "/json.json");
const obj = JSON.parse(json);


Object.keys(obj).forEach(key => {
  console.log(`\n\n----TESTING ${key}----\n\n`);
  const functions = obj[key];
  Object.keys(functions).forEach(scaleLevel => {
    console.log(`\nTesting ${key.slice(0,-16)} ${scaleLevel}: ${functions[scaleLevel]}`);
    try{
      const [fnName, expression] = functions[scaleLevel].split(" = ")
      const regExp = /\(([^)]+)\)/;
      const varName = regExp.exec(fnName)[1];

      const result = Parser.evaluate(expression, { [varName]: 2 });
      console.log(`result for ${scaleLevel}: ${result}`);
    }
    catch(e){
      console.error(e.message);
    }
  });
})

