import { Component } from '@angular/core';
import { PlanListComponent } from './plan-list.component';
import { NotificationButtonComponent } from './notification-button.component';

@Component({
    selector: 'tp-plan',
    templateUrl: 'build/+plan/plan.component.html',
    directives: [PlanListComponent, NotificationButtonComponent]
})
export class PlanComponent {
}