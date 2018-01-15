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
            password: ['', Validators.compose([Validators.required, Validators.minLength(6)])]
        });
    }

    onSubmit() {
        if (!this.loginForm.valid) {
            console.log('error');
            return;
        }
        console.log('Form is valid.');
    }

    fieldIsInvalid(fieldName: string): boolean {
        const ctrl = this.loginForm.controls[fieldName];
        return !ctrl.valid && ctrl.touched;
    }

}