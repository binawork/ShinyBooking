import { async, TestBed } from '@angular/core/testing';
import { FiltersBarComponent } from './filters-bar.component';
describe('FiltersBarComponent', () => {
    let component;
    let fixture;
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [FiltersBarComponent]
        })
            .compileComponents();
    }));
    beforeEach(() => {
        fixture = TestBed.createComponent(FiltersBarComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=filters-bar.component.spec.js.map