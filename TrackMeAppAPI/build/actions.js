"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var util_1 = require("util");
var callbacks_1 = require("./callbacks");
var lowerCase = require('lower-case');
var Actions = (function () {
    function Actions(sqliteDb) {
        if (util_1.isUndefined(sqliteDb))
            console.error("Database not initialised");
        this.db = sqliteDb;
        this.notifyMeCallback = new callbacks_1.NotifyMeCallback(8001);
        this.hubCallback = new callbacks_1.HubCallback(8003);
    }
    Actions.prototype.phraseRecognised = function (res, phrase, correctly) {
        var _this = this;
        if (this.db == undefined) {
            console.error("Database not properly initialised");
            res.sendStatus(500);
        }
        else {
            if (isNaN(Number(phrase))) {
                phrase = lowerCase(phrase);
                this.db.all("SELECT id FROM Commands WHERE phrase=? LIMIT 1", [phrase], function (err, rows) {
                    if (err)
                        return console.log(err.message);
                    else {
                        if (rows.length == 1) {
                            console.log("Recognised '" + phrase + "' with id " + rows[0].id);
                            if (correctly == undefined || util_1.isNull(correctly) || correctly === true) {
                                _this.db.run("INSERT INTO RecognisedPhrases(timestamp, actualCommand) VALUES(?,?)", [(new Date()).toUTCString(), rows[0].id], function (err) {
                                    if (err) {
                                        console.log(err.message);
                                        res.sendStatus(500);
                                    }
                                    else {
                                        res.sendStatus(201);
                                        _this.notifyMeCallback.invoke(new callbacks_1.NotifyMeCallbackEventArgs("Command recognised", "Command " + phrase + " recognised and recorded"));
                                        switch (rows[0].id) {
                                            case 1:
                                                _this.hubCallback.invoke(new callbacks_1.HubCallbackEventArgs(callbacks_1.HubAPIEvents.START_TRAINING));
                                                break;
                                            case 2:
                                                _this.hubCallback.invoke(new callbacks_1.HubCallbackEventArgs(callbacks_1.HubAPIEvents.STOP_TRAINING));
                                                break;
                                            case 5:
                                                _this.hubCallback.invoke(new callbacks_1.HubCallbackEventArgs(callbacks_1.HubAPIEvents.STOP_APPLICATION));
                                                break;
                                            case 4:
                                                _this.hubCallback.invoke(new callbacks_1.HubCallbackEventArgs(callbacks_1.HubAPIEvents.FIRST_APPLICATION));
                                                break;
                                            default:
                                                console.log("Id: '" + rows[0].id + "' not found");
                                                break;
                                        }
                                    }
                                });
                            }
                            else {
                                _this.db.run("INSERT INTO RecognisedPhrases(timestamp, actualCommand, correctly) VALUES(?,?,?)", [(new Date()).toUTCString(), rows[0].id, 0], function (err) {
                                    if (err) {
                                        console.log(err.message);
                                        res.sendStatus(500);
                                    }
                                    else {
                                        res.sendStatus(201);
                                        _this.notifyMeCallback.invoke(new callbacks_1.NotifyMeCallbackEventArgs("Command recognised", "Command " + phrase + " recognised and recorded"));
                                    }
                                });
                            }
                        }
                        else {
                            console.log("Command " + phrase + " not found.");
                            res.sendStatus(503);
                        }
                    }
                });
            }
            else {
                res.sendStatus(501);
            }
        }
    };
    Actions.prototype.addCommand = function (res, command, description) {
        var _this = this;
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!util_1.isNull(description)) {
                this.db.run("INSERT INTO Commands(phrase,description) VALUES(?,?)", [command, description], function (err) {
                    if (err) {
                        console.log(err.message);
                        res.sendStatus(500);
                    }
                    else {
                        res.sendStatus(201);
                        _this.notifyMeCallback.invoke(new callbacks_1.NotifyMeCallbackEventArgs("Command added", "Command " + command + " with description " + description + " added to database"));
                    }
                });
            }
            else {
                this.db.run("INSERT INTO Commands(phrase) VALUES(?)", [command], function (err) {
                    if (err) {
                        console.log(err.message);
                        res.sendStatus(500);
                    }
                    else {
                        res.sendStatus(201);
                        _this.notifyMeCallback.invoke(new callbacks_1.NotifyMeCallbackEventArgs("Command added", "Command " + command + " added to database"));
                    }
                });
            }
        }
    };
    Actions.prototype.getCommands = function (res, commandIndex) {
        var commands = new Array();
        if (commandIndex == undefined) {
            this.db.all("SELECT * FROM Commands", function (err, rows) {
                if (err)
                    return console.log(err.message);
                else {
                    rows.forEach(function (row) {
                        commands.push(row);
                    });
                    res.send(JSON.stringify(commands));
                }
            });
        }
        else {
            this.db.all("SELECT * FROM Commands WHERE id=?", [commandIndex], function (err, rows) {
                if (err)
                    return console.log(err.message);
                else {
                    rows.forEach(function (row) {
                        commands.push(row);
                    });
                    res.send(JSON.stringify(commands));
                }
            });
        }
    };
    Actions.prototype.getLastCommands = function (res, count) {
        var phrases = new Array();
        var sql = "select phrase, description, timestamp, correctly, RecognisedPhrases.id as entryId, Commands.id as commandId from RecognisedPhrases " +
            "inner join " +
            "Commands on RecognisedPhrases.actualCommand = Commands.id " +
            "order by RecognisedPhrases.id desc";
        if (count != undefined)
            sql = sql + " limit ?";
        this.db.all(sql, [count], function (err, rows) {
            if (err)
                return console.log(err.message);
            else {
                rows.forEach(function (row) {
                    phrases.push(new PhrasesRecognisedEntry(row));
                });
                res.send(JSON.stringify(phrases));
            }
        });
    };
    return Actions;
}());
exports.Actions = Actions;
var PhrasesRecognisedEntry = (function () {
    function PhrasesRecognisedEntry(queryResult) {
        this.id = queryResult.entryId;
        this.timestamp = queryResult.timestamp;
        this.correctly = queryResult.correctly;
        this.actualCommand = {
            id: queryResult.commandId,
            phrase: queryResult.phrase,
            description: queryResult.description
        };
    }
    return PhrasesRecognisedEntry;
}());
