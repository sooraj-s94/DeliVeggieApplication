import { Component, OnInit } from '@angular/core';
import {Product} from 'src/Models/Product';
import { WebApiService } from 'src/Services/web-api.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.scss']
})
export class ProductInfoComponent implements OnInit {
  product!: Product; 
  productId! :string;

  constructor(private WebApiService: WebApiService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void { 
    this.productId = String(this.route.snapshot.paramMap.get('id'));
    this.GetProductDetails();
  }

  GetProductDetails(){
    this.WebApiService.getProductById(this.productId).subscribe(
      (data : Product) => { 
        this.product = data;
      }
    );
  }
}
