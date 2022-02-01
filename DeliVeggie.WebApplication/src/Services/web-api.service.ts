import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';  
import { Product } from '../Models/Product'; 

@Injectable({
  providedIn: 'root'
})
export class WebApiService {

  private API_URL = "https://localhost:5001";

  constructor(private httpClient: HttpClient) { }

  getAllProducts(): Observable<Product[]> {  
    return this.httpClient.get<Product[]>(this.API_URL + '/Product');  
  }  
  getProductById(id:string): Observable<Product> {  
    return this.httpClient.get<Product>(this.API_URL + '/Product/' + id);  
  }
}
