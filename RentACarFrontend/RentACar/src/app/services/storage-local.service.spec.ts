import { TestBed } from '@angular/core/testing';

import { StorageLocalService } from './storage-local.service';

describe('StorageLocalService', () => {
  let service: StorageLocalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StorageLocalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
