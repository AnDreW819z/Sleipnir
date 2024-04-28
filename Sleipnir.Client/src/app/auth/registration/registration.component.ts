import { Component } from '@angular/core';
import { Registration } from '../interfaces/registration';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    //Location
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegisterComponent {

  constructor(
    private authService: AuthService,
    private router: Router,
    
  ) {}

  public RegisterForm = new FormGroup({
    name: new FormControl<string>('', Validators.required),
    email: new FormControl<string>('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl<string>('', Validators.required),
    confirmPassword: new FormControl<string>('', Validators.required)
  });

  public get name(): FormControl<string> {
    return this.RegisterForm.get('name') as FormControl<string>;
  }

  public get email(): FormControl<string> {
    return this.RegisterForm.get('email') as FormControl<string>;
  }

  public get password(): FormControl<string> {
    return this.RegisterForm.get('password') as FormControl<string>;
  }

  public get confirmPassword(): FormControl<string> {
    return this.RegisterForm.get('confirmPassword') as FormControl<string>;
  }
  

  public register(): void {
    let RegisterModel: Registration = {
      userAvatar: this.name.value,
      email: this.email.value,
      password: this.password.value,
      passwordConfirm: this.confirmPassword.value
    };
    this.authService.register(RegisterModel).subscribe(() => {
      this.router.navigate(['/login']);
    });
  }

  public goBack(): void {
    //this.location.back();
    this.router.navigate(['/login']);
  }

}
