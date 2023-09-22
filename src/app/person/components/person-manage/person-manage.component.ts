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
    private router: Router,
  ) {}
  public sports$ = this.sharedService.GetSports();

  public personManageForm = this.formBuilder.nonNullable.group({
    firstName: '',
    lastName: '',
    isValid: false,
    isAuthorized: false,
    isEnabled: false,
    isPallndrome: false,
  });

  public person!: Person;

  public addActive: boolean = false;
  public editActive: boolean = false;
  public detailActive: boolean = false;
  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['add'] == 'add') {
        this.addActive = !this.addActive;
      }
      if (params['add'] == 'edit') {
        this.editActive = !this.editActive;
      }
      if (params['id'] == 'id') {
        this.detailActive = !this.detailActive;
      }

      //I am having issues with routing so I hade to do this spagetti
    });
  }
  add() {
    this.person = {
      id: '',
      firstName: this.personManageForm.value.firstName,
      lastName: this.personManageForm.value.lastName,
      isAuthorized: this.personManageForm.value.isAuthorized,
      isValid: this.personManageForm.value.isValid,
      isPallndrome: this.personManageForm.value.isPallndrome,
      isEnabled: this.personManageForm.value.isEnabled,
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

  clear() {
    this.personManageForm.reset();
  }
}
