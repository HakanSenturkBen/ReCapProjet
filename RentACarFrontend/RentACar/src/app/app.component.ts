import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RentACar';
  validaty:boolean=validity();
}



function validity() {
  let route=localStorage.getItem("route")
  if (route=="cars") {
    return true
  }
  return false

  
}

