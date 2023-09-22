import { Component, OnInit, ViewChild } from '@angular/core';
import { PersonService } from '../../api/person.service';
import { FormBuilder } from '@angular/forms';
import { Person } from '../../models/person'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
})
export class PersonListComponent {
  constructor(
    private personService: PersonService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.addActionDisplayColumn = this.displayedColumns.concat(['action']);
  }

  public searchForm = this.formBuilder.nonNullable.group({
    searchTerm: '',
    isApproved: false,
  });

  // @ViewChild(MatPaginator) public paginator!: MatPaginator;

  public columns = [
    {
      columnDef: 'Name',
      header: 'Name',
      cell: (element: Person): string =>
        `${element?.firstName} ${element?.lastName}`,
    },
    {
      columnDef: 'isEnabled',
      header: 'Enabled',
      cell: (element: Person): boolean | undefined => element?.isEnabled,
    },
    {
      columnDef: 'isValid',
      header: 'Valid',
      cell: (element: Person): boolean | undefined => element?.isValid,
    },
    {
      columnDef: 'isAuthorized',
      header: 'Authorized',
      cell: (element: Person): boolean | undefined => element?.isAuthorized,
    },
    {
      columnDef: 'isPallndrome',
      header: 'Pallndrome',
      cell: (element: Person): boolean | undefined => element?.isPallndrome,
    },
  ];
  public displayedColumns = this.columns.map((column) => column.columnDef);
  public addActionDisplayColumn: string[] = [];
  public colSpanNumber!: number;

  public tableView$ = this.personService.GetPersons();
}
