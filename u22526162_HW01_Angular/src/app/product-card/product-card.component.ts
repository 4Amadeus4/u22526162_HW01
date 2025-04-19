import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../models/product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-card',
  standalone: false,
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss'
})
export class ProductCardComponent {
  @Input() product!: Product;
  @Output() delete = new EventEmitter<number>();

  constructor(private router: Router) {}

  onEdit() {
    this.router.navigate(['/edit', this.product.productId]);
  }

  onDelete() {
    this.delete.emit(this.product.productId);
  }

  get formattedPrice(): string {
    return `R${this.product.productPrice.toFixed(2)}`;
  }
}
