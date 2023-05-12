import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackGetSnacksDto } from 'src/app/models/Snacks/SnackGetSnacksDto';
import { SnackResultSnackDto } from 'src/app/models/Snacks/SnackResultSnackDto';
import { SnackService } from 'src/app/services/snack.service';

@Component({
  templateUrl: './snacks.component.html'
})
export class SnacksComponent implements OnInit {

  snacksList: Array<SnackResultSnackDto> = new Array<SnackResultSnackDto>()
  filter: String = "";
  snackToDelete: Number = 0;

  constructor(private toasts: ToastrService, private service: SnackService, private router: Router) { }

  ngOnInit(): void {
    this.GetData()
  }

  GetData() {
    let filterDto: SnackGetSnacksDto = { name: this.filter };
    this.service.Get(filterDto).subscribe(res => {
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
