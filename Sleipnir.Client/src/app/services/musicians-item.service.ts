import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { CardMusicians } from '../interfaces/card-musicians';
import { CardMusicianAlbums } from '../interfaces/card-musician-albums';

@Injectable({
  providedIn: 'root'
})
export class MusiciansItemService {

  constructor(
    private httpClient: HttpClient,
  ) { }

public activeMusician: string = "";

  public pageItems: CardMusicians[] = [
    
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    
    
  ];

  public albumItems: CardMusicianAlbums[] = [

    
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    
    
    
  ];

  public getGenreItems(): CardMusicians[] {
    return this.pageItems;
  }

  public getMusicianAlbumItems(): CardMusicianAlbums[] {
    return this.albumItems;
  }

  public getAllGenres(): Observable<CardMusicians[]> {
    return this.httpClient.get<CardMusicians[]>(environment.apiUrl + 'Genre/getGenres')
  }

}
