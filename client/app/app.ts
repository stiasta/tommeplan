import {Component} from '@angular/core';
import {Platform, ionicBootstrap} from 'ionic-angular';
import {StatusBar} from 'ionic-native';
import {HomeComponent} from './+home/home.component';
import { PlanService, StorageService } from './+plan/index';
import { AddressService } from './address/address.service';

@Component({
  template: '<ion-nav [root]="rootPage"></ion-nav>',
})
export class MyApp {
  rootPage: any = HomeComponent;

  constructor(platform: Platform) {
    const foo = { bar: 'foobar'};
    console.log(foo);
    delete foo.bar;
    console.log(foo);
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
    });
  }
}

ionicBootstrap(MyApp, [AddressService, PlanService, StorageService]);
