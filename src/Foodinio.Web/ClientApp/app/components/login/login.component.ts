import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http/src/http';
import { LoginService } from '../../services/login/login.service';
import { LoginCommand } from '../../models/commands/LoginCommand';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    providers: [LoginService]
})
export class LoginComponent implements OnInit {

    loginForm: FormGroup;

    constructor(private formBuilder: FormBuilder) {
        this.createForm();
    }

    ngOnInit() {
    }

    createForm() {
        this.loginForm = this.formBuilder.group({
            email: ['', Validators.email],
            password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    onSubmit() {
    }
}