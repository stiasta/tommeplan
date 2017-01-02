import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { PlanService } from './plan.service';
import { Plan } from './plan.model';
import { Week } from './week.model';
import { AddressPickerComponent } from '../address/address-picker.component';
import { ModalController } from 'ionic-angular';
import { Subscription, Subject } from 'rxjs/Rx';
@Component({
    selector: 'tp-plan-list',
    templateUrl: 'build/+plan/plan-list.component.html',
    directives: [AddressPickerComponent]
})
export class PlanListComponent implements OnInit {
    plan: Plan;
    searchInput: string;

    constructor(
        private service: PlanService,
        public modalCtrl: ModalController) {
        this.resetPlan();
    }

    ngOnInit() {
        this.service
            .getLatest()
            .subscribe(plan => {
                this.searchInput = plan.toPrettyString();
                this.plan = plan;
            });
    }

    openModal(inputaddress) {
        let modal = this.modalCtrl.create(AddressPickerComponent);
        modal.onDidDismiss((plan: Plan) => {
            if (plan) {
                this.plan = plan;
                this.searchInput = plan.toPrettyString();
            }
        });

        modal.present();
    }

    private resetPlan() {
        this.plan = { road: '', weeks: [], activeWeeks: () => [], city: '', id: '', toPrettyString: () => '' };
        this.searchInput = "Trykk for å velge gate";
    }
}