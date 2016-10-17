import { LocalNotifications } from 'ionic-native';
import { Alert, AlertController, Platform } from 'ionic-angular';
import { Component } from '@angular/core';
import { PlanService } from './plan.service';
import * as moment from 'moment';
@Component({
    selector: 'tp-notification-button',
    templateUrl: 'build/+plan/notification-button.component.html',
})
export class NotificationButtonComponent {
    private alert: Alert;
    private isCordova: boolean;
    constructor(
        private service: PlanService,
        private platform: Platform,
        private alertCtrl: AlertController) {

        this.alert = this.alertCtrl.create({
            title: 'Oppretter varsler',
            message: 'Varslinger blir opprettet og vil komme en dag før tømmeperioden starter. ',
            buttons: ['Ok']
        });

        this.init();
    }

    private init() {
        this.platform
            .ready()
            .then(value => {
                this.isCordova = value === 'cordova';
            });
    }

    createNotification() {
        if (!this.isCordova) {
            this.alertCtrl.create({
                title: 'Ingen varslinger',
                message: 'Ikke mulig å opprette varslinger på denne enheten.',
                buttons: ['Ok']
            }).present();

            return;
        }

        this.alert
            .present()
            .then(() => {
                this.service
                    .getLatest()
                    .subscribe(plan => {
                        LocalNotifications
                            .cancelAll()
                            .then(() => {
                                let counter = 0;

                                LocalNotifications.schedule(
                                    plan.activeWeeks()
                                        .map(week => {
                                            let startDate =
                                                moment(week.getStartDate())
                                                    .hour(10)
                                                    .minute(0)
                                                    .subtract(1, 'day');
                                            // console.log({
                                            //     id: counter++,
                                            //     title: 'Søpla blir hentet i løpet av uken.',
                                            //     text: `Husk å gjøre klar for henting av ${week.types}.`,
                                            //     at: startDate.toDate()
                                            // });

                                            return {
                                                id: counter++,
                                                title: 'Tømmeplan for neste uke.',
                                                text: `Neste uke så er det ${week.types}.`,
                                                at: startDate.toDate()
                                            };
                                        }));
                            });
                    });
            });
    }
}