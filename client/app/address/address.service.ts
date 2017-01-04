import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Address } from './address.model';

@Injectable()
export class AddressService {
    constructor(private http: Http) {
    }

    get(road: string) {
        let params = new URLSearchParams();
        params.append('searchstring', road);
        return this.http
            .get('http://tommeplan.azurewebsites.net/api/address', {
                search: params
            })
            .map(response => {
                return this.map(response.json());
            });
    }

    private map(addresses: any[]) {
        return addresses.map(x => new Address(x.id, x.city, x.road));
    }
}