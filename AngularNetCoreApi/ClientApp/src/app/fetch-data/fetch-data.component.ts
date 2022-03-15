import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public members: MemberEntity[];
  public success: boolean;

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<MemberEntity[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.members = result;
      this.success = true;
    }, error => console.error(error));
  }

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface MemberEntity {

  memberId: number;
  firstName: string;
  lastName: string;
  address: string

}
