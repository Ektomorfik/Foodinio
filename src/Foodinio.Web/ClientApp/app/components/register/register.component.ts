import { Component, OnInit } from '@angular/core';
import { CreateUser } from '../../models/User/CreateUser';
import { FormGroup, FormControl, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { AbstractControl } from '@angular/forms/src/model';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
    providers: [EmailValidator]
})
export class RegisterComponent implements OnInit {

    registerForm: FormGroup;
    command: CreateUser = new CreateUser();

    constructor(private formBuilder: FormBuilder) {
        this.createForm();
    }

    ngOnInit() {
    }

    createForm() {
        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', Validators.email],
            password: ['', Validators.compose([Validators.required, Validators.minLength(6)])],
            passwordConfirmation: ['', Validators.compose([Validators.required, Validators.minLength(6)])],
        });
        //TODO: Create custom validators for all fields
    }

    onSubmit() {
        const userModel: CreateUser = this.registerForm.value;
        if (!this.registerForm.valid) {
            console.log('error');
            return;
        }
        console.log('Form is valid.');
    }

    fieldIsInvalid(fieldName: string): boolean {
        const ctrl = this.registerForm.controls[fieldName];
        return !ctrl.valid && ctrl.touched;
    }
}
