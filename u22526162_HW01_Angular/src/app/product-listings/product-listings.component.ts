import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductApiRequestsService } from '../services/product-api-requests.service'; // Import service
import { Product } from '../models/product.model';

@Component({
  selector: 'app-product-listings',
  standalone: false,
  templateUrl: './product-listings.component.html',
  styleUrl: './product-listings.component.scss'
})
export class ProductListingsComponent {
  products: Product[] = [];

  constructor(private apiReq: ProductApiRequestsService) {} // inject service
  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.apiReq.getProducts().subscribe({
      next: (data) => this.products = data,
      error: (err) => console.error('Failed to load products:', err)
    });
  }

  handleDelete(productId: number) {
    this.apiReq.deleteProduct(productId).subscribe({
      next: () => {
        this.products = this.products.filter(p => p.productId !== productId);
      },
      error: (err) => console.error('Failed to delete:', err)
    });
  }
}
