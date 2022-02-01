import { Component, OnInit } from '@angular/core';
import { WebApiService } from '../../Services/web-api.service';
import { Product } from 'src/Models/Product';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.scss']
})
export class AllProductsComponent implements OnInit {

  products: Array<Product> = [];
  constructor(private WebApiService: WebApiService) { }

  ngOnInit(): void {
    console.log("kooooooooiiiii");
    this.GetAllProducts();
  }

  GetAllProducts() {
    this.WebApiService.getAllProducts().subscribe(
      (data: Product[]) => {
        this.products = data.map(x => Object.assign({}, x));
      }
    );
  }
}
