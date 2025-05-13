import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildFormPageComponent } from './child-form-page.component';

describe('ChildFormPageComponent', () => {
  let component: ChildFormPageComponent;
  let fixture: ComponentFixture<ChildFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildFormPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
