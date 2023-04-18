import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Events } from 'src/app/app.events';
import { SecurityRegisterDto } from 'src/app/models/Security/SecurityRegisterDto';
import { SecurityService } from 'src/app/services/security.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  user: SecurityRegisterDto = new SecurityRegisterDto();
  error: String = "";

  constructor(private security: SecurityService, private events: Events, private router: Router, private toasts: ToastrService) { }

  Register() {
    this.security.Register(this.user).subscribe(
      res => {
      this.toasts.success("Usuario registrado correctamente. Porfavor, inicie sesión", "Éxito")
      },
      err => {
        this.error = err.error;
      }
    );
  }

}
