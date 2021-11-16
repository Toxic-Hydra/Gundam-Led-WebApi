import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-light',
  templateUrl: './light.component.html'
})
export class LightComponent {
  public lights: Led[];
  public newLight: Led = {
    id: 0,
    red: 0,
    green: 0,
    blue: 0
  };
  private _http: HttpClient;
  private _baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;

    this._http.get<Led[]>(baseUrl + 'Led').subscribe(result => {
      this.lights = result;
    }, error => console.error(error));
  }

  onButtonConfirm() {
    console.log(this._baseUrl);
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    console.log(JSON.stringify(this.newLight));
    this._http.post<Led>(this._baseUrl + 'Led', JSON.stringify(this.newLight), httpOptions).subscribe(reply => {
      console.log(reply);
    });
  }
}

interface Led {
  id: number;
  red: number;
  green: number;
  blue: number;
}
