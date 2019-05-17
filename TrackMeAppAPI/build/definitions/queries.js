"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GetCommandsThatMatch = "SELECT id FROM Commands WHERE phrase=? LIMIT 1";
exports.InsertRecognisedPhrase = "INSERT INTO RecognisedPhrases(timestamp, actualCommand) VALUES(?,?)";
exports.InsertRecognisedPhraseWithStatus = "INSERT INTO RecognisedPhrases(timestamp, actualCommand, correctly) VALUES(?,?,?)";
exports.AddNewCommandWithDescription = "INSERT INTO Commands(phrase,description) VALUES(?,?)";
exports.AddNewCommand = "INSERT INTO Commands(phrase) VALUES(?)";
exports.GetAllCommands = "SELECT * FROM Commands";
exports.GetCommandsWithId = "SELECT * FROM Commands WHERE id=?";
exports.GetCalledCommandsDesc = "select phrase, description, timestamp, correctly, RecognisedPhrases.id as entryId, Commands.id as commandId from RecognisedPhrases inner join Commands on RecognisedPhrases.actualCommand = Commands.id order by RecognisedPhrases.id desc";
var PewClass = (function () {
    function PewClass() {
    }
    return PewClass;
}());
exports.PewClass = PewClass;
