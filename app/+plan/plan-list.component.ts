import { Component, OnInit, OnDestroy } from '@angular/core';
import * as moment from 'moment';
import { PlanService } from './plan.service';
import { Plan } from './plan.model';
import { Week }from './week.model';
import { Subscription, Subject } from 'rxjs/Rx';
@Component({
    selector: 'tp-plan-list',
    templateUrl: 'build/+plan/plan-list.component.html'
})
export class PlanListComponent implements OnInit, OnDestroy {
    plan: Plan;
    searchInput: string;
    private subscription: Subscription;
    private getPlanSource: Subject<string> = new Subject<string>();

    constructor(private service: PlanService) {
        this.resetPlan();
    }

    ngOnInit() {
        this.service.getLatest()
            .subscribe(plan => {
                this.searchInput = plan.road;
                this.plan = plan;
            });

        this.getPlanSource
            .debounceTime(1000)
            .subscribe(road => {
                if (this.subscription && !this.subscription.isUnsubscribed) {
                    this.subscription.unsubscribe();
                }

                this.subscription = this.service
                    .get(road)
                    .subscribe(plan => {
                        this.plan = plan;
                    });
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    search(event: any) {
        if (!event) {
            this.resetPlan();
            return;
        }

        let val = this.searchInput;
        if (!val && val.trim() === '') {
            this.resetPlan();
            return;
        }

        this.getPlan(val);
    }

    private getPlan(road: string) {
        this.getPlanSource.next(road);
    }

    private resetPlan() {
        this.plan = { road: '', weeks: [], activeWeeks: () => [] };
    }
}