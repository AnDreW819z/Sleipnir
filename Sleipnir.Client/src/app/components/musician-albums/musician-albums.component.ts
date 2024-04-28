import { Component } from '@angular/core';
import { CardMusicianAlbums } from '../../interfaces/card-musician-albums';
import { MusiciansItemService } from '../../services/musicians-item.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-musician-albums',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './musician-albums.component.html',
  styleUrl: './musician-albums.component.scss'
})
export class MusicianAlbumsComponent {
  constructor(
    public musiciansService: MusiciansItemService,
  
    ) { }

  public navItems: CardMusicianAlbums[] = [];

  public ngOnInit(): void {
    this.navItems = this.musiciansService.getMusicianAlbumItems();
  }
}
