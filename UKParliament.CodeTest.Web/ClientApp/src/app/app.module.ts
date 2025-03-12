import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ExerciseComponent } from './pages/exercise/exercise.component';
import { PeopleComponent } from './pages/people/people.component';
import { PersonFormComponent } from './pages/people/components/person-form/person-form.component';
import { CardComponent } from './pages/people/components/card/card.component';
import { ErrorListComponent } from './pages/people/components/error-list/error-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ExerciseComponent,
    PeopleComponent,
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    ReactiveFormsModule,
    PersonFormComponent,
    ErrorListComponent,
    CardComponent,
    RouterModule.forRoot([
      { path: 'exercise', component: ExerciseComponent, pathMatch: 'full' },
      { path: '', component: PeopleComponent, pathMatch: 'full' },
    ]),
  ],
  providers: [provideHttpClient(withInterceptorsFromDi())],
})
export class AppModule {}
