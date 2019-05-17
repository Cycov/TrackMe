import * as sqlite from 'sqlite3';
import { isNull, debug, isUndefined } from 'util';
import { cpus } from 'os';
import { strict } from 'assert';
import { GetCommandsQueryResult, GetLastCommandsQueryResult } from './definitions/queryResults';
import { Response } from 'express';
import { NotifyMeCallback, NotifyMeCallbackEventArgs, HubCallback, HubCallbackEventArgs, HubAPIEvents } from './callbacks';
var lowerCase = require('lower-case');

export class Actions {
    protected db: sqlite.Database;

    constructor(sqliteDb: sqlite.Database) {
        if (isUndefined(sqliteDb))
            console.error("Database not initialised");
        this.db = sqliteDb;
    }

    login(res: Response, user: any, pass: string) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(user) && !isNull(pass))
            {
                this.db.all("SELECT id FROM USERS WHERE email=? AND password=? LIMIT 1", [user, pass], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else {
                        if (rows && rows.length > 0)
                            res.send(JSON.stringify(rows[0].id));
                        else
                            res.sendStatus(404);
                    }
                })
            }
        }
    }

    addNewUser(res: Response, user: any) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(user)) {
                this.db.run("INSERT INTO USERS(email, password, company, privilege) VALUES (?,?,?,?)", [user.email, user.password, user.companyId, user.privilege], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else
                        res.sendStatus(201);
                });
            }
        }
    }

    addNewTask(res: Response, userId: any, taskName: any) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(userId)) {
                this.db.run("INSERT INTO TASKS(name, user_id) VALUES (?,?)", [taskName, userId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else
                        res.sendStatus(201);
                });
            }
        }
    }

    logSession(res: Response, userId: number, sessionData: string) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(userId) && !isNull(sessionData))
            {
                this.db.run("INSERT INTO sessions(json_data, user_id) values (?,?)", [sessionData, userId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else
                        res.sendStatus(201);
                });
            }
        }
    }

    getUserTasks(res: Response, userId: number) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(userId))
            {
                this.db.all("SELECT name, id FROM tasks WHERE user_id=?", [userId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else {
                        let tasks: TaskData[] = [];
                        rows.forEach((row: any) => {
                            tasks.push(new TaskData(row.id, row.name));
                        });
                        res.send(JSON.stringify(tasks));
                    }
                })
            }
        }
    }

    getUserData(res: Response, userId: number) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(userId))
            {
                this.db.all("SELECT * FROM users WHERE id=? LIMIT 1", [userId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else {
                        res.send(rows[0]);
                    }
                });
            }
        }
    }

    getSessions(res: Response, userId: number) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(userId))
            {
                this.db.all("SELECT json_data FROM sessions WHERE user_id=?", [userId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else {
                        let data: any[] = [];
                        rows.forEach((row: any) => {
                            data.push(JSON.parse(row.json_data));
                        });
                        res.send(JSON.stringify(data));
                    }
                });
            }
        }
    }

    getCompanyUsers(res: Response, companyId: number) {
        if (this.db == undefined)
            console.error("Db not properly initialised");
        else {
            if (!isNull(companyId))
            {
                this.db.all("SELECT * FROM users WHERE company=?", [companyId], (err: Error, rows: any) => {
                    if (err)
                        return console.log(err.message);
                    else {
                        let data: UserData[] = [];
                        rows.forEach((row: any) => {
                            data.push(row);
                        });
                        res.send(JSON.stringify(data));
                    }
                });
            }
        }
    }
}

export class UserData {
    constructor(
        public id: number,
        public email: string,
        public password: string,
        public companyId: number,
        public privilege: Privileges
    )
    {

    }

}

export class TaskData {
    constructor(
        public id: number,
        public title: string
    ) { }
}

export enum Privileges {
    Admin = 0,
    Manager = 1,
    User = 2,
}