import { TestBed } from '@angular/core/testing';

import { GenreItemService } from './genre-item.service';

describe('GenreItemService', () => {
  let service: GenreItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GenreItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
