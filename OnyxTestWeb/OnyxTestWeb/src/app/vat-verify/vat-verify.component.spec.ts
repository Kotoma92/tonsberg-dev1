import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VatVerifyComponent } from './vat-verify.component';

describe('VatVerifyComponent', () => {
  let component: VatVerifyComponent;
  let fixture: ComponentFixture<VatVerifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VatVerifyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VatVerifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
