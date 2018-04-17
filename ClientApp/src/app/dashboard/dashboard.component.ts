import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Hero } from '../shared/hero';
import { DashboardService } from './dashboard.service';


@Component({
  selector: 'app-dashboard-component',
  templateUrl: './dashboard.component.html'
})

export class DashboarComponent {
  
  public heroes: Hero[];

  private dashboardService: DashboardService;
  constructor(dashboardService: DashboardService) {
    this.dashboardService = dashboardService;
  }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes(): void {
    
    this.dashboardService.getTopHeroes()
      .subscribe(heroesResult => this.heroes = heroesResult);
  }
}
