import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Hero } from '../shared/hero';
//import { DashboardService } from './hero-detail.service';


@Component({
  selector: 'app-herodetail-component',
  templateUrl: './hero-detail.component.html'
})

export class HeroDetailComponent implements OnInit {

  public heroes: Hero[];

  constructor() {

  }

  ngOnInit() {

  }

  getHeroes(): void {
    
  }
}
