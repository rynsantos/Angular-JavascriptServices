
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

import { Hero } from '../shared/hero';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class DashboardService {

  private _baseUrl = ''; //url to web api
  private _httpClient: HttpClient;

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {

    this._httpClient = http;
    this._baseUrl = baseUrl;
  }

  getTopHeroes(): Observable<Hero[]> {

    const url = `${this._baseUrl}/api/Heroes/TopHeroes`;
    return this._httpClient
      .get<Hero[]>(url);
  }

  /** POST: add a new hero to the server */
  addHero(hero: Hero): Observable<Hero> {



    const url = `${this._baseUrl}/api/Heroes`;
    return this._httpClient.post<Hero>(url, hero, httpOptions);
  }


  //addHero(hero: Hero): Observable<Hero> {
  //  return this.http.post<Hero>(this.heroesUrl, hero, httpOptions).pipe(
  //    tap((hero: Hero) => this.log(`added hero w/ id=${hero.id}`)),
  //    catchError(this.handleError<Hero>('addHero'))
  //  );
  //}
}
