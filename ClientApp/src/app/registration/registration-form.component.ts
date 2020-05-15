import { Component, OnInit } from '@angular/core';
import {RegistrationModel} from '../shared/Registration.model';
import {DataStorageService} from '../shared/data-storage.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css', './styles.css']
})
export class RegistrationFormComponent implements OnInit {

  registrationForm:FormGroup;
  //TODO add separate service to communicate with backend
  constructor(private dataStorageService: DataStorageService,
    private fb: FormBuilder) { }

  ngOnInit(): void{
    this.registrationForm = this.fb.group({
      UserName: ['Please enter user name'],
      Email: ['Please enter email address'],
      PhoneNumber: ['Please enter phone number'],
      Password: ['Please enter password']
      });
    this.registrationForm.valueChanges.subscribe(console.log);
    console.log('form loaded');
  }
  onSubmit() {
   
    let value = this.registrationForm.value;
   
    const registeredUser = new RegistrationModel(
      value.UserName,
      value.Email,
      value.PhoneNumber,
      value.Password

      );

    console.log(registeredUser);
    this.dataStorageService.storeUser(registeredUser);
    //this.resetForm();

  };
      
    // todo when successfully added redirect to /rooms
 
}
