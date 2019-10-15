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
      const expr = Parser.parse(functions[scaleLevel]);
      const result = expr.evaluate()(2);
      console.log(`result for ${scaleLevel}: ${result}`);
    }
    catch(e){
      console.error(e.message);
    }
  });
})

