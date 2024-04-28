import { Routes } from '@angular/router';
import { PopularComponent } from './components/popular/popular.component';
import { GenreComponent } from './components/genre/genre.component';
import { MoodComponent } from './components/mood/mood.component';
import { MusiciansComponent } from './components/musicians/musicians.component';
import { PlaylistsComponent } from './components/playlists/playlists.component';
import { MusicianAlbumsComponent } from './components/musician-albums/musician-albums.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/registration/registration.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/popular',
    pathMatch: 'full'
  },
  {
    path: 'popular',
    component: PopularComponent,
    canActivate: []
  },
  {
    path: 'musicians',
    component: MusiciansComponent,
    canActivate: []
  },
  {
    path: 'playlists',
    component: PlaylistsComponent,
    canActivate: []
  },
  {
    path: 'genre',
    component: GenreComponent,
    //canActivate: [authGuard]
  },
  {
    path: 'mood',
    component: MoodComponent,
    //canActivate: [authGuard]
  },
  {
    path: 'musicians/:id', 
    component: MusicianAlbumsComponent,
    // canActivate: [authGuard] 
  },
  {
    path: 'login',
    component: LoginComponent,
    //canActivate: [authGuard]
  },
  {
    path: 'register',
    component: RegisterComponent,
    //canActivate: [authGuard]
  },
  {
    path: 'user',
    component: GenreComponent,
    //canActivate: [authGuard]
  },
];

