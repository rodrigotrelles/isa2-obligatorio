import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';

@Component({
  templateUrl: './snacks.component.html'
})
export class SnacksComponent implements OnInit {

  snacksList: Array<SnackResultSnackDto> = new Array<SnackResultSnackDto>()
  snackToDelete: Number = 0;

  constructor(private toasts: ToastrService, private service: SnackService, private router: Router) { }

  ngOnInit(): void {
    this.GetData()
  }

  GetData() {
    this.service.Get().subscribe(res => {
      this.snacksList = res
    })
  }

  SetSnackToDelete(id: Number) {
    this.snackToDelete = id;
  }

  Delete() {
    this.service.Delete(this.snackToDelete).subscribe(res => {
      this.toasts.success("Snack eliminado correctamente", "Éxito")
      this.GetData();
    },
      err => {
        this.toasts.error(err.error, "Error")
      })
  }
}
