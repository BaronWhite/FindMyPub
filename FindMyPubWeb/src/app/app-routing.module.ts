import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PubListComponent } from './pub/pub-list/pub-list.component';
import { PubComponent } from './pub/pub/pub.component';


const routes: Routes = [
  {
    path: '', component: PubListComponent,
    children: [
      {
        path: ':pubId', component: PubComponent
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
