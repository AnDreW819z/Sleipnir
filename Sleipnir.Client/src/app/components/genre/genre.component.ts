import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CardGenre } from '../../interfaces/card-genre';
import { GenreItemService } from '../../services/genre-item.service';

@Component({
  selector: 'app-genre',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './genre.component.html',
  styleUrl: './genre.component.scss'
})
export class GenreComponent implements OnInit{

  constructor(
    public genreService: GenreItemService,
  
    ) { }

  public navItems: CardGenre[] = [];

  public ngOnInit(): void {
    this.loadGenres();
    //this.navItems = this.genreService.getGenreItems();
    console.log(this.navItems.length);
  }

  private loadGenres(): void {
    this.genreService.getAllGenres().subscribe(genresFromService => {
      this.navItems = genresFromService;
    });
  }
}



