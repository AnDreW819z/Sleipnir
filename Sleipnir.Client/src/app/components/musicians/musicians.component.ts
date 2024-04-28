import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CardMusicians } from '../../interfaces/card-musicians';
import { MusiciansItemService } from '../../services/musicians-item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-musicians',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './musicians.component.html',
  styleUrl: './musicians.component.scss'
})
export class MusiciansComponent implements OnInit{
  constructor(
    public musiciansService: MusiciansItemService,
    
    private router: Router
    ) { }

  public navItems: CardMusicians[] = [];

  public ngOnInit(): void {
    this.navItems = this.musiciansService.getGenreItems();
  }

  public musicianPage(id: number) {
    
    let stringId = String(id);
    this.router.navigate([`/musicians/${stringId}`]);
  }



  // private loadGenres(): void {
  //   this.musiciansService.getAllGenres().subscribe(musiciansFromService => {
  //     this.navItems = musiciansFromService;
  //   });
  // }
}
