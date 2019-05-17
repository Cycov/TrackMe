Jos sunt exemple de comenzi suportate de microserviciu

{{ip}}:{{port}}/addCommand/command phrase/description --POST - add command to microservice database
{{ip}}:{{port}}/phraseRecognised/stop training --POST - tell the service that the command 'stop training' has been found correctly
{{ip}}:{{port}}/phraseRecognised/stop training --PATCH - tell the service that the command 'stop training' has been found incorrectly
{{ip}}:{{port}}/commands --GET - get commands stored
{{ip}}:{{port}}/commands/2 --GET - get command with id 2
{{ip}}:{{port}}/getLastCommands --GET - get all commands executed
{{ip}}:{{port}}/getLastCommands/3 --GET - get last 3 commands