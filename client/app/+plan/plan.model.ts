import { Week } from './week.model';
import * as moment from 'moment';
export class Plan {
    constructor(
        public weeks: Week[],
        public road: string) {
        this.weeks = this.weeks || [];
    }

    activeWeeks() {
        var currentWeek = moment().startOf('isoWeek' as any).week() - 1;
        return this.weeks.filter(week => week.weekNumber >= currentWeek);
    }
}