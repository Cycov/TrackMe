export const GetCommandsThatMatch = "SELECT id FROM Commands WHERE phrase=? LIMIT 1";
export const InsertRecognisedPhrase = "INSERT INTO RecognisedPhrases(timestamp, actualCommand) VALUES(?,?)";
export const InsertRecognisedPhraseWithStatus = "INSERT INTO RecognisedPhrases(timestamp, actualCommand, correctly) VALUES(?,?,?)"
export const AddNewCommandWithDescription = "INSERT INTO Commands(phrase,description) VALUES(?,?)";
export const AddNewCommand = "INSERT INTO Commands(phrase) VALUES(?)";
export const GetAllCommands = "SELECT * FROM Commands";
export const GetCommandsWithId = "SELECT * FROM Commands WHERE id=?";
export const GetCalledCommandsDesc = "select phrase, description, timestamp, correctly, RecognisedPhrases.id as entryId, Commands.id as commandId from RecognisedPhrases inner join Commands on RecognisedPhrases.actualCommand = Commands.id order by RecognisedPhrases.id desc";
export class PewClass { }