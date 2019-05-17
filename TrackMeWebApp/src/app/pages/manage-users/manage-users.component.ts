import { Component, OnInit } from '@angular/core';
import { LoginCredentials } from 'src/app/classes/LoginCredentials';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {

  credentials: LoginCredentials;
  users: Array<any>;

  constructor(private loginService: LoginService) { }

  async ngOnInit() {

  }

  addNewUser() {
    if (!this.credentials.isEmpty()) {

    }
  }

  downloadData(userId: number) {

  }

  addNewTask(userId: number) {
    this.loginService.addNewTask(userId, )
  }
}
