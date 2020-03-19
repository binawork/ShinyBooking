import {Component, Inject} from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {


  constructor(@Inject('BASE_URL') baleUrl: string) {
  }



  public incrementCounter() {
    console.log("dupa")
  }
}
