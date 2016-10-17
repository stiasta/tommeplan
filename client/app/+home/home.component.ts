import {Component} from '@angular/core';
import { PlanComponent } from '../+plan/plan.component';

@Component({
    template: '<tp-plan></tp-plan>',
    directives: [PlanComponent]
})
export class HomeComponent {
}