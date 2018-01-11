import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http/src/http';
import { LoginService } from '../../services/login/login.service';
import { LoginCommand } from '../../models/commands/LoginCommand';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [LoginService]
})
export class LoginComponent implements OnInit {
    command: LoginCommand = new LoginCommand();

    constructor(private loginService: LoginService) { }

    ngOnInit() {
        this.command.Email = 'konradbadzio@email.com';
        this.command.Password = 'secret';
    }

    async Login() {
        try {
            const result = await this.loginService.Post(this.command);
            console.log(result);

        } catch (error) {
            console.log(error);
        }
    }
    validateEmail() {
        console.log(123);
    }


}