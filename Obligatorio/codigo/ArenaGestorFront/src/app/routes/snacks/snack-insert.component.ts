import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackInsertSnackDto } from 'src/app/models/Snacks/SnackInsertSnackDto';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';

@Component({
  templateUrl: './snack-form.component.html'
})
export class SnackInsertComponent {

  mode: String = "Insertar";
  model: SnackInsertSnackDto = new SnackInsertSnackDto();

  constructor(private toastr: ToastrService, private service: SnackService, private router: Router) { }

  Confirm() {
    this.service.Insert(this.model).subscribe(res => {
      this.toastr.success("Snack agregado correctamente", "Éxito")
      this.router.navigate(["/administracion/snacks"])
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }

}
