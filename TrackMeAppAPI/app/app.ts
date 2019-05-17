import express = require('express');
var cors = require('cors');
import * as bodyParser from 'body-parser';
import { Routes } from "./routes"
import * as sqlite from 'sqlite3';
//http codes: 501 - not implemented
//            400 - bad syntax

const app: express.Application = express();
const port: number = 8000;
app.use(cors());
app.use(bodyParser.urlencoded({ extended: true }));
app.listen(port, function () {
    console.log("Server started on port " + port);
})
const db = new sqlite.Database("trackmeapp.sqlite", function (this:any,err) {
    if (err)
        console.error(err);
    console.log("Connected to database");
    var routes: Routes = new Routes(app, this);
});
