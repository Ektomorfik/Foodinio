import { Component, OnInit, OnChanges } from '@angular/core';
import { CreateUser } from '../../models/User/CreateUser';
import { FormGroup, FormControl, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { AbstractControl } from '@angular/forms/src/model';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
    providers: [EmailValidator]
})
export class RegisterComponent implements OnInit, OnChanges {

    registerForm: FormGroup;
    command: CreateUser = new CreateUser();

    constructor(private formBuilder: FormBuilder) {
        this.createForm();
    }

    ngOnInit() {
    }

    ngOnChanges() {
    }

    createForm() {
        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', Validators.email, Validators.minLength(6)],
            password: ['', Validators.required],
            password2: ['', Validators.required],
        });
    }

    onSubmit() {
        const userModel: CreateUser = this.registerForm.value;

        console.log(name);
    }

}
