import { TestBed } from '@angular/core/testing';

import { ProductApiRequestsService } from './product-api-requests.service';

describe('ProductApiRequestsService', () => {
  let service: ProductApiRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductApiRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
