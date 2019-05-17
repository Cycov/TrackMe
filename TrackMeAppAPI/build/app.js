"use strict";
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
var express = require("express");
var bodyParser = __importStar(require("body-parser"));
var routes_1 = require("./routes");
var sqlite = __importStar(require("sqlite3"));
var app = express();
var port = 8000;
app.use(bodyParser.urlencoded({ extended: true }));
app.listen(port, function () {
    console.log("Server started on port " + port);
});
var db = new sqlite.Database("sensyspeechdb.db", function (err) {
    if (err)
        console.error(err);
    console.log("Connected to database");
    var routes = new routes_1.Routes(app, this);
});
