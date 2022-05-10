import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientListComponent } from './Components/client-list/client-list.component';
import { ClientComponent } from './Components/client/client.component';
import { ResidentialComponent } from './Components/residential/residential.component';

const routes: Routes = [
  {path: 'client', component: ClientComponent},
  {path: 'clients', component: ClientListComponent},
  {path: 'residential', component: ResidentialComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
