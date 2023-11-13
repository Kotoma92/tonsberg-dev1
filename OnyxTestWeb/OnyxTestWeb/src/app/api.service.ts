import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly apiUrl = 'http://localhost:5275/api';

  constructor(private http: HttpClient) { }

  verifyVat(countryCode: string, vatId: string) {
    return this.http.get(`${this.apiUrl}/Vat/${countryCode}/${vatId}`);
  }
}
