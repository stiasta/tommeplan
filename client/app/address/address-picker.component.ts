import { Component } from '@angular/core';
import * as moment from 'moment';
import { AddressService } from './address.service';
import { PlanService, StorageService } from '../+plan';
import { Address } from './address.model';
import { Subscription, Subject } from 'rxjs/Rx';
import { ViewController } from 'ionic-angular';
import { CORE_DIRECTIVES } from '@angular/common';

@Component({
    selector: 'tp-address-picker',
    templateUrl: 'build/address/address-picker.component.html',
    directives: [CORE_DIRECTIVES]
})
export class AddressPickerComponent {
    searchInput: string;
    addresses: Address[] = [];

    constructor(private addressService: AddressService,
        private planService: PlanService,
        public viewCtrl: ViewController) {
    }

    search() {
        if (!this.searchInput || this.searchInput.length < 3) {
            return;
        }

        this.addressService
            .get(this.searchInput)
            .subscribe(x => this.addresses = x);
    }

    setAddress(address: Address) {
        this.planService
            .getWithId(address.id, address.city, address.road)
            .subscribe(x => this.viewCtrl.dismiss(x));  
    }

    dismiss() {
        this.viewCtrl.dismiss();
    }
}