import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../api/person.service';
import { SharedService } from 'src/app/shared/api/shared.service';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from '../../models/person';
// @ts-ignore
import { v4 as uuidv4 } from 'uuid';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-person-manage',
  templateUrl: './person-manage.component.html',
})
export class PersonManageComponent implements OnInit {
  constructor(
    private personService: PersonService,
    private sharedService: SharedService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}
  public sports$ = this.sharedService.GetSports();

  public personManageForm = this.formBuilder.nonNullable.group({
    title: '', 
    completed: false, 
  });

  public person!: Person;

  public addActive: boolean = false;
  public editActive: boolean = false;
  public detailActive: boolean = false;
  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['id']) {
        this.personService.GetPerson(params['id']).subscribe((person) => {
          this.person = person;
          this.setPersonData();
        });
      }
    });
  }
  add() {
    this.person = {
      id: '',
      title: this.personManageForm.value.title,
      completed: this.personManageForm.value.completed,
    };
    this.personService
      .CreatePerson(this.person)
      .pipe()
      .subscribe((p) => {
        this.clear();
        if (p.id.length > 0) {
          this.snackBar.open('Saved Sharp');
          this.router.navigate(['/person']);
        }
      });
  }
  setPersonData() {
    this.personManageForm.patchValue(this.person);
  }
  clear() {
    this.personManageForm.reset();
  }

  update() {
    this.person = {
      id: this.person.id,
      title: this.personManageForm.value.title, 
      completed: this.personManageForm.value.completed,
    };
    
    this.personService
      .UpdatePerson(this.person.id, this.person)
      .pipe()
      .subscribe((p) => {
        this.snackBar.open('Updated  Sharp');
      });
  }
}
