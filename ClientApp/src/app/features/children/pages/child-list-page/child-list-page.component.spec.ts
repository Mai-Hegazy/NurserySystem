import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ChildListPageComponent } from './child-list-page.component';


describe('ChildListComponent', () => {
  let component: ChildListPageComponent;
  let fixture: ComponentFixture<ChildListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildListPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
