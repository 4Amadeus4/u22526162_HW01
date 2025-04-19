import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductApiRequestsService } from '../services/product-api-requests.service';
import { Product } from '../models/product.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-product',
  standalone: false,
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.scss'
})
export class EditProductComponent {
  product!: Product;

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private productDataService: ProductApiRequestsService
  ) {}

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.productDataService.getProduct(id).subscribe(product => {
      this.product = product;
    });
  }

  saveChanges() {
    this.productDataService.updateProduct(this.product).subscribe(() => {
      this.router.navigate(['/products']);
    });
  }
}
