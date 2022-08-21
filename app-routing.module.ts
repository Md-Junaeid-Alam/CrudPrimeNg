import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeCreateComponent } from './components/employee-create/employee-create.component';
import { EmployeeInfoComponent } from './components/employee-info/employee-info.component';

const routes: Routes = [
  {path:'employee-list',component:EmployeeInfoComponent},
  {path:'employee-create',component:EmployeeCreateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
