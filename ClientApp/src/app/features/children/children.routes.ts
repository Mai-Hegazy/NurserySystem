import { Routes } from '@angular/router';
import { ChildListPageComponent } from './pages/child-list-page/child-list-page.component';
import { ChildFormPageComponent } from './pages/child-form-page/child-form-page.component';

export const CHILDREN_ROUTES: Routes = [
  { path: '', component: ChildListPageComponent },
  { path: 'add', component: ChildFormPageComponent },
  { path: 'edit/:id', component: ChildFormPageComponent }
];
