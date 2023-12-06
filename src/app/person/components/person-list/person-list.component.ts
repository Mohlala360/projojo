import { Component, OnInit, ViewChild } from '@angular/core';
import { PersonService } from '../../api/person.service';
import { FormBuilder } from '@angular/forms';
import { Person } from '../../models/person';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { PersonManageComponent } from '../person-manage/person-manage.component';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
})
export class PersonListComponent {
  displayedColumns = [
    'id',
    'title',
    'completed', 
    'action'
  ];

  dataSource!: MatTableDataSource<Person>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private personService: PersonService,
    public dialog: MatDialog,
    private router: Router
  ) {
    this.personService.GetPersons().subscribe((persons) => {

      console.log(persons)
      this.dataSource = new MatTableDataSource(persons);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  } 
  updateRowData(row_obj: Person) {
    this.router.navigate(['/person/edit',row_obj.id]);
  } 
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(target: any) {
    var filterValue = target.value;
    if (filterValue.length > 0) {
      filterValue = filterValue.trim();
      filterValue = filterValue.toLowerCase();
      this.dataSource.filter = filterValue;
    }
  }
}
