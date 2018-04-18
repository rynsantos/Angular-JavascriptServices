import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Hero } from '../shared/hero';
import { HeroDetailService } from './hero-detail.service';


@Component({
  selector: 'app-herodetail-component',
  templateUrl: './hero-detail.component.html'
})

export class HeroDetailComponent implements OnInit {

  public hero: Hero;
  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private heroDetailService: HeroDetailService
  ) { }

  ngOnInit() {
    this.getHero();
  }

  getHero(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.heroDetailService
      .getHero(id)
      .subscribe(heroResult => this.hero = heroResult);
  }

  goBack(): void {
    this.location.back();
  }
}
