import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarStaticComponent } from './navbar-static.component';

describe('NavbarStaticComponent', () => {
  let component: NavbarStaticComponent;
  let fixture: ComponentFixture<NavbarStaticComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarStaticComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarStaticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
