import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonListComponent } from './components/person-list/person-list.component';
import { PersonManageComponent } from './components/person-manage/person-manage.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'person',
    pathMatch: 'full',
  },
  {
    path: 'person',
    component: PersonListComponent,
  },
  {
    path: 'person/add',
    component: PersonManageComponent,
    pathMatch: 'full',
  },
  {
    path: 'person/edit/:id',
    component: PersonManageComponent,
    pathMatch: 'full',
  },
  {
    path: 'person/:edit',
    component: PersonManageComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PersonRoutingModule {}
