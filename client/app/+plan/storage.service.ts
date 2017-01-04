import { Injectable } from '@angular/core';
import { NativeStorage } from 'ionic-native';
import { Platform } from 'ionic-angular';
import { Observable } from 'Rxjs/Rx';
import { Storage, LocalStorage } from 'ionic-angular';
import { Plan } from './plan.model';
import { Week } from './week.model';

@Injectable()
export class StorageService {
    private _isPlatformReady: boolean;
    private _isCordova: boolean;
    private _localStorage: Storage;
    constructor(private platform: Platform) {
        this._isPlatformReady = false;
        this.platform
            .ready()
            .then(value => {
                this._isPlatformReady = true;
                this._isCordova = value === 'cordova';
                if (!this._isCordova) {
                    this._localStorage = new Storage(LocalStorage);
                }
            });
    }

    set(key: string, value: any) {
        let setItem = () => {
            let json = JSON.stringify(value);
            if (this._isCordova) {
                return Observable.fromPromise(NativeStorage.setItem(key, json));
            }

            // defaulting to web browser local storage.
            return Observable.fromPromise(this._localStorage.set(key, json));
        };

        return this._isPlatformReady ?
            setItem() :
            Observable.fromPromise(this.platform.ready()).flatMap(setItem);
    }

    get(key: string) {
        let getItem = () => {
            let observable = this._isCordova ?
                Observable.fromPromise(NativeStorage.getItem(key)) : // using native storage
                Observable.fromPromise(this._localStorage.get(key)); // defaulting to localstorage

            return observable.map(json => {
                var plan = JSON.parse(json);
                return new Plan(
                    plan.weeks
                        .map(week =>
                            new Week(week.weekNumber, week.types)),
                    plan.road, 
                    plan.city, 
                    plan.id);
            });
        };

        return this._isPlatformReady ?
            getItem() :
            Observable.fromPromise(this.platform.ready()).flatMap(getItem);
    }
}