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
  password: string = '';
  email: string = '';
  isEmailValid: boolean = true;
  phoneNumber: string = '';
  somethingWentWrong = false;
  submitted: boolean = false;

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
    this.somethingWentWrong = false;
    this.submitted = true;
    let value = this.registrationForm.value;

    const registeredUser = new RegistrationModel(
      value.UserName,
      value.Email,
      value.PhoneNumber,
      value.Password

      );

    this.dataStorageService.storeUser(registeredUser);
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
}
