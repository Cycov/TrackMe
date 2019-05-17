import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { LoginCredentials } from 'src/app/classes/LoginCredentials';
import { LoginService } from 'src/app/services/login.service';
import { isUndefined } from 'util';
import { Router } from '@angular/router';
import { routerNgProbeToken } from '@angular/router/src/router_module';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  credentials: LoginCredentials;
  constructor(private http: HttpClient,
              private loginService: LoginService,
              private router: Router) { }

  ngOnInit() {
    this.credentials = {email: '', password: ''};
  }


  async login() {
    const id = await this.loginService.login(this.credentials);
    if (!isUndefined(id) && id > -1) {
        await this.router.navigate(['/manage-users']);
    }
  }
}
