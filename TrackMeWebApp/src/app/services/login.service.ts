import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginCredentials } from '../classes/LoginCredentials';
import { environment } from 'src/environments/environment';
import { promisify, isUndefined } from 'util';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/x-www-form-urlencoded'
    })};

  loggedInId: number;

  async login(credentials: LoginCredentials): Promise<number> {
    try {
      if (isUndefined(this.loggedInId)) {
        const body = `user=${credentials.email}&pass=${credentials.password}`;
        this.loggedInId = (await this.http.post(environment.api.baseUrl + environment.api.login, body , this.httpOptions).toPromise()) as number;
      }
      return this.loggedInId;
    } catch (error) {
      console.log(error);
    }
  }

  logout(): void {
    this.loggedInId = undefined;
  }

  async addNewTask(userId: number, taskname: string) {
    try {
      const body = `userId=${userId}&taskName=${taskname}`;
      await this.http.post(environment.api.baseUrl + environment.api.login, body, this.httpOptions).toPromise();
    } catch (error) {
      console.log(error);
    }
  }
}
