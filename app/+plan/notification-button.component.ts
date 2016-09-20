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
    constructor(
        private service: PlanService,
        private platform: Platform,
        private alertCtrl: AlertController) {

        this.alert = this.alertCtrl.create({
            title: 'Opprett varsler?',
            message: 'Hvis du trykker Ok, så vil varsler bli opprettet og komme en dag før uken starter.',
            buttons: [
                {
                    title: 'Avbryt',
                    handler: () => false
                },
                {
                    title: 'Ok',
                    handler: () => true
                }]
        });
    }

    createNotification() {
        if (!this.platform.is('mobileweb')) {
            this.alertCtrl.create({
                title: 'Ingen varslinger',
                message: 'Ikke mulig å opprette varslinger på denne enheten.',
                buttons: ['Ok']
            }).present();

            return;
        }

        this.alert
            .present()
            .then(isConfirmed => {
                if (isConfirmed) {
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
                                                let startDate = moment(week.getStartDate());
                                                return {
                                                    id: counter++,
                                                    title: 'Søpla blir hentet i morgen.',
                                                    text: `Husk å gjøre klar for henting av ${week.types}.`,
                                                    at: startDate.subtract(1)
                                                };
                                            }));
                                });
                        });
                }
            });
    }
}