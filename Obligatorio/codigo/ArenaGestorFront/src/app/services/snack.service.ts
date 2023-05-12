import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SnackResultSnackDto } from '../models/Snacks/SnackResultSnackDto';
import { SnackInsertSnackDto } from '../models/Snacks/SnackInsertSnackDto';

@Injectable({
  providedIn: 'root'
})
export class SnackService {

  private apiUrl: string

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiURL + "snacks"
  }

  Get(): Observable<Array<SnackResultSnackDto>> {
    return this.http.get<Array<SnackResultSnackDto>>(this.apiUrl)
  }

  GetById(id: Number): Observable<SnackResultSnackDto> {
    return this.http.get<SnackResultSnackDto>(this.apiUrl + "/" + id.toString())
  }

  Insert(snack: SnackInsertSnackDto): Observable<SnackResultSnackDto> {
    return this.http.post<SnackResultSnackDto>(this.apiUrl, snack)
  }

  Delete(id: Number) {
    return this.http.delete(this.apiUrl + "/" + id.toString())
  }

}
