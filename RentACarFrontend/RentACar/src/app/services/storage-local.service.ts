import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class StorageLocalService {

  constructor() { }

  loadObject(objectName:string,t:any){
    localStorage.setItem(objectName,JSON.stringify(t))
  }
  getObject(objectName:string,){
    if (localStorage.getItem(objectName)) {
           
      return localStorage.getItem(objectName)
    }
    return
  }
  deleteIt(objectName:string){
    localStorage.removeItem(objectName)
  }

}
