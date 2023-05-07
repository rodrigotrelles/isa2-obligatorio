import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SnackResultSnackDto } from '../models/Snacks/SnackResultSnackDto';
import { SnackInsertSnackDto } from '../models/Snacks/SnackInsertSnackDto';
import { SnackGetSnacksDto } from '../models/Snacks/SnackGetSnacksDto';

@Injectable({
  providedIn: 'root'
})
export class SnackService {

  private apiUrl: string

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiURL + "snacks"
  }

  Get(filter?: SnackGetSnacksDto): Observable<Array<SnackResultSnackDto>> {
    let url = this.apiUrl
    if (filter && filter.name.length > 0) {
      url = url + "?name=" + filter.name
    }
    return this.http.get<Array<SnackResultSnackDto>>(url)
  }

  GetById(id: Number): Observable<SnackResultSnackDto> {
    return this.http.get<SnackResultSnackDto>(this.apiUrl + "/" + id.toString())
  }

  Insert(gender: SnackInsertSnackDto): Observable<SnackResultSnackDto> {
    return this.http.post<SnackResultSnackDto>(this.apiUrl, gender)
  }

  Update(gender: SnackInsertSnackDto): Observable<SnackResultSnackDto> {
    return this.http.put<SnackResultSnackDto>(this.apiUrl, gender)
  }

  Delete(id: Number) {
    return this.http.delete(this.apiUrl + "/" + id.toString())
  }

}
