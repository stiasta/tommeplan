export class Week {
    constructor(
        public weekNumber: number,
        public types: string[]
    ) {
    }

    getStartDate() {
        return this.firstDayOfWeek(this.weekNumber);
    }

    getEndDate() {
        let start = this.getStartDate();
        start.setDate(start.getDate() + 6);
        return start;
    }

    private firstDayOfWeek(week: number, year?: number) {
        if (year == null) {
            year = (new Date()).getFullYear();
        }

        var date = this.firstWeekOfYear(year),
            weekTime = this.weeksToMilliseconds(week),
            targetTime = date.getTime() + weekTime;

        date.setTime(targetTime);
        return date;
    }

    private weeksToMilliseconds(weeks) {
        return 1000 * 60 * 60 * 24 * 7 * (weeks - 1);
    }

    private firstWeekOfYear(year) {
        var date = new Date();
        date = this.firstDayOfYear(date, year);
        date = this.firstWeekday(date);
        return date;
    }

    private firstDayOfYear(date, year) {
        date.setYear(year);
        date.setDate(1);
        date.setMonth(0);
        date.setHours(0);
        date.setMinutes(0);
        date.setSeconds(0);
        date.setMilliseconds(0);
        return date;
    }

    /**
     * Sets the given date as the first day of week of the first week of year.
     */
    private firstWeekday(firstOfJanuaryDate) {
        // 0 correspond au dimanche et 6 correspond au samedi.
        var FIRST_DAY_OF_WEEK = 1; // Monday, according to iso8601
        var WEEK_LENGTH = 7; // 7 days per week
        var day = firstOfJanuaryDate.getDay();
        day = (day === 0) ? 7 : day; // make the days monday-sunday equals to 1-7 instead of 0-6
        var dayOffset = -day + FIRST_DAY_OF_WEEK; // dayOffset will correct the date in order to get a Monday
        if (WEEK_LENGTH - day + 1 < 4) {
            // the current week has not the minimum 4 days required by iso 8601 => add one week
            dayOffset += WEEK_LENGTH;
        }
        return new Date(firstOfJanuaryDate.getTime() + dayOffset * 24 * 60 * 60 * 1000);
    }
}
