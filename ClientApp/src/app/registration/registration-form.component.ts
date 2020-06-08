import { Component, OnInit } from '@angular/core';
import {RegistrationModel} from '../shared/Registration.model';
import {DataStorageService} from '../shared/data-storage.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import {LoginModel} from "../shared/Login.model";

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css', './styles.css']
})
export class RegistrationFormComponent implements OnInit {
  registrationForm:FormGroup;
  userName: string = '';
  password: string = '';
  email: string = '';
  isEmailValid: boolean = true;
  phoneNumber: string = '';
  somethingWentWrong = false;
  submitted: boolean = false;
  invalidForm = false;

  //TODO add separate service to communicate with backend
  constructor(private dataStorageService: DataStorageService,
    private fb: FormBuilder) { }

  ngOnInit(): void{
    this.registrationForm = this.fb.group({
      UserName: [''],
      Email: [''],
      PhoneNumber: [''],
      Password: ['']
      });
    this.registrationForm.valueChanges.subscribe(console.log);
    console.log('form loaded');
  }
  onSubmit() {
    this.invalidForm = false;
    if (!this.registrationForm.valid) {
      this.invalidForm = true;
      return;
    }
    this.somethingWentWrong = false;
    this.submitted = true;
    let value = this.registrationForm.value;

    const registeredUser = new RegistrationModel(
      value.UserName,
      value.Email,
      value.PhoneNumber,
      value.Password

      );
    console.log(registeredUser);
    this.dataStorageService.registerUser(registeredUser);
    const loginRegisteredUser = new LoginModel(
      registeredUser.userName,
      registeredUser.password
    )
     setTimeout(()=>this.dataStorageService.login(loginRegisteredUser), 5000);
     setTimeout(()=>{this.somethingWentWrong = true;},10000);
  };

    // todo when successfully added redirect to /rooms

  isEmailValidCheck(mail) {
    this.isEmailValid = (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail))
  }

  isNumber(phoneNumber) {
    return /^-?[\d.]+(?:e-?\d+)?$/.test(phoneNumber);
  }

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
