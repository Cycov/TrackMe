import { Request, Response, Application } from "express";
import { Actions } from "./actions";
import { Database } from 'sqlite3';
import { isUndefined } from "util";

export class Routes {

    private app: Application;
    protected db: Database;
    protected actions: Actions;

    constructor(expressApp: Application, sqliteDb: Database) {
        if (isUndefined(sqliteDb))
            console.error("Database not initialised");
        this.db = sqliteDb;
        this.actions = new Actions(sqliteDb);

        this.app = expressApp;

        this.app.post('/login', (req: Request, res: Response) => {
            this.actions.login(res, req.body.user, req.body.pass);
        });

        this.app.post('/addNewUser', (req: Request, res: Response) => {
            this.actions.addNewUser(res, JSON.parse(req.body.user));
        });

        this.app.post('/logSession', (req: Request, res: Response) => {
            this.actions.logSession(res, req.body.userId, req.body.session);
        });

        this.app.post('/addNewTask', (req: Request, res: Response) => {
            this.actions.addNewTask(res, req.body.userId, req.body.taskName);
        });

        this.app.post('/getSessions', (req: Request, res: Response) => {
            this.actions.getSessions(res, req.body.userId);
        });

        this.app.post('/getUserTasks', (req: Request, res: Response) => {
            this.actions.getUserTasks(res, req.body.userId);
        });

        this.app.post('/getUserData', (req: Request, res: Response) => {
            this.actions.getUserData(res, req.body.id);
        });

        this.app.post('/getCompanyUsers', (req: Request, res: Response) => {
            this.actions.getCompanyUsers(res, req.body.companyId);
        });

        this.app.post('*', (req: Request, res: Response) => {
            res.sendStatus(400); //bad request
        });

        this.app.delete('*', (req: Request, res: Response) => {
            res.sendStatus(400); //bad request
        });

        this.app.patch('*', (req: Request, res: Response) => {
            res.sendStatus(400); //bad syntax
        });

        this.app.get('*', (req: Request, res: Response) => {
            res.sendStatus(400); //bad syntax
        });
    }
}