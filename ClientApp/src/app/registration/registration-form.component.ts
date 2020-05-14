import { Component, OnInit } from '@angular/core';
import {RegistrationModel} from '../shared/Registration.model';
import {DataStorageService} from '../shared/data-storage.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css', './styles.css']
})
export class RegistrationFormComponent implements OnInit {

  registrationForm:FormGroup;

  constructor(dataStorageService:DataStorageService) { }

  ngOnInit(){
  }
  onSubmit() {
  }

}
