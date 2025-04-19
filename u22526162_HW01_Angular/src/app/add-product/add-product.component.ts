import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ProductApiRequestsService } from '../services/product-api-requests.service';
import { Product } from '../models/product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  standalone: false,
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.scss'
})
export class AddProductComponent {
    product: Product = {
      productId: 0, // assigned by the API
      productName: '',
      productPrice: 0,
      productDescription: ''
    };

    errorMessage = '';

    constructor(
      private productService: ProductApiRequestsService,
      public router: Router
    ) {}

    onSubmit() {
      if (this.isValidProduct()) {
        this.errorMessage = '';

        this.productService.addProduct(this.product).subscribe({
          next: () => {
            this.router.navigate(['/products']);
          },
          error: (err) => {
            this.errorMessage = 'Failed to add product. Please try again.';
            console.error('Add product error:', err);
          }
        });
      }
    }

    private isValidProduct(): boolean {
      if (!this.product.productName.trim()) {
        this.errorMessage = 'Product name is required';
        return false;
      }

      if (this.product.productPrice <= 0) {
        this.errorMessage = 'Price must be greater than 0';
        return false;
      }

      return true;
    }
}
