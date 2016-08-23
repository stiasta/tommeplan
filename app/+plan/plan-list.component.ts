import { Component, OnInit } from '@angular/core';
import { PlanService } from './plan.service';
import { Plan } from './plan.model';

@Component({
    selector: 'tp-plan-list',
    templateUrl: 'build/+plan/plan-list.component.html'
})
export class PlanListComponent implements OnInit {
    plan: Plan;
    constructor(private service: PlanService) {
    }

    ngOnInit() {
        this.service
            .get('Blåklokkevegen')
            .subscribe(plan => {
                this.plan = plan;
            });
    }
}