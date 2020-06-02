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
  password: string = 'exampleNotEmptyPassword';

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
    this.dataStorageService.login(loginUser);
  };

  //check if password contains at least: 1 non-alphanumeric,
  // 1 lowercase and 1 uppercase letter, 1 digit and 6 characters
  isPasswordValid(str) {
    return !(/^[a-z0-9]+$/i.test(str))
      && (/[a-z]/.test(str))
      && (/[A-Z]/.test(str))
      && (/[0-9]/.test(str))
      && str.length > 5;
  }

}

