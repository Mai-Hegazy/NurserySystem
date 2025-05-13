import { Routes } from '@angular/router';
import { ChildListPageComponent } from './features/children/pages/child-list-page/child-list-page.component';

export const routes: Routes = [
    // { path: 'children', component: ChildListComponent },
    {
        path: 'children',
        loadChildren: () =>
          import('./features/children/children.routes').then(m => m.CHILDREN_ROUTES),
      }
      
];
