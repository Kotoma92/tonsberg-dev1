import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../api.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
 selector: 'app-vat-verify',
 templateUrl: './vat-Verify.component.html',
 styleUrls: ['./vat-Verify.component.css']
})

export class VatVerifyComponent {
  country = '';
  vatId = '';
  vatResponse: any;

 constructor(private http: HttpClient) { }

 //TODO use the ApiService to verify the VAT instead of the HttpClient
  verifyVat() {
    const url = `http://localhost:5275/api/Vat/${this.country}/${this.vatId}`;
    console.log(url);
    this.http.get(url, {responseType: 'text'}).subscribe(response => {
      console.log(response);
      this.vatResponse = response;
    });
  }
}

@NgModule({
  declarations: [VatVerifyComponent],
  imports: [CommonModule, FormsModule, HttpClientModule],
  exports: [VatVerifyComponent]
})
export class VatVerifyModule { }




