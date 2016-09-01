import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { PlanService } from './plan.service';
import { Plan } from './plan.model';
import { Week }from './week.model';

@Component({
    selector: 'tp-plan-list',
    templateUrl: 'build/+plan/plan-list.component.html'
})
export class PlanListComponent implements OnInit {
    plan: Plan;
    constructor(private service: PlanService) {
        this.plan = { weeks: [], activeWeeks: () => [] };
    }

    ngOnInit() {
        this.service
            .get('Blåklokkevegen')
            .subscribe(plan => {
                this.plan = plan;
            });
    }

    startDate(week: Week) {
        return moment(week.getStartDate()).format('DD.MM');
    }

    endDate(week: Week) {
        return moment(week.getEndDate()).format('DD.MM');
    }
}