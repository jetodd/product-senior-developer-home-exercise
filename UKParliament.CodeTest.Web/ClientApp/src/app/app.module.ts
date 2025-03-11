import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ExerciseComponent } from './components/exercise/exercise.component';
import { PeopleComponent } from './components/people/people.component';

@NgModule({ declarations: [
        AppComponent,
        ExerciseComponent,
        PeopleComponent,
    ],
    bootstrap: [AppComponent], imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: 'exercise', component: ExerciseComponent, pathMatch: 'full' },
            { path: 'people', component: PeopleComponent, pathMatch: 'full'},
        ])], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
