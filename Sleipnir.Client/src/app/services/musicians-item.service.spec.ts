import { TestBed } from '@angular/core/testing';

import { MusiciansItemService } from './musicians-item.service';

describe('MusiciansItemService', () => {
  let service: MusiciansItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MusiciansItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
