import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GenderGetGendersDto } from 'src/app/models/Genders/GenderGetGendersDto';
import { GenderResultGenderDto } from 'src/app/models/Genders/GenderResultGenderDto';
import { GenderService } from 'src/app/services/gender.service';

@Component({
  templateUrl: './genders.component.html'
})
export class GendersComponent implements OnInit {

  genderList: Array<GenderResultGenderDto> = new Array<GenderResultGenderDto>()
  filter: String = "";
  genderToDelete: Number = 0;

  constructor(private toasts: ToastrService, private service: GenderService, private router: Router) { }

  ngOnInit(): void {
    this.GetData()
  }

  GetData() {
    let filterDto: GenderGetGendersDto = { name: this.filter };
    this.service.Get(filterDto).subscribe(res => {
      this.genderList = res
    })
  }

  SetGenderToDelete(id: Number) {
    this.genderToDelete = id;
  }

  Delete() {
    this.service.Delete(this.genderToDelete).subscribe(res => {
      this.toasts.success("Genero eliminado correctamente", "Éxito")
      this.GetData();
    },
      err => {
        this.toasts.error(err.error, "Error")
      })
  }
}
