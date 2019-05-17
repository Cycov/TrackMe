export interface GetCommandsQueryResult {
    id : number;
    phrase : string;
    description : string;
}
export interface GetLastCommandsQueryResult {
    phrase : string;
    description : string;
    timestamp : string;
    correctly : number;
    entryId : number;
    commandId : number;
}