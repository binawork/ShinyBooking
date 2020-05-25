import {Component, Injectable, OnInit} from '@angular/core';
import {LoginModel} from '../shared/Login.model';
import {DataStorageService} from '../shared/data-storage.service';
import {FormGroup, FormBuilder, NgForm} from '@angular/forms';
import {NgModel} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', './styles.css']
})

export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  password: string;
  passwordLengthValid: boolean = true;

  constructor(public dataStorageService: DataStorageService,
              private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      UserName: [''],
      Password: ['']
    });
    this.loginForm.valueChanges.subscribe(console.log);
    console.log('form loaded');
  }

  onSubmit() {
    if (!this.loginForm.valid) {
      return;
    }
    const formValue = this.loginForm.value;
    const loginUser = new LoginModel(
      formValue.UserName,
      formValue.Password
    );
    console.log(loginUser);
    this.dataStorageService.login(loginUser);
  };

  onPasswordChange() {
    this.password.length > 5 ? this.passwordLengthValid = true : this.passwordLengthValid = false;
  }
}

