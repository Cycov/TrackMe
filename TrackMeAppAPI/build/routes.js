"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var actions_1 = require("./actions");
var util_1 = require("util");
var Routes = (function () {
    function Routes(expressApp, sqliteDb) {
        var _this = this;
        if (util_1.isUndefined(sqliteDb))
            console.error("Database not initialised");
        this.db = sqliteDb;
        this.actions = new actions_1.Actions(sqliteDb);
        this.app = expressApp;
        this.app.post('/addCommand/:phrase/:description', function (req, res) {
            _this.actions.addCommand(res, req.params.phrase, req.params.description);
        });
        this.app.post('/addCommand/:phrase', function (req, res) {
            _this.actions.addCommand(res, req.params.phrase);
        });
        this.app.post('/addCommand', function (req, res) {
            if (req.body.phrase == undefined) {
                res.sendStatus(400);
            }
            else {
                _this.actions.addCommand(res, req.body.phrase, req.body.description);
            }
        });
        this.app.post('/phraseRecognised/:phrase', function (req, res) {
            _this.actions.phraseRecognised(res, req.params.phrase);
        });
        this.app.post('registerCallback/:function', function (req, res) {
        });
        this.app.post('*', function (req, res) {
            res.sendStatus(400);
        });
        this.app.delete('unregisterCallback/:function', function (req, res) {
        });
        this.app.delete('*', function (req, res) {
            res.sendStatus(400);
        });
        this.app.patch('/phraseRecognised/:phrase', function (req, res) {
            _this.actions.phraseRecognised(res, req.params.phrase, false);
        });
        this.app.patch('*', function (req, res) {
            res.sendStatus(400);
        });
        this.app.get('/commands', function (req, res) {
            _this.actions.getCommands(res);
        });
        this.app.get('/commands/:id', function (req, res) {
            _this.actions.getCommands(res, req.params.id);
        });
        this.app.get('/getLastCommands/', function (req, res) {
            _this.actions.getLastCommands(res);
        });
        this.app.get('/getLastCommands/:count', function (req, res) {
            _this.actions.getLastCommands(res, req.params.count);
        });
        this.app.get('*', function (req, res) {
            res.sendStatus(400);
        });
    }
    return Routes;
}());
exports.Routes = Routes;
