import {Component} from '@angular/core';
import {Platform, ionicBootstrap} from 'ionic-angular';
import {StatusBar} from 'ionic-native';
import {HomeComponent} from './+home/home.component';
import { PlanService, StorageService } from './+plan/index';

@Component({
  template: '<ion-nav [root]="rootPage"></ion-nav>',
  providers: [PlanService, StorageService]
})
export class MyApp {
  rootPage: any = HomeComponent;

  constructor(platform: Platform) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      StatusBar.styleDefault();
    });
  }
}

ionicBootstrap(MyApp);