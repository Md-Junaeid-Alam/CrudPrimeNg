import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeInfo } from 'src/app/models/employee-info';
import { EmployeeService } from 'src/app/services/employee.service';



@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent implements OnInit {
  employeeForm: FormGroup = this.fb.group({});
  employeeinfo:EmployeeInfo = new EmployeeInfo();
  employeeinfoList:EmployeeInfo[] = [];
  employeeinfoSelectedList:any[] = [];
  buttonName:string="Save";
  constructor(
    private fb: FormBuilder,
    private service:EmployeeService
    
  ) { }

  ngOnInit(): void {
    this.initial();
    this.LoadDropDown();
  }
  initial(){
    this.employeeForm = this.fb.group({
      employeeName:[""],
      employeeAge:[0],
      employeeInfo:[0,Validators.required],
      employeeId2:[""]
    });
  }
  onSubmit(){
    let employee = this.employeeForm.value.employeeName;
    alert(employee);
    let age = this.employeeForm.controls["employeeAge"].value;
    alert(age);
    this.employeeinfo = this.employeeForm.value;
    console.log(this.employeeinfo);
    this.service.addEmployee(this.employeeinfo).subscribe(
    (res)=>{
      if(res.status){
        alert(res.message);
        this.LoadDropDown();
      }
    }
    );
  }

  LoadDropDown(){
    this.service.getAllEmployeeInfo().subscribe(
      (data)=>{
        this.employeeinfoList = data
        this.employeeinfoSelectedList = new Array();
            this.employeeinfoSelectedList.push({ label: "Select", value: 0 });
            for (var i = 0; i < this.employeeinfoList.length; i++) {
              this.employeeinfoSelectedList.push({
                label: this.employeeinfoList[i].employeeName,
                value: this.employeeinfoList[i].id,
              });
            }
      }
    );
  }

  editData(rowData:EmployeeInfo){
    this.employeeForm.patchValue({
      employeeName:rowData.employeeName,
      employeeAge:rowData.employeeAge,
      employeeId2:rowData.employeeId
    });

    this.buttonName="Update";
  }



}
