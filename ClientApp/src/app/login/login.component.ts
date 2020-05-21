import { Component, OnInit } from '@angular/core';
import {LoginModel} from '../shared/Login.model';
import {DataStorageService} from '../shared/data-storage.service';
import { FormGroup, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', './styles.css']
})
export class LoginComponent implements OnInit {
  loginForm:FormGroup;

  constructor( private dataStorageService: DataStorageService,
              private fb: FormBuilder) { }

  ngOnInit(): void{
    this.loginForm = this.fb.group({
      UserName:[''],
      Password: ['']
    });
    this.loginForm.valueChanges.subscribe(console.log);
    console.log('form loaded');
  }
  onSubmit() {
    let value = this.loginForm.value;
    const loginUser = new LoginModel(
      value.UserName,
      value.Password
      );
    console.log(loginUser);
    this.dataStorageService.storeLogin(loginUser);
  };
}
