import { Week } from './week.model';
import * as moment from 'moment';
export class Plan {
    constructor(
        public weeks: Week[],
        public road: string,
        public city?: string,
        public id?: string) {
        this.weeks = this.weeks || [];

        if (!this.city) console.warn('city is not set');
        if (!this.id) console.warn('id is not set.');
    }

    activeWeeks() {
        var currentWeek = moment().startOf('isoWeek' as any).week();
        return this.weeks.filter(week => week.weekNumber >= currentWeek);
    }

    toPrettyString() {
        if (!this.city) return this.road;
        return `${this.road}, ${this.city}`;
    }
}