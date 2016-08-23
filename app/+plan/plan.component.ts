import { Component } from '@angular/core';
import { PlanListComponent } from './plan-list.component';

@Component({
    selector: 'tp-plan',
    templateUrl: 'build/+plan/plan.component.html',
    directives: [PlanListComponent]
})
export class PlanComponent {
}