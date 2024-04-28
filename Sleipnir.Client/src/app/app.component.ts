import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavigationComponent } from './components/navigation/navigation.component';
import { HeaderComponent } from './components/header/header.component';
import { GenreComponent } from './components/genre/genre.component';
import { PlayerComponent } from './components/player/player.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/registration/registration.component';
import { AuthService } from './auth/auth.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
    RouterOutlet, 
    NavigationComponent,
    HeaderComponent,
    GenreComponent,
    PlayerComponent,
    LoginComponent,
    RegisterComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'music-playlist';

  constructor(
    private authService: AuthService,
  ) {}

  public openAuth() {
    return this.authService.openAuth;
  }
}
