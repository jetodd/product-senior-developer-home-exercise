import { Pipe, PipeTransform } from '@angular/core';
import { DepartmentService } from '../services/department.service';
import { DepartmentViewModel } from '../models/department-view-model';

@Pipe({
  name: 'departmentFilter',
  pure: false,
  standalone: true,
})
export class DepartmentFilterPipe implements PipeTransform {
  transform(id: number, departments: DepartmentViewModel[]): any {
    const selectedDepartment = departments.find((d) => d.id === id);

    return selectedDepartment ? selectedDepartment.name : 'Unknown Department';
  }
}
