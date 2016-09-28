import {Injectable} from '@angular/core';
import {Http, Headers, URLSearchParams} from '@angular/http';
import * as $ from 'jquery';
import {Observable} from 'rxjs/Rx';
import {Plan} from './plan.model';
import {Week} from './week.model';
import {StorageService} from './storage.service';
import {Platform} from 'ionic-angular';

@Injectable()
export class PlanService {
    constructor(
		private http: Http,
        private platform: Platform,
		private storage: StorageService) {
    }

    getLatest(): Observable<Plan> | Observable<any> | any { // very strange hack to get tslint to work properly :|
        return this.storage.get('latest').map((plan: Plan) => plan);
    }

    get(road: string) {
        return this.getRoadId(road)
            .flatMap(id => {
                if (id === -1) {
                    return Observable.from([this.emptyPlan()]);
                }

                let params = new URLSearchParams();
                params.set('action', 'get_tommeplan_year');
                params.set('target_adress', road);
                params.set('is_container', '0');
                params.set('id', id.toString());

                return this.http
                    .post('http://trv.no/wp-content/themes/sircon/aj/aj.php', params.toString(),
                    {
                        headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' })
                    })
                    .flatMap(response => {
                        let plan = this.mapToPlan(road, response.text());
						return this.storage.set('latest', plan).map(() => plan);
                    });
            });
    }

    getRoadId(road: string) {
		if(road){
			road = road.trim();
		}

        let params = new URLSearchParams();
        params.set('action', 'finn_tommeplan_adresser');
        params.set('adr', road);
        params.set('is_container', '0');
        return this.http
            .post('http://trv.no/wp-content/themes/sircon/aj/aj.php', params.toString(),
            {
                headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' })
            })
            .map(response => {
                let html = response.text();
                if (!html) {
                    return -1;
                }

                html = html[0] === '1' ? html.slice(1) : html;
                var adresses = $(html).find('.adr-option');
                if (!adresses || adresses.length !== 1) {
                    return -1;
                }

                return parseInt(adresses.attr('data-adrid'));
            });
    }

    private mapToPlan(road: string, html: string) {
        let weeks: Week[] = [];
        $(html)
            .find('.tomme-week')
            .each((index, week) => {
                let num = $(week).find('.tomme-week-title').text();
                num = num[4] + num[5];
                let types: string[] = [];
                $(week)
                    .find('.tomming-name')
                    .each((subindex, type) => types.push($(type).text()));

                weeks.push(new Week(parseInt(num), types));
            });

        return new Plan(weeks, road);
    }

    private emptyPlan() {
        return { weeks: [], activeWeeks: () => [] } as Plan;
    }

    private dummyHtml() {
        return `<div class="tommeplan-fullyear no-show-days">
		<div class="legend">
			<div class="legend-box tomming-papp_papir">Papp / Papir</div>
			<div class="legend-box tomming-plast">Plast</div>
			<div class="legend-box tomming-rest">Restavfall</div>
			<div class="tommeplancode">P7</div>
			<div class="target-address">Blåklokkevegen</div>
			<div class="print-button" data-sirconclick="print-year-tommeplan" data-cachefilename="145257_0">Skriv ut</div>
			<h4 style="margin:0;">2016</h4>
		</div>
		<div class="columns">
		<div class="column">
            <div class="tomme-week">
							<h4 class="tomme-week-title">Uke 01</h4><div class="tomme-weekdates">04.01-10.01</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 02</h4><div class="tomme-weekdates">11.01-17.01</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 03</h4><div class="tomme-weekdates">18.01-24.01</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div><div class="single-tomming tomming-juletre">
					<span class="tomming-name">Juletreinnsamling</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 04</h4><div class="tomme-weekdates">25.01-31.01</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 05</h4><div class="tomme-weekdates">01.02-07.02</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 06</h4><div class="tomme-weekdates">08.02-14.02</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 07</h4><div class="tomme-weekdates">15.02-21.02</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 08</h4><div class="tomme-weekdates">22.02-28.02</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 09</h4><div class="tomme-weekdates">29.02-06.03</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 10</h4><div class="tomme-weekdates">07.03-13.03</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 11</h4><div class="tomme-weekdates">14.03-20.03</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 12</h4><div class="tomme-weekdates">21.03-27.03</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 13</h4><div class="tomme-weekdates">28.03-03.04</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 14</h4><div class="tomme-weekdates">04.04-10.04</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 15</h4><div class="tomme-weekdates">11.04-17.04</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 16</h4><div class="tomme-weekdates">18.04-24.04</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 17</h4><div class="tomme-weekdates">25.04-01.05</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 18</h4><div class="tomme-weekdates">02.05-08.05</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --></div><div class="column"><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 19</h4><div class="tomme-weekdates">09.05-15.05</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div><div class="single-tomming tomming-hageavfall">
					<span class="tomming-name">Hageavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 20</h4><div class="tomme-weekdates">16.05-22.05</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 21</h4><div class="tomme-weekdates">23.05-29.05</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 22</h4><div class="tomme-weekdates">30.05-05.06</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 23</h4><div class="tomme-weekdates">06.06-12.06</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 24</h4><div class="tomme-weekdates">13.06-19.06</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 25</h4><div class="tomme-weekdates">20.06-26.06</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 26</h4><div class="tomme-weekdates">27.06-03.07</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 27</h4><div class="tomme-weekdates">04.07-10.07</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 28</h4><div class="tomme-weekdates">11.07-17.07</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 29</h4><div class="tomme-weekdates">18.07-24.07</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 30</h4><div class="tomme-weekdates">25.07-31.07</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 31</h4><div class="tomme-weekdates">01.08-07.08</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 32</h4><div class="tomme-weekdates">08.08-14.08</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 33</h4><div class="tomme-weekdates">15.08-21.08</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 34</h4><div class="tomme-weekdates">22.08-28.08</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 35</h4><div class="tomme-weekdates">29.08-04.09</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 36</h4><div class="tomme-weekdates">05.09-11.09</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --></div><div class="column"><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 37</h4><div class="tomme-weekdates">12.09-18.09</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 38</h4><div class="tomme-weekdates">19.09-25.09</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 39</h4><div class="tomme-weekdates">26.09-02.10</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 40</h4><div class="tomme-weekdates">03.10-09.10</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 41</h4><div class="tomme-weekdates">10.10-16.10</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 42</h4><div class="tomme-weekdates">17.10-23.10</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 43</h4><div class="tomme-weekdates">24.10-30.10</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 44</h4><div class="tomme-weekdates">31.10-06.11</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 45</h4><div class="tomme-weekdates">07.11-13.11</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 46</h4><div class="tomme-weekdates">14.11-20.11</div><div class="single-tomming tomming-tommefri-uke">
					<span class="tomming-name">Tømmefri uke</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 47</h4><div class="tomme-weekdates">21.11-27.11</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 48</h4><div class="tomme-weekdates">28.11-04.12</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 49</h4><div class="tomme-weekdates">05.12-11.12</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 50</h4><div class="tomme-weekdates">12.12-18.12</div><div class="single-tomming tomming-plast">
					<span class="tomming-name">Plastemballasje</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 51</h4><div class="tomme-weekdates">19.12-25.12</div><div class="single-tomming tomming-rest">
					<span class="tomming-name">Restavfall</span></div></div><!-- tomme-week --><div class="tomme-week">
			<h4 class="tomme-week-title">Uke 52</h4><div class="tomme-weekdates">26.12-01.01</div><div class="single-tomming tomming-papp_papir">
					<span class="tomming-name">Papp/Papir</span></div></div><!-- tomme-week --></div>
									</div></div>`;
    }
}