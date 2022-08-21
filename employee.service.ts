import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { observable } from 'rxjs';
import { EmployeeInfo } from '../models/employee-info';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  //employee:EmployeeInfo=new EmployeeInfo();
  baseUrl:string="https://localhost:44395/api/";
  constructor(private http: HttpClient) { }
  
  getAllEmployeeInfo(){
    return this.http.get<any>(this.baseUrl+"Employee/GetAllEmployee");
  }

  addEmployee(employee:EmployeeInfo){
    return this.http.post<any>(this.baseUrl+"Employee/AddNewEmployee",employee);
  }

}
