import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Events } from 'src/app/app.events';
import { SecurityRegisterDto } from 'src/app/models/Security/SecurityRegisterDto';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  user: SecurityRegisterDto = new SecurityRegisterDto();
  error: String = "";

  constructor(private security: SecurityService, private events: Events, private router: Router) { }

  ngOnInit(): void {}

  Register() {
    // this.security.Login(this.user).subscribe(
    //   (response: any) => {
    //     this.error = ""
    //     this.router.navigate(['/']);
    //   },
    //   err => {
    //     this.error = ""
    //     if (err.status == 400) {
    //       for (const [key, value] of Object.entries(err.error.errors)) {
    //         let values = Object(value)
    //         for (let i = 0; i < values.length; i++) {
    //           this.error = this.error + values[i] + "<br>";
    //         }
    //       }
    //     } else {
    //       this.error = err.error
    //     }
    //   }
    // )
  }

}
